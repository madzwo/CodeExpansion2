using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletE2 : MonoBehaviour
{
    public Rigidbody2D rb;
    private Transform tf;
    public GameObject bullet;
    private SpriteRenderer m_SpriteRenderer;
    private int lifeSpan;
    public float speed;
    public float angle;
    public int moveMode;
    public int shootMode;
    private GameObject player;
    private int timer;

    // Start is called before the first frame update
    void Start()
    {
        lifeSpan = 1200;
        rb = this.GetComponent<Rigidbody2D>();
        tf = this.GetComponent<Transform>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        rb.rotation = angle;
        player = GameObject.FindGameObjectWithTag("Player");
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeSpan <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            lifeSpan -= 1;
        }
        switch (moveMode)
        {
            case 0:
                break;
            case 1:
                BasicMove();
                break;
            case 2:
                StopMove();
                break;
            case 3:
                HoldMove();
                break;
        }
        timer += 1;
    }

    private void PartingShot()
    {
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
            case 5:
                BounceShot();
                break;
            case 6:
                UpFire();
                break;
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                collision.gameObject.GetComponent<PuffStar>().GotHit();
                Destroy(gameObject);
                break;
        }
    }

    private void BasicMove()
    {
        tf.Translate(Vector2.up * speed/200);
        if (transform.position.x < -5 || transform.position.x > 5)
        {
            PartingShot();
        }
        if (transform.position.y < -8 || transform.position.y > 9)
        {
            PartingShot();
        }
    }

    private void StopMove()
    {
        if (timer < 50 && timer < 100)
        {
            tf.Translate(Vector2.down * speed/200);
        }
        if (timer > 250)
        {
            PartingShot();
        }
    }

    private void HoldMove()
    {
        if (timer > 300)
        {
            PartingShot();
        }
    }

    private void DownFire()
    {
        GameObject shotFired = Instantiate(bullet, this.transform.position, this.transform.rotation);
        BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
        shotBullet.angle = 180f;
        shotBullet.speed = speed;
    }
    private void UpFire()
    {
        GameObject shotFired = Instantiate(bullet, this.transform.position, this.transform.rotation);
        BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
        shotBullet.angle = 0;
        shotBullet.speed = speed;
    }

    private void AimFire()
    {
        Vector2 playerDirection = (player.transform.position - transform.position).normalized;
        float aimTowards = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg - 90f;
        GameObject shotFired = Instantiate(bullet, this.transform.position, this.transform.rotation);
        BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
        shotBullet.angle = aimTowards;
        shotBullet.speed = speed;
    }

    private void DownSpread()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject shotFired = Instantiate(bullet, this.transform.position, this.transform.rotation);
            BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
            shotBullet.angle = 160f + (10f * i);
            shotBullet.speed = speed;
        }
    }
    private void AimSpread()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector2 playerDirection = (player.transform.position - transform.position).normalized;
            float aimTowards = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg - 90f;
            GameObject shotFired = Instantiate(bullet, this.transform.position, this.transform.rotation);
            BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
            shotBullet.angle = (aimTowards - 20f) + (10f * i);
            shotBullet.speed = speed;
        }
    }
    private void BounceShot()
    {
        GameObject shotFired = Instantiate(bullet, this.transform.position, this.transform.rotation);
        BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
        if (transform.position.x < -5 || transform.position.x > 5)
        {
            shotBullet.angle = -(this.angle);
        }
        if (transform.position.y < -8 || transform.position.y > 9)
        {
            shotBullet.angle = -(this.angle)+180;
        }
        shotBullet.speed = speed;
    }
}
