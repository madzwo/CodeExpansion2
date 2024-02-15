using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    private bool myColor;
    private SpriteRenderer m_SpriteRenderer;
    private int fireCount;
    public GameObject bullet;
    public GameObject bullet2;
    private Rigidbody2D rb;
    private Transform tf;
    private GameObject player;
    private int timer;
    public GameObject explode;
    private bool movePhase;
    private int life;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        tf = this.GetComponent<Transform>();
        myColor = Random.value > 0.5f;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        
            m_SpriteRenderer.color = Color.black;
            
        player = GameObject.FindGameObjectWithTag("Player");
        fireCount = 0;
        timer = 0;
        movePhase = Random.value > 0.5f;
        life = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0 && timer < 75)
        {
            tf.Translate(Vector2.right * 0.08f);
            DownFire();
        }
        if (timer > 75 && timer < 225)
        {
            tf.Translate(Vector2.left * 0.08f);
            DownFire();
        }
        if (timer > 225 && timer < 300)
        {
            tf.Translate(Vector2.right * 0.08f);
            DownFire();
        }
        if (timer > 315)
        {
            timer = 0;
            fireCount = 0;
        }
        timer += 1;
        IsAlive();
    }

    private void DownFire()
    {
        if (fireCount > 0)
        {
            fireCount -= 1;
        }
        else
        {
            fireCount = 20;
            GameObject shotFired = Instantiate(bullet, this.transform.position, this.transform.rotation);
            BulletE1 shotBullet = shotFired.GetComponent<BulletE1>();
            shotBullet.angle = 180f;
            shotBullet.speed = 20;
        }
    }

    public void GotHit(bool shotColor)
    {
        if (myColor == shotColor)
        {
            Instantiate(explode, this.transform.position, this.transform.rotation);
            Debug.Log("ouch");
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject shotFired = Instantiate(bullet2, this.transform.position, this.transform.rotation);
                BulletE2 shotBullet = shotFired.GetComponent<BulletE2>();
                shotBullet.angle = (180 - 60f) + (30f * i);
                shotBullet.speed = 4.2f;
                shotBullet.moveMode = 2;
                shotBullet.shootMode = 1;

            }
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
