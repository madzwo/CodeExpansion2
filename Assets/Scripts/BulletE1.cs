using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletE1 : MonoBehaviour
{
    public Rigidbody2D rb;
    private Transform tf;
    private SpriteRenderer m_SpriteRenderer;
    private int lifeSpan;
    public float speed;
    public float angle;

    // Start is called before the first frame update
    void Start()
    {
        lifeSpan = 1200;
        rb = this.GetComponent<Rigidbody2D>();
        //rb.AddForce(rb.transform.up * speed, ForceMode2D.Impulse);
        tf = this.GetComponent<Transform>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        rb.rotation = angle;
    }

    // Update is called once per frame
    void Update()
    {
        tf.Translate(Vector2.up * speed/200);
        CheckBounds();
        if (lifeSpan <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            lifeSpan -= 1;
        }
    }

    private void CheckBounds()
    {
        if (this.transform.position.x < -6 ||this.transform.position.x > 6)
        {
            Destroy(gameObject);
        }

        if (this.transform.position.y < -8 || this.transform.position.y > 11)
        {
            Destroy(gameObject);
        }
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
}
