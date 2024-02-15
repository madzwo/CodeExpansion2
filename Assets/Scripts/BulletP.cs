using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletP : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform tf;
    private SpriteRenderer m_SpriteRenderer;
    private int lifeSpan;
    public float speed;
    public bool shotColor;
    public bool kirin;
    

    // Start is called before the first frame update
    void Start()
    {
        lifeSpan = 600;
        //rb = this.GetComponent<Rigidbody2D>();
        //rb.AddForce(rb.transform.up * speed, ForceMode2D.Impulse);
        tf = this.GetComponent<Transform>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        tf.Translate(Vector2.up * speed/100);

            m_SpriteRenderer.color = Color.white;
       

        if (lifeSpan <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            lifeSpan -= 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                collision.gameObject.GetComponent<Enemy1>().GotHit(shotColor);
                if (kirin)
                    break;
                Destroy(gameObject);
                break;
            case "Boss1":
                collision.gameObject.GetComponent<Boss1>().GotHit(shotColor);
                Destroy(gameObject);
                if (kirin)
                    break;
                break;
            case "Boss2":
                collision.gameObject.GetComponent<Boss2>().GotHit(shotColor); 
                if (kirin)
                    break;
                Destroy(gameObject);
                break;
            case "BossPart":
                collision.gameObject.GetComponent<BossWing>().GotHit(shotColor);
                if (kirin)
                    break;
                Destroy(gameObject);
                break;
            case "Boss3":
                collision.gameObject.GetComponent<Boss3>().GotHit(shotColor);
                if (kirin)
                    break;
                Destroy(gameObject);
                break;
        }

    }
}
