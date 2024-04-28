using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2: MonoBehaviour
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
    private bool movePhase;
    private int life;
    private int pattern;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        tf = this.GetComponent<Transform>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        
            m_SpriteRenderer.color = Color.black;
        
        player = GameObject.FindGameObjectWithTag("Player");
        timer = 0;
        movePhase = Random.value > 0.5f;
        life = 25;
        pattern = Random.Range(0, 4);
    }

    void Update()
    {
        switch (pattern)
        {
            case 0:
                // CornerSpread();
                break;
            case 1:
                Eruption();
                break;
            case 2:
                // BounceWaves();
                break;
            case 3:
                // TopRain();
                break;
        }
        timer += 1;
        IsAlive();
    }

    private void CornerSpread()
    {
        switch (timer)
        {
            //changed where the boss moves
            case 50:
                transform.position = new Vector2(-3, 7);
                break;
            case 100:
                for (int i = 0; i < 5; i++)
                {
                    Vector2 playerDirection = (player.transform.position - transform.position).normalized;
                    float aimTowards = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg - 90f;
                    GameObject shotFired = Instantiate(bullet2, this.transform.position, this.transform.rotation);
                    BulletE2 shotBullet = shotFired.GetComponent<BulletE2>();
                    shotBullet.angle = (aimTowards - 20f) + (10f * i);
                    shotBullet.speed = 20f;
                    shotBullet.moveMode = 1;
                    shotBullet.shootMode = 2;

                }
                break;
            case 150:
                transform.position = new Vector2(3, 7);
                break;
            case 200:
                for (int i = 0; i < 5; i++)
                {
                    Vector2 playerDirection = (player.transform.position - transform.position).normalized;
                    float aimTowards = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg - 90f;
                    GameObject shotFired = Instantiate(bullet2, this.transform.position, this.transform.rotation);
                    BulletE2 shotBullet = shotFired.GetComponent<BulletE2>();
                    shotBullet.angle = (aimTowards - 20f) + (10f * i);
                    shotBullet.speed = 20f;
                    shotBullet.moveMode = 1;
                    shotBullet.shootMode = 2;
                }
                break;
            case 250:
                transform.position = new Vector2(0, 7);
                break;
            case 300:
                pattern = Random.Range(0, 4);
                timer = 0;
                break;
        }
    }

    private void Eruption()
    {
        switch (timer)
        {
            case 50:
                GameObject shotFired = Instantiate(bullet2, new Vector2(player.transform.position.x, -7), this.transform.rotation);
                BulletE2 shotBullet = shotFired.GetComponent<BulletE2>();
                shotBullet.angle = 180f;
                shotBullet.speed = 20;
                shotBullet.moveMode = 3;
                shotBullet.shootMode = 6;
                break;
            case 100:
                shotFired = Instantiate(bullet2, new Vector2(player.transform.position.x, -7), this.transform.rotation);
                shotBullet = shotFired.GetComponent<BulletE2>();
                shotBullet.angle = 180f;
                shotBullet.speed = 20;
                shotBullet.moveMode = 3;
                shotBullet.shootMode = 6;
                break;
            case 125:
                shotFired = Instantiate(bullet2, new Vector2(player.transform.position.x, -7), this.transform.rotation);
                shotBullet = shotFired.GetComponent<BulletE2>();
                shotBullet.angle = 180f;
                shotBullet.speed = 20;
                shotBullet.moveMode = 3;
                shotBullet.shootMode = 6;
                break;
            case 150:
                shotFired = Instantiate(bullet2, new Vector2(player.transform.position.x, -7), this.transform.rotation);
                shotBullet = shotFired.GetComponent<BulletE2>();
                shotBullet.angle = 180f;
                shotBullet.speed = 20;
                shotBullet.moveMode = 3;
                shotBullet.shootMode = 6;
                break;
            case 175:
                shotFired = Instantiate(bullet2, new Vector2(player.transform.position.x, -7), this.transform.rotation);
                shotBullet = shotFired.GetComponent<BulletE2>();
                shotBullet.angle = 180f;
                shotBullet.speed = 20;
                shotBullet.moveMode = 3;
                shotBullet.shootMode = 6;
                break;
            case 200:
                shotFired = Instantiate(bullet2, new Vector2(player.transform.position.x, -7), this.transform.rotation);
                shotBullet = shotFired.GetComponent<BulletE2>();
                shotBullet.angle = 180f;
                shotBullet.speed = 20;
                shotBullet.moveMode = 3;
                shotBullet.shootMode = 6;
                break;
            case 210:
                shotFired = Instantiate(bullet2, new Vector2(player.transform.position.x, -7), this.transform.rotation);
                shotBullet = shotFired.GetComponent<BulletE2>();
                shotBullet.angle = 180f;
                shotBullet.speed = 20;
                shotBullet.moveMode = 3;
                shotBullet.shootMode = 6;
                break;
            case 220:
                shotFired = Instantiate(bullet2, new Vector2(player.transform.position.x, -7), this.transform.rotation);
                shotBullet = shotFired.GetComponent<BulletE2>();
                shotBullet.angle = 180f;
                shotBullet.speed = 20;
                shotBullet.moveMode = 3;
                shotBullet.shootMode = 6;
                break;
            case 230:
                shotFired = Instantiate(bullet2, new Vector2(player.transform.position.x, -7), this.transform.rotation);
                shotBullet = shotFired.GetComponent<BulletE2>();
                shotBullet.angle = 180f;
                shotBullet.speed = 20;
                shotBullet.moveMode = 3;
                shotBullet.shootMode = 6;
                break;
            case 240:
                shotFired = Instantiate(bullet2, new Vector2(player.transform.position.x, -7), this.transform.rotation);
                shotBullet = shotFired.GetComponent<BulletE2>();
                shotBullet.angle = 180f;
                shotBullet.speed = 20;
                shotBullet.moveMode = 3;
                shotBullet.shootMode = 6;
                break;
            case 250:
                shotFired = Instantiate(bullet2, new Vector2(player.transform.position.x, -7), this.transform.rotation);
                shotBullet = shotFired.GetComponent<BulletE2>();
                shotBullet.angle = 180f;
                shotBullet.speed = 20;
                shotBullet.moveMode = 3;
                shotBullet.shootMode = 6;
                break;
            case 300:
                pattern = Random.Range(0, 4);
                timer = 0;
                break;
        }
    }

    private void BounceWaves()
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
                    shotBullet.shootMode = 5;

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
                    shotBullet.shootMode = 5;

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
                    shotBullet.shootMode = 5;

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
                    shotBullet.shootMode = 5;

                }
                break;
            case 300:
                pattern = Random.Range(0, 4);
                timer = 0;
                break;
        }
    }

    private void TopRain()
    {
        switch (timer)
        {
            case 50:
                for (int i = 0; i < 6; i++)
                {
                    GameObject shotFired = Instantiate(bullet, new Vector2((-5)+(2*i), 8), this.transform.rotation);
                    BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
                    shotBullet.angle = 180f;
                    shotBullet.speed = 20;
                }
                break;
            case 100:
                for (int i = 0; i < 6; i++)
                {
                    GameObject shotFired = Instantiate(bullet, new Vector2((-5) + (2 * i), 8), this.transform.rotation);
                    BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
                    shotBullet.angle = 180f;
                    shotBullet.speed = 20;
                }
                break;
            case 150:
                for (int i = 0; i < 6; i++)
                {
                    GameObject shotFired = Instantiate(bullet, new Vector2((-5) + (2 * i), 8), this.transform.rotation);
                    BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
                    shotBullet.angle = 180f;
                    shotBullet.speed = 20;
                }
                break;
            case 200:
                for (int i = 0; i < 6; i++)
                {
                    GameObject shotFired = Instantiate(bullet, new Vector2((-5) + (2 * i), 8), this.transform.rotation);
                    BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
                    shotBullet.angle = 180f;
                    shotBullet.speed = 20;
                }
                break;
            case 250:
                for (int i = 0; i < 6; i++)
                {
                    GameObject shotFired = Instantiate(bullet, new Vector2((-5) + (2 * i), 8), this.transform.rotation);
                    BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
                    shotBullet.angle = 180f;
                    shotBullet.speed = 20;
                }
                break;
            case 300:
                pattern = Random.Range(0, 4);
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

    public void WingHit()
    {
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
