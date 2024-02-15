using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWing : MonoBehaviour
{
    public bool myColor;
    private SpriteRenderer m_SpriteRenderer;
    private int fireCount;
    public GameObject bullet2;
    public Boss2 boss2;
    public GameObject explode;

    // Start is called before the first frame update
    void Start()
    {
        boss2 = this.GetComponentInParent<Boss2>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

            m_SpriteRenderer.color = Color.black;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GotHit(bool shotColor)
    {
        if (myColor == !shotColor)
        {
            GameObject shotFired = Instantiate(bullet2, this.transform.position, this.transform.rotation);
            BulletE2 shotBullet = shotFired.GetComponent<BulletE2>();
            shotBullet.angle = Random.Range(0, 360);
            shotBullet.speed = 20f;
            shotBullet.moveMode = 2;
            shotBullet.shootMode = 2;
        }
        else
        {
            Instantiate(explode, this.transform.position, this.transform.rotation);
            Debug.Log("cluck");
        }
        boss2.WingHit();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
}
