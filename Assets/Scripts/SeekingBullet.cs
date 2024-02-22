using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekingBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform tf;
    private SpriteRenderer m_SpriteRenderer;
    private int lifeSpan;
    public float speed;
    public bool kirin;
    public bool shotColor;
    public GameObject enemy;
    

    void Start()
    {
        lifeSpan = 200;
        tf = this.GetComponent<Transform>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");

    }

    void Update()
    {
        m_SpriteRenderer.color = Color.white;

        transform.position = Vector2.MoveTowards(this.transform.position, enemy.transform.position, speed * Time.deltaTime);

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
