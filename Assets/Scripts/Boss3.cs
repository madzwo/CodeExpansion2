using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3 : MonoBehaviour
{
    private bool myColor;
    private SpriteRenderer m_SpriteRenderer;
    public GameObject bullet;
    public GameObject bullet2;
    private Rigidbody2D rb;
    private Transform tf;
    private GameObject player;
    private int timer;
    public GameObject explode;
    private int movePhase;
    private int life;
    private int pattern;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        tf = this.GetComponent<Transform>();
        myColor = Random.value > 0.5f;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        if (myColor)
        {
            m_SpriteRenderer.color = Color.white;
        }
        else
        {
            m_SpriteRenderer.color = Color.black;
        }
        player = GameObject.FindGameObjectWithTag("Player");
        timer = 0;
        life = 75;
        movePhase = Random.Range(0, 4);
        pattern = Random.Range(0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        switch (pattern)
        {
            case 0:
                Demarcation();
                break;
            case 1:
                MultiCircle();
                break;
            case 2:
                HomingWaves();
                break;
            case 3:
                SideRain();
                break;
        }
        timer += 1;
        IsAlive();
    }

    private void MovePoint()
    {
        movePhase = Random.Range(0, 4);
        switch (movePhase)
        {
            case 0:
                transform.position = new Vector2(0, 6);
                break;
            case 1:
                transform.position = new Vector2(-3, 6);
                break;
            case 2:
                transform.position = new Vector2(3, 6);
                break;
            case 3:
                transform.position = new Vector2(0, 4);
                break;
        }
    }

    private void Demarcation()
    {
        switch (timer)
        {
            case 50:
                for (int i = 0; i < 10; i++)
                {
                    Vector2 playerDirection = (player.transform.position - transform.position).normalized;
                    float aimTowards = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg - 90f;
                    GameObject shotFired = Instantiate(bullet2, this.transform.position, this.transform.rotation);
                    BulletE2 shotBullet = shotFired.GetComponent<BulletE2>();
                    shotBullet.angle = -(aimTowards) + (10f * i);
                    shotBullet.speed = 10f;
                    shotBullet.moveMode = 2;
                    shotBullet.shootMode = 2;

                }
                break;
            case 75:
                for (int i = 0; i < 10; i++)
                {
                    Vector2 playerDirection = (player.transform.position - transform.position).normalized;
                    float aimTowards = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg - 90f;
                    GameObject shotFired = Instantiate(bullet2, this.transform.position, this.transform.rotation);
                    BulletE2 shotBullet = shotFired.GetComponent<BulletE2>();
                    shotBullet.angle = -(aimTowards) - (10f * i);
                    shotBullet.speed = 10f;
                    shotBullet.moveMode = 2;
                    shotBullet.shootMode = 2;

                }
                break;
            case 150:
                for (int i = 0; i < 10; i++)
                {
                    Vector2 playerDirection = (player.transform.position - transform.position).normalized;
                    float aimTowards = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg - 90f;
                    GameObject shotFired = Instantiate(bullet2, this.transform.position, this.transform.rotation);
                    BulletE2 shotBullet = shotFired.GetComponent<BulletE2>();
                    shotBullet.angle = -(aimTowards) + (10f * i);
                    shotBullet.speed = 10f;
                    shotBullet.moveMode = 2;
                    shotBullet.shootMode = 2;

                }
                break;
            case 175:
                for (int i = 0; i < 10; i++)
                {
                    Vector2 playerDirection = (player.transform.position - transform.position).normalized;
                    float aimTowards = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg - 90f;
                    GameObject shotFired = Instantiate(bullet2, this.transform.position, this.transform.rotation);
                    BulletE2 shotBullet = shotFired.GetComponent<BulletE2>();
                    shotBullet.angle = -(aimTowards) - (10f * i);
                    shotBullet.speed = 10f;
                    shotBullet.moveMode = 2;
                    shotBullet.shootMode = 2;

                }
                break;
            case 250:
                for (int i = 0; i < 10; i++)
                {
                    Vector2 playerDirection = (player.transform.position - transform.position).normalized;
                    float aimTowards = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg - 90f;
                    GameObject shotFired = Instantiate(bullet2, this.transform.position, this.transform.rotation);
                    BulletE2 shotBullet = shotFired.GetComponent<BulletE2>();
                    shotBullet.angle = -(aimTowards) + (10f * i);
                    shotBullet.speed = 10f;
                    shotBullet.moveMode = 2;
                    shotBullet.shootMode = 2;

                }
                break;
            case 275:
                for (int i = 0; i < 10; i++)
                {
                    Vector2 playerDirection = (player.transform.position - transform.position).normalized;
                    float aimTowards = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg - 90f;
                    GameObject shotFired = Instantiate(bullet2, this.transform.position, this.transform.rotation);
                    BulletE2 shotBullet = shotFired.GetComponent<BulletE2>();
                    shotBullet.angle = -(aimTowards) - (10f * i);
                    shotBullet.speed = 10f;
                    shotBullet.moveMode = 2;
                    shotBullet.shootMode = 2;

                }
                break;
            case 300:
                pattern = Random.Range(0, 4);
                MovePoint();
                timer = 0;
                break;
        }
    }

    private void MultiCircle()
    {
        switch (timer)
        {
            case 50:
                for (int i = 0; i < 20; i++)
                {
                    Vector2 playerDirection = (player.transform.position - transform.position).normalized;
                    float aimTowards = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg - 90f;
                    GameObject shotFired = Instantiate(bullet, this.transform.position, this.transform.rotation);
                    BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
                    shotBullet.angle = (aimTowards) + (18f * i);
                    shotBullet.speed = 20f;

                }
                break;
            case 75:
                for (int i = 0; i < 20; i++)
                {
                    Vector2 playerDirection = (player.transform.position - transform.position).normalized;
                    float aimTowards = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg - 90f;
                    GameObject shotFired = Instantiate(bullet, this.transform.position, this.transform.rotation);
                    BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
                    shotBullet.angle = (aimTowards) + (18f * i);
                    shotBullet.speed = 20f;

                }
                break;
            case 100:
                for (int i = 0; i < 20; i++)
                {
                    Vector2 playerDirection = (player.transform.position - transform.position).normalized;
                    float aimTowards = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg - 90f;
                    GameObject shotFired = Instantiate(bullet, this.transform.position, this.transform.rotation);
                    BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
                    shotBullet.angle = (aimTowards) + (18f * i);
                    shotBullet.speed = 20f;

                }
                break;
            case 150:
                for (int i = 0; i < 20; i++)
                {
                    Vector2 playerDirection = (player.transform.position - transform.position).normalized;
                    float aimTowards = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg - 90f;
                    GameObject shotFired = Instantiate(bullet, this.transform.position, this.transform.rotation);
                    BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
                    shotBullet.angle = (aimTowards) + (18f * i);
                    shotBullet.speed = 20f;

                }
                break;
            case 175:
                for (int i = 0; i < 20; i++)
                {
                    Vector2 playerDirection = (player.transform.position - transform.position).normalized;
                    float aimTowards = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg - 90f;
                    GameObject shotFired = Instantiate(bullet, this.transform.position, this.transform.rotation);
                    BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
                    shotBullet.angle = (aimTowards) + (18f * i);
                    shotBullet.speed = 20f;

                }
                break;
            case 200:
                for (int i = 0; i < 20; i++)
                {
                    Vector2 playerDirection = (player.transform.position - transform.position).normalized;
                    float aimTowards = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg - 90f;
                    GameObject shotFired = Instantiate(bullet, this.transform.position, this.transform.rotation);
                    BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
                    shotBullet.angle = (aimTowards) + (18f * i);
                    shotBullet.speed = 20f;

                }
                break;
            case 300:
                pattern = Random.Range(0, 4);
                MovePoint();
                timer = 0;
                break;
        }
    }

    private void HomingWaves()
    {
        switch (timer)
        {
            case 50:
                for (int i = 0; i < 5; i++)
                {
                    GameObject shotFired = Instantiate(bullet2, this.transform.position, this.transform.rotation);
                    BulletE2 shotBullet = shotFired.GetComponent<BulletE2>();
                    shotBullet.angle = (90 - 20f) + (10f * i);
                    shotBullet.speed = 20f;
                    shotBullet.moveMode = 1;
                    shotBullet.shootMode = 4;

                }
                break;
            case 100:
                for (int i = 0; i < 5; i++)
                {
                    GameObject shotFired = Instantiate(bullet2, this.transform.position, this.transform.rotation);
                    BulletE2 shotBullet = shotFired.GetComponent<BulletE2>();
                    shotBullet.angle = (0 - 20f) + (10f * i);
                    shotBullet.speed = 20f;
                    shotBullet.moveMode = 1;
                    shotBullet.shootMode = 4;

                }
                break;
            case 150:
                for (int i = 0; i < 5; i++)
                {
                    GameObject shotFired = Instantiate(bullet2, this.transform.position, this.transform.rotation);
                    BulletE2 shotBullet = shotFired.GetComponent<BulletE2>();
                    shotBullet.angle = (270 - 20f) + (10f * i);
                    shotBullet.speed = 20f;
                    shotBullet.moveMode = 1;
                    shotBullet.shootMode = 4;

                }
                break;
            case 200:
                for (int i = 0; i < 5; i++)
                {
                    GameObject shotFired = Instantiate(bullet2, this.transform.position, this.transform.rotation);
                    BulletE2 shotBullet = shotFired.GetComponent<BulletE2>();
                    shotBullet.angle = (180 - 20f) + (10f * i);
                    shotBullet.speed = 20f;
                    shotBullet.moveMode = 1;
                    shotBullet.shootMode = 4;

                }
                break;
            case 300:
                pattern = Random.Range(0, 4);
                MovePoint();
                timer = 0;
                break;
        }
    }

    private void SideRain()
    {
        switch (timer)
        {
            case 50:
                for (int i = 0; i < 5; i++)
                {
                    GameObject shotFired = Instantiate(bullet, new Vector2(-5.5f, (-6) + (4 * i)), this.transform.rotation);
                    BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
                    shotBullet.angle = 270f;
                    shotBullet.speed = 20;
                }
                for (int i = 0; i < 5; i++)
                {
                    GameObject shotFired = Instantiate(bullet, new Vector2(5.5f, (-8) + (4 * i)), this.transform.rotation);
                    BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
                    shotBullet.angle = 90f;
                    shotBullet.speed = 20;
                }
                break;
            case 100:
                for (int i = 0; i < 5; i++)
                {
                    GameObject shotFired = Instantiate(bullet, new Vector2(-5.5f, (-6) + (4 * i)), this.transform.rotation);
                    BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
                    shotBullet.angle = 270f;
                    shotBullet.speed = 20;
                }
                for (int i = 0; i < 5; i++)
                {
                    GameObject shotFired = Instantiate(bullet, new Vector2(5.5f, (-8) + (4 * i)), this.transform.rotation);
                    BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
                    shotBullet.angle = 90f;
                    shotBullet.speed = 20;
                }
                break;
            case 150:
                for (int i = 0; i < 5; i++)
                {
                    GameObject shotFired = Instantiate(bullet, new Vector2(-5.5f, (-6) + (4 * i)), this.transform.rotation);
                    BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
                    shotBullet.angle = 270f;
                    shotBullet.speed = 20;
                }
                for (int i = 0; i < 5; i++)
                {
                    GameObject shotFired = Instantiate(bullet, new Vector2(5.5f, (-8) + (4 * i)), this.transform.rotation);
                    BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
                    shotBullet.angle = 90f;
                    shotBullet.speed = 20;
                }
                break;
            case 200:
                for (int i = 0; i < 5; i++)
                {
                    GameObject shotFired = Instantiate(bullet, new Vector2(-5.5f, (-6) + (4 * i)), this.transform.rotation);
                    BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
                    shotBullet.angle = 270f;
                    shotBullet.speed = 20;
                }
                for (int i = 0; i < 5; i++)
                {
                    GameObject shotFired = Instantiate(bullet, new Vector2(5.5f, (-8) + (4 * i)), this.transform.rotation);
                    BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
                    shotBullet.angle = 90f;
                    shotBullet.speed = 20;
                }
                break;
            case 250:
                for (int i = 0; i < 5; i++)
                {
                    GameObject shotFired = Instantiate(bullet, new Vector2(-5.5f, (-6) + (4 * i)), this.transform.rotation);
                    BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
                    shotBullet.angle = 270f;
                    shotBullet.speed = 20;
                }
                for (int i = 0; i < 5; i++)
                {
                    GameObject shotFired = Instantiate(bullet, new Vector2(5.5f, (-8) + (4 * i)), this.transform.rotation);
                    BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
                    shotBullet.angle = 90f;
                    shotBullet.speed = 20;
                }
                break;
            case 300:
                pattern = Random.Range(0, 4);
                MovePoint();
                timer = 0;
                break;
        }
    }

    public void GotHit(bool shotColor)
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject shotFired = Instantiate(bullet2, this.transform.position, this.transform.rotation);
            BulletE2 shotBullet = shotFired.GetComponent<BulletE2>();
            shotBullet.angle = Random.Range(0, 360);
            shotBullet.speed = 20f;
            shotBullet.moveMode = 2;
            shotBullet.shootMode = 2;

        }
        life -= 1;
    }

    private void IsAlive()
    {
        if (life < 1)
        {
            Destroy(gameObject);
        }
    }
}
