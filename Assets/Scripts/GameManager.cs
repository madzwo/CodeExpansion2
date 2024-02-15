using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject enemy;
    public GameObject boss1;
    public GameObject boss2;
    public GameObject boss3;
    public GameObject puffStar;
    public GameObject kirin;
    private bool stagePhase;
    private bool bossPhase;
    private bool deadPhase;
    private bool endPhase;
    public GameObject winnerText;
    public GameObject gameOverText;
    public GameObject titleText;
    public Text livesText;
    private int playerLives;
    private int timer;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        playerLives = 10;
        stagePhase = true;
        bossPhase = false;
        deadPhase = false;
        endPhase = false;
        Debug.Log(SceneManager.GetActiveScene().name + ":START");
        Application.targetFrameRate = 60;
        if (TitleManager.eZMode)
        {
            puffStar.SetActive(false);
            kirin.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1;
        livesText.text = "Lives:" + playerLives.ToString();
        if (SceneManager.GetActiveScene().name == "Stage1")
        {
            Stage1();
        }
        if (SceneManager.GetActiveScene().name == "Stage2")
        {
            Stage2();
        }
        if (SceneManager.GetActiveScene().name == "Stage3")
        {
            Stage3();
        }
    }

    public void PlayerHit()
    {
        playerLives -= 1;
        if (playerLives < 1)
        {
            deadPhase = true;
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
    }

    public void ToTitle()
    {
        SceneManager.LoadSceneAsync("Title");
    }

    private void EnemySpawn(Vector2 v, int m, int s)
    {
        GameObject spawnedE1 = Instantiate(enemy, v, this.transform.rotation);
        Enemy1 spawnE = spawnedE1.GetComponent<Enemy1>();
        spawnE.moveMode = m;
        spawnE.shootMode = s;
    }

    private void Stage1()
    {
        if (stagePhase)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                stagePhase = false;
                bossPhase = true;
                boss1.SetActive(true);
                Debug.Log("woot");
            }
        }
        if (bossPhase)
        {
            if (GameObject.FindGameObjectsWithTag("Boss1").Length == 0)
            {
                bossPhase = false;
                endPhase = true;
            }
        }
        if (endPhase)
        {
            winnerText.SetActive(true);
            titleText.SetActive(true);

        }
        if (deadPhase)
        {
            gameOverText.SetActive(true);
            titleText.SetActive(true);
        }
    }
    private void Stage2()
    {
        if (stagePhase)
        {
            switch (timer)
            {
                case 10:
                    EnemySpawn(new Vector2(0, 11), 1, 1);
                    break;
                case 100:
                    EnemySpawn(new Vector2(-1, 11), 1, 1);
                    EnemySpawn(new Vector2(1, 11), 1, 1);
                    break;
                case 200:
                    EnemySpawn(new Vector2(-5, 11), 1, 1);
                    EnemySpawn(new Vector2(5, 11), 1, 1);
                    break;
                case 500:
                    EnemySpawn(new Vector2(0, 11), 1, 1);
                    break;
                case 600:
                    EnemySpawn(new Vector2(-4, 11), 2, 3);
                    EnemySpawn(new Vector2(4, 11), 2, 3);
                    break;
                case 700:
                    EnemySpawn(new Vector2(-5, 11), 1, 1);
                    EnemySpawn(new Vector2(0, 11), 1, 1);
                    EnemySpawn(new Vector2(5, 11), 1, 1);
                    break;
                case 1000:
                    EnemySpawn(new Vector2(-5, 11), 1, 1);
                    EnemySpawn(new Vector2(-3, 11), 1, 1);
                    EnemySpawn(new Vector2(-1, 11), 1, 1);
                    EnemySpawn(new Vector2(1, 11), 1, 1);
                    EnemySpawn(new Vector2(3, 11), 1, 1);
                    EnemySpawn(new Vector2(5, 11), 1, 1);
                    break;
                case 1250:
                    EnemySpawn(new Vector2(-5, 11), 1, 1);
                    EnemySpawn(new Vector2(-3, 11), 2, 3);
                    EnemySpawn(new Vector2(-1, 11), 1, 1);
                    EnemySpawn(new Vector2(1, 11), 1, 1);
                    EnemySpawn(new Vector2(3, 11), 2, 3);
                    EnemySpawn(new Vector2(5, 11), 1, 1);
                    break;
                case 1500:
                    EnemySpawn(new Vector2(-2, 11), 1, 1);
                    EnemySpawn(new Vector2(2, 11), 1, 1);
                    break;
                // case 2900:
                //     EnemySpawn(new Vector2(0, 11), 1, 1);
                //     break;
                // case 3000:
                //     EnemySpawn(new Vector2(-1, 11), 1, 1);
                //     EnemySpawn(new Vector2(1, 11), 1, 1);
                //     break;
                // case 3100:
                //     EnemySpawn(new Vector2(-5, 11), 1, 1);
                //     EnemySpawn(new Vector2(5, 11), 1, 1);
                //     break;
                // case 3300:
                //     EnemySpawn(new Vector2(-3, 11), 1, 1);
                //     EnemySpawn(new Vector2(3, 11), 1, 1);
                //     break;
                // case 3500:
                //     EnemySpawn(new Vector2(-5, 11), 2, 3);
                //     EnemySpawn(new Vector2(5, 11), 2, 3);
                //     break;
                // case 4000:
                //     EnemySpawn(new Vector2(0, 11), 1, 1);
                //     EnemySpawn(new Vector2(-1, 11), 1, 1);
                //     EnemySpawn(new Vector2(1, 11), 1, 1);
                //     break;
                // case 4500:
                //     EnemySpawn(new Vector2(-5, 11), 1, 1);
                //     EnemySpawn(new Vector2(-3, 11), 1, 1);
                //     EnemySpawn(new Vector2(-1, 11), 1, 1);
                //     EnemySpawn(new Vector2(1, 11), 1, 1);
                //     EnemySpawn(new Vector2(3, 11), 1, 1);
                //     EnemySpawn(new Vector2(5, 11), 1, 1);
                //     break;
                // case 5000:
                //     EnemySpawn(new Vector2(-5, 11), 2, 3);
                //     EnemySpawn(new Vector2(5, 11), 2, 3);
                //     break;
                // case 5500:
                //     EnemySpawn(new Vector2(-3, 11), 1, 1);
                //     EnemySpawn(new Vector2(3, 11), 1, 1);
                //     break;
                // case 6000:
                //     EnemySpawn(new Vector2(-2, 11), 2, 3);
                //     EnemySpawn(new Vector2(2, 11), 2, 3);
                //     break;
                // case 6100:
                //     EnemySpawn(new Vector2(-1, 11), 1, 1);
                //     EnemySpawn(new Vector2(1, 11), 1, 1);
                //     break;
                case 2500:
                    bossPhase = true;
                    boss2.SetActive(true);
                    Debug.Log("woot");
                    break;
            }
        }
        if (bossPhase)
        {
            if (GameObject.FindGameObjectsWithTag("Boss2").Length == 0)
            {
                bossPhase = false;
                endPhase = true;
            }
        }
        if (endPhase)
        {
            winnerText.SetActive(true);
            titleText.SetActive(true);

        }
        if (deadPhase)
        {
            gameOverText.SetActive(true);
            titleText.SetActive(true);
        }

    }
    private void Stage3()
    {
        if (stagePhase)
        {
            switch (timer)
            {
                case 100:
                    EnemySpawn(new Vector2(-4, 11), 4, 0);
                    break;
                case 130:
                    EnemySpawn(new Vector2(-4, 11), 4, 0);
                    break;
                case 160:
                    EnemySpawn(new Vector2(-4, 11), 4, 0);
                    break;
                case 190:
                    EnemySpawn(new Vector2(-4, 11), 4, 0);
                    break;
                case 220:
                    EnemySpawn(new Vector2(-4, 11), 4, 0);
                    break;
                case 230:
                    EnemySpawn(new Vector2(4, 11), 3, 0);
                    break;
                case 260:
                    EnemySpawn(new Vector2(4, 11), 3, 0);
                    break;
                case 290:
                    EnemySpawn(new Vector2(4, 11), 3, 0);
                    break;
                case 320:
                    EnemySpawn(new Vector2(4, 11), 3, 0);
                    break;
                case 350:
                    EnemySpawn(new Vector2(4, 11), 3, 0);
                    break;
                case 380:
                    EnemySpawn(new Vector2(4, 11), 3, 0);
                    break;
                case 410:
                    EnemySpawn(new Vector2(4, 11), 3, 0);
                    break;
                case 440:
                    EnemySpawn(new Vector2(4, 11), 3, 0);
                    break;
                case 500:
                    EnemySpawn(new Vector2(-5.5f, 11), 1, 0);
                    EnemySpawn(new Vector2(5.5f, 11), 1, 0);
                    break;
                case 530:
                    EnemySpawn(new Vector2(-5, 11), 1, 0);
                    EnemySpawn(new Vector2(5, 11), 1, 0);
                    break;
                case 560:
                    EnemySpawn(new Vector2(-4.5f, 11), 1, 0);
                    EnemySpawn(new Vector2(-4.5f, 11), 1, 0);
                    break;
                case 590:
                    EnemySpawn(new Vector2(-4, 11), 1, 0);
                    EnemySpawn(new Vector2(4, 11), 1, 0);
                    break;
                case 620:
                    EnemySpawn(new Vector2(-3.5f, 11), 1, 0);
                    EnemySpawn(new Vector2(3.5f, 11), 1, 0);
                    break;
                case 650:
                    EnemySpawn(new Vector2(-3, 11), 1, 0);
                    EnemySpawn(new Vector2(3, 11), 1, 0);
                    break;
                case 680:
                    EnemySpawn(new Vector2(-2.5f, 11), 1, 0);
                    EnemySpawn(new Vector2(2.5f, 11), 1, 0);
                    break;
                case 710:
                    EnemySpawn(new Vector2(-2, 11), 1, 0);
                    EnemySpawn(new Vector2(2, 11), 1, 0);
                    break;
                case 740:
                    EnemySpawn(new Vector2(-1.5f, 11), 1, 0);
                    EnemySpawn(new Vector2(1.5f, 11), 1, 0);
                    break;
                case 770:
                    EnemySpawn(new Vector2(-1, 11), 1, 0);
                    EnemySpawn(new Vector2(1, 11), 1, 0);
                    break;
                case 800:
                    EnemySpawn(new Vector2(0, 11), 1, 0);
                    break;
                case 900:
                    EnemySpawn(new Vector2(-5, 11), 2, 4);
                    break;
                case 950:
                    EnemySpawn(new Vector2(2, 11), 2, 4);
                    break;
                case 1000:
                    EnemySpawn(new Vector2(-3, 11), 2, 4);
                    break;
                case 1050:
                    EnemySpawn(new Vector2(5, 11), 2, 4);
                    break;
                case 1100:
                    EnemySpawn(new Vector2(-5, 11), 2, 4);
                    break;
                case 1150:
                    EnemySpawn(new Vector2(4, 11), 2, 4);
                    break;
                case 1170:
                    EnemySpawn(new Vector2(-3, 11), 2, 4);
                    break;
                case 1190:
                    EnemySpawn(new Vector2(3, 11), 2, 4);
                    break;
                case 1210:
                    EnemySpawn(new Vector2(-4, 11), 2, 4);
                    break;
                case 1230:
                    EnemySpawn(new Vector2(1, 11), 2, 4);
                    break;
                case 1250:
                    EnemySpawn(new Vector2(-5, 11), 2, 4);
                    break;
                case 1260:
                    EnemySpawn(new Vector2(4, 11), 2, 4);
                    break;
                case 1270:
                    EnemySpawn(new Vector2(0, 11), 2, 4);
                    break;
                case 1280:
                    EnemySpawn(new Vector2(-5, 11), 2, 4);
                    break;
                case 1290:
                    EnemySpawn(new Vector2(2, 11), 2, 4);
                    break;
                case 1400:
                    EnemySpawn(new Vector2(5, 11), 3, 0);
                    break;
                case 1420:
                    EnemySpawn(new Vector2(1, 11), 3, 0);
                    break;
                case 1440:
                    EnemySpawn(new Vector2(-1, 11), 4, 0);
                    break;
                case 1460:
                    EnemySpawn(new Vector2(0, 11), 4, 0);
                    break;
                case 1480:
                    EnemySpawn(new Vector2(0, 11), 3, 0);
                    break;
                case 1500:
                    EnemySpawn(new Vector2(-5, 11), 4, 0);
                    break;
                case 1520:
                    EnemySpawn(new Vector2(-2, 11), 4, 0);
                    break;
                case 1540:
                    EnemySpawn(new Vector2(0, 11), 3, 0);
                    break;
                case 1560:
                    EnemySpawn(new Vector2(5, 11), 3, 0);
                    break;
                case 1580:
                    EnemySpawn(new Vector2(0, 11), 3, 0);
                    break;
                case 1600:
                    EnemySpawn(new Vector2(0, 11), 4, 0);
                    break;
                case 1620:
                    EnemySpawn(new Vector2(1, 11), 3, 0);
                    break;
                case 1640:
                    EnemySpawn(new Vector2(-1, 11), 4, 0);
                    break;
                case 1700:
                    EnemySpawn(new Vector2(5, 11), 3, 0);
                    EnemySpawn(new Vector2(4, 11), 3, 0);
                    break;
                case 1730:
                    EnemySpawn(new Vector2(5, 11), 3, 0);
                    EnemySpawn(new Vector2(4, 11), 3, 0);
                    break;
                case 1760:
                    EnemySpawn(new Vector2(5, 11), 3, 0);
                    EnemySpawn(new Vector2(4, 11), 3, 0);
                    break;
                case 1790:
                    EnemySpawn(new Vector2(5, 11), 3, 0);
                    EnemySpawn(new Vector2(4, 11), 3, 0);
                    break;
                case 1820:
                    EnemySpawn(new Vector2(5, 11), 3, 0);
                    EnemySpawn(new Vector2(4, 11), 3, 0);
                    break;
                case 1850:
                    EnemySpawn(new Vector2(-5, 11), 4, 0);
                    EnemySpawn(new Vector2(-4, 11), 4, 0);
                    break;
                case 1880:
                    EnemySpawn(new Vector2(-5, 11), 4, 0);
                    EnemySpawn(new Vector2(-4, 11), 4, 0);
                    break;
                case 1910:
                    EnemySpawn(new Vector2(-5, 11), 4, 0);
                    EnemySpawn(new Vector2(-4, 11), 4, 0);
                    break;
                case 1940:
                    EnemySpawn(new Vector2(-5, 11), 4, 0);
                    EnemySpawn(new Vector2(-4, 11), 4, 0);
                    break;
                case 1970:
                    EnemySpawn(new Vector2(-5, 11), 4, 0);
                    EnemySpawn(new Vector2(-4, 11), 4, 0);
                    break;
                case 2000:
                    EnemySpawn(new Vector2(-5, 11), 4, 0);
                    EnemySpawn(new Vector2(-4, 11), 4, 0);
                    break;
                case 2030:
                    EnemySpawn(new Vector2(-5, 11), 4, 0);
                    EnemySpawn(new Vector2(-4, 11), 4, 0);
                    break;
                case 2060:
                    EnemySpawn(new Vector2(-5, 11), 4, 0);
                    EnemySpawn(new Vector2(-4, 11), 4, 0);
                    break;
                case 2200:
                    EnemySpawn(new Vector2(4, 11), 2, 4);
                    break;
                case 2250:
                    EnemySpawn(new Vector2(-1, 11), 2, 4);
                    break;
                case 2300:
                    EnemySpawn(new Vector2(5, 11), 2, 4);
                    break;
                case 2350:
                    EnemySpawn(new Vector2(-5, 11), 2, 4);
                    break;
                case 2400:
                    EnemySpawn(new Vector2(1, 11), 2, 4);
                    break;
                case 2450:
                    EnemySpawn(new Vector2(4, 11), 2, 4);
                    break;
                case 2470:
                    EnemySpawn(new Vector2(-4, 11), 2, 4);
                    break;
                case 2490:
                    EnemySpawn(new Vector2(-3, 11), 2, 4);
                    break;
                case 2510:
                    EnemySpawn(new Vector2(3, 11), 2, 4);
                    break;
                case 2530:
                    EnemySpawn(new Vector2(5, 11), 2, 4);
                    break;
                case 2550:
                    EnemySpawn(new Vector2(-5, 11), 2, 4);
                    break;
                case 2560:
                    EnemySpawn(new Vector2(2, 11), 2, 4);
                    break;
                case 2570:
                    EnemySpawn(new Vector2(2, 11), 2, 4);
                    break;
                case 2580:
                    EnemySpawn(new Vector2(1, 11), 2, 4);
                    break;
                case 2590:
                    EnemySpawn(new Vector2(0, 11), 2, 4);
                    break;
                case 2600:
                    EnemySpawn(new Vector2(5, 11), 3, 0);
                    EnemySpawn(new Vector2(4, 11), 3, 0);
                    break;
                case 2630:
                    EnemySpawn(new Vector2(5, 11), 3, 0);
                    EnemySpawn(new Vector2(4, 11), 3, 0);
                    break;
                case 2660:
                    EnemySpawn(new Vector2(5, 11), 3, 0);
                    EnemySpawn(new Vector2(4, 11), 3, 0);
                    break;
                case 2690:
                    EnemySpawn(new Vector2(5, 11), 3, 0);
                    EnemySpawn(new Vector2(4, 11), 3, 0);
                    break;
                case 2720:
                    EnemySpawn(new Vector2(5, 11), 3, 0);
                    EnemySpawn(new Vector2(4, 11), 3, 0);
                    break;
                case 2750:
                    EnemySpawn(new Vector2(-5, 11), 4, 0);
                    EnemySpawn(new Vector2(-4, 11), 4, 0);
                    break;
                case 2780:
                    EnemySpawn(new Vector2(-5, 11), 4, 0);
                    EnemySpawn(new Vector2(-4, 11), 4, 0);
                    break;
                case 2810:
                    EnemySpawn(new Vector2(-5, 11), 4, 0);
                    EnemySpawn(new Vector2(-4, 11), 4, 0);
                    break;
                case 2840:
                    EnemySpawn(new Vector2(-5, 11), 4, 0);
                    EnemySpawn(new Vector2(-4, 11), 4, 0);
                    break;
                case 2870:
                    EnemySpawn(new Vector2(-5, 11), 4, 0);
                    EnemySpawn(new Vector2(-4, 11), 4, 0);
                    break;
                case 2900:
                    EnemySpawn(new Vector2(-5, 11), 4, 0);
                    EnemySpawn(new Vector2(-4, 11), 4, 0);
                    break;
                case 2930:
                    EnemySpawn(new Vector2(-5, 11), 4, 0);
                    EnemySpawn(new Vector2(-4, 11), 4, 0);
                    break;
                case 2960:
                    EnemySpawn(new Vector2(-5, 11), 4, 0);
                    EnemySpawn(new Vector2(-4, 11), 4, 0);
                    break;
                case 3000:
                    EnemySpawn(new Vector2(5, 11), 3, 0);
                    EnemySpawn(new Vector2(4, 11), 3, 0);
                    break;
                case 3030:
                    EnemySpawn(new Vector2(5, 11), 3, 0);
                    EnemySpawn(new Vector2(4, 11), 3, 0);
                    break;
                case 3060:
                    EnemySpawn(new Vector2(5, 11), 3, 0);
                    EnemySpawn(new Vector2(4, 11), 3, 0);
                    break;
                case 3090:
                    EnemySpawn(new Vector2(5, 11), 3, 0);
                    EnemySpawn(new Vector2(4, 11), 3, 0);
                    break;
                case 3120:
                    EnemySpawn(new Vector2(5, 11), 3, 0);
                    EnemySpawn(new Vector2(4, 11), 3, 0);
                    break;
                case 3150:
                    EnemySpawn(new Vector2(-5, 11), 4, 0);
                    EnemySpawn(new Vector2(-4, 11), 4, 0);
                    break;
                case 3180:
                    EnemySpawn(new Vector2(-5, 11), 4, 0);
                    EnemySpawn(new Vector2(-4, 11), 4, 0);
                    break;
                case 3210:
                    EnemySpawn(new Vector2(-5, 11), 4, 0);
                    EnemySpawn(new Vector2(-4, 11), 4, 0);
                    break;
                case 3240:
                    EnemySpawn(new Vector2(-5, 11), 4, 0);
                    EnemySpawn(new Vector2(-4, 11), 4, 0);
                    break;
                case 3270:
                    EnemySpawn(new Vector2(-5, 11), 4, 0);
                    EnemySpawn(new Vector2(-4, 11), 4, 0);
                    break;
                case 3300:
                    EnemySpawn(new Vector2(-5, 11), 4, 0);
                    EnemySpawn(new Vector2(-4, 11), 4, 0);
                    break;
                case 3330:
                    EnemySpawn(new Vector2(-5, 11), 4, 0);
                    EnemySpawn(new Vector2(-4, 11), 4, 0);
                    break;
                case 3360:
                    EnemySpawn(new Vector2(-5, 11), 4, 0);
                    EnemySpawn(new Vector2(-4, 11), 4, 0);
                    break;
                case 4000:
                    bossPhase = true;
                    boss3.SetActive(true);
                    Debug.Log("woot");
                    break;
            }
            
        }
        if (bossPhase)
        {
            if (GameObject.FindGameObjectsWithTag("Boss3").Length == 0)
            {
                bossPhase = false;
                endPhase = true;
            }
        }
        if (endPhase)
        {
            winnerText.SetActive(true);
            titleText.SetActive(true);

        }
        if (deadPhase)
        {
            gameOverText.SetActive(true);
            titleText.SetActive(true);
        }
    }
}
