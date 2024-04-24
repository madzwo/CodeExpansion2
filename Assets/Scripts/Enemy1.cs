using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    private bool myColor;
    private SpriteRenderer m_SpriteRenderer;
    private int fireCount;
    public GameObject bullet;
    private Rigidbody2D rb;
    private Transform tf;
    private GameObject player;
    public int moveMode;
    public int shootMode;
    private int timer;
    public GameObject explode;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        tf = this.GetComponent<Transform>();
        fireCount = Random.Range(10,100);
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    
        //getting rid of the black white thing not sure what they were going for/how to expand
            m_SpriteRenderer.color = Color.black;

        player = GameObject.FindGameObjectWithTag("Player");
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer +=1;
        switch (moveMode)
        {
            case 0:
                break;
            case 1:
                BasicMove();
                break;
            case 2:
                DownUpMove();
                break;
            case 3:
                SlipMoveL();
                break;
            case 4:
                SlipMoveR();
                break;
        }
        switch (shootMode)
        {
            case 0:
                break;
            case 1:
                DownFire();
                break;
            case 2:
                AimFire();
                break;
            case 3:
                DownSpread();
                break;
            case 4:
                AimSpread();
                break;
        }
        CheckBounds();
    }

    private void BasicMove()
    {
        tf.Translate(Vector2.down * 0.04f);
    }

    private void DownUpMove()
    {
       if (timer < 150 && timer < 550)
        {
            tf.Translate(Vector2.down * 0.04f);
        }
       if (timer > 150 && timer > 550)
        {
            tf.Translate(Vector2.up * 0.04f);
        }
    }

    private void SlipMoveR()
    {
        if (timer < 150 || timer > 400)
        {
            tf.Translate(Vector2.down * 0.04f);
        }
        if (timer > 150 && timer < 400)
        {
            tf.Translate((Vector2.down * 0.01f) + Vector2.right * 0.02f);
        }
    }
    private void SlipMoveL()
    {
        if (timer < 150 || timer > 400)
        {
            tf.Translate(Vector2.down * 0.04f);
        }
        if (timer > 150 && timer < 400)
        {
            tf.Translate((Vector2.down * 0.01f) + Vector2.left * 0.02f);
        }
    }

    private void DownFire()
    {
        if (fireCount > 0)
        {
            fireCount -= 1;
        }
        else
        {
            fireCount = 300;
            GameObject shotFired = Instantiate(bullet, this.transform.position, this.transform.rotation);
            BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
            shotBullet.angle = 180f;
            shotBullet.speed = 20;
        }
    }

    private void AimFire()
    {
        if (fireCount > 0)
        {
            fireCount -= 1;
        }
        else
        {
            fireCount = 300;
            Vector2 playerDirection = (player.transform.position - transform.position).normalized;
            float aimTowards = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg - 90f;
            GameObject shotFired = Instantiate(bullet, this.transform.position, this.transform.rotation);
            BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
            shotBullet.angle = aimTowards;
            shotBullet.speed = 20;
        }
    }

    private void DownSpread()
    {
        if (fireCount > 0)
        {
            fireCount -= 1;
        }
        else
        {
            fireCount = 300;
            for (int i = 0; i < 5; i++)
            {
                GameObject shotFired = Instantiate(bullet, this.transform.position, this.transform.rotation);
                BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
                shotBullet.angle = 160f + (10f * i);
                shotBullet.speed = 20;
            }
        }
    }
    private void AimSpread()
    {
        if (fireCount > 0)
        {
            fireCount -= 1;
        }
        else
        {
            fireCount = 300;
            for (int i = 0; i < 5; i++)
            {
                Vector2 playerDirection = (player.transform.position - transform.position).normalized;
                float aimTowards = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg - 90f;
                GameObject shotFired = Instantiate(bullet, this.transform.position, this.transform.rotation);
                BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
                shotBullet.angle = (aimTowards - 20f) + (10f * i);
                shotBullet.speed = 20;
            }
        }
    }

    private void CheckBounds()
    {
        if (this.transform.position.x < -6 || this.transform.position.x > 6)
        {
            Destroy(gameObject);
        }

        if (this.transform.position.y < -8 || this.transform.position.y > 11)
        {
            Destroy(gameObject);
        }
    }

    public void GotHit(bool shotColor)
    {
        if (myColor == shotColor)
        {
            Instantiate(explode, this.transform.position, this.transform.rotation);
            Destroy(gameObject);
        }
        else
        {
            fireCount = 0;
            switch (shootMode)
            {
                case 0:
                    DownFire();
                    break;
                case 1:
                    AimFire();
                    break;
                case 2:
                    DownSpread();
                    break;
                case 3:
                    AimSpread();
                    break;
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Explode":
                Destroy(gameObject);
                // randomly spawn powerups
                break;
        }
    }
}
