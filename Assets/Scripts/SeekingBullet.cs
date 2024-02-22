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
    GameObject enemy;
    GameObject boss1;
    GameObject boss2;
    GameObject boss3;


    

    void Start()
    {
        lifeSpan = 100;
        tf = this.GetComponent<Transform>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        boss1 = GameObject.FindGameObjectWithTag("Boss1");
        boss2 = GameObject.FindGameObjectWithTag("Boss2");
        boss3 = GameObject.FindGameObjectWithTag("Boss3");




    }

    void Update()
    {
        // bullet will follow bosses too, if there are no enemies or bosses it will destroy itself
        m_SpriteRenderer.color = Color.white;
        if (enemy != null)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, enemy.transform.position, speed * Time.deltaTime);
        }
        else if (boss1 != null)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, boss1.transform.position, speed * Time.deltaTime);
        }
        else if (boss2 != null)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, boss2.transform.position, speed * Time.deltaTime);
        }
        else if (boss3 != null)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, boss3.transform.position, speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
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
