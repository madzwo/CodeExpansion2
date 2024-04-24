using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuffStar : MonoBehaviour
{
    private bool isDragging = false;
    private bool isAim = false;
    private Vector2 mousePosition;
    private Rigidbody2D rb;
    public Camera MainCamera;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    private Vector2 aimDirection;
    private float aimAngle;
    bool shotColor = false;
    public GameObject bullet;
    private Transform firePoint;
    private SpriteRenderer ballRender;
    public GameObject explode;
    public GameObject seekingExplode;

    private ParticleSystem ps;
    private int hurtTime;
    // hurtTime above changes and goes down to 1
    // new variable is the length of the particle effect
    private int hurtDuration;
    private GameManager gm;
    public CircleCollider2D hitBox;

    // changed variable name so I can make smooth movement
    float dragToMoveSpeed = 10f;
    public float speed;

    // added a firerate
    public float fireRate;
    public float timeTillFire;

    //added seeking bullets
    public GameObject seekingBullet;
    public float seekingBulletFireRate;
    public float seekingBulletCooldown;


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        ballRender = this.GetComponentInChildren<SpriteRenderer>();
        ps = this.GetComponent<ParticleSystem>();
        hurtDuration = 50;
        hurtTime = hurtDuration;
        gm = GameManager.instance;
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = ballRender.bounds.extents.x; //extents = size of width / 2
        objectHeight = ballRender.bounds.extents.y; //extents = size of height / 2

        timeTillFire = fireRate;
        seekingBulletCooldown = seekingBulletFireRate; 
    }

    // Update is called once per frame
    void Update()
    {
        LookAtMouse();
        AimAtMouse();
        KeyControls();
        if (isDragging)
        {
            DragToMove();
        }
        AimToShoot();
        ShootSeekingBullet();
        Hurting();
    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, (screenBounds.y  - 1.75f) * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;
    }

    private void KeyControls()
    {
        //implimented smooth movement

        Vector3 position = transform.position;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    private void LookAtMouse()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private void AimAtMouse()
    {
        aimDirection = mousePosition - rb.position;
        aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

    private void DragToMove()
    {
        transform.position = Vector2.Lerp(transform.position, mousePosition, dragToMoveSpeed * Time.deltaTime);
    }

    public void OnMouseDrag()
    {
        isDragging = true;
        isAim = false;
    }
    public void OnMouseUp()
    {
        isDragging = false;
    }

    private void AimToShoot()
    {
        if (Input.GetMouseButtonDown(0) && !isDragging && !isAim)
        {
            isAim = true;
        }
        if (Input.GetMouseButtonUp(0) && !isDragging && isAim)
        {
            if(timeTillFire <= 0)
            {
                timeTillFire = fireRate;
                firePoint = this.transform;
                GameObject shotFired = Instantiate(bullet, firePoint.position, firePoint.rotation);
                BulletP shotBullet = shotFired.GetComponent<BulletP>();
                shotBullet.speed = 20;
                shotBullet.shotColor = shotColor;
                //get rid of alternating colors
                // shotColor = !shotColor;
                isAim = false;
                if (this.name == "Kirin")
                {
                    shotBullet.kirin = true;
                }
            }
        }
        timeTillFire -= 0.1f;
    }

    // added seeking bullet
    private void ShootSeekingBullet()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isDragging)
        {
            if (seekingBulletCooldown <= 0)
            {
                firePoint = this.transform;
                GameObject shotFired = Instantiate(seekingBullet, firePoint.position, firePoint.rotation);
                seekingBulletCooldown = seekingBulletFireRate; 

            }
        }
        seekingBulletCooldown -= 0.1f;
    }

    private void Hurting()
    {
        if (hurtTime > 0)
        {
            ps.Play();
            hurtTime -= 1;
        }
        else
        {
            ps.Clear();
            ps.Pause();
        }
    }
    public void GotHit()
    {
        if (hurtTime < 1)
        {
            hurtTime = hurtDuration;
        }
        gm.PlayerHit();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D col = collision.gameObject.GetComponent<Collider2D>();
        if (hitBox.IsTouching(col))
        {
            switch (collision.gameObject.tag)
            {
                case "Enemy":
                    GotHit();
                    break;
                case "Boss1":
                    GotHit();
                    break;
                case "Boss2":
                    GotHit();
                    break;
                case "Boss3":
                    GotHit();
                    break;
                case "BossWings":
                    GotHit();
                    break;
            }
        }

        if (collision.tag == "Border")
        {
            speed *= 0.2f;
        }
        if (collision.tag == "SlowZoneOne")
        {
            speed *= 0.9f;
        }
        if (collision.tag == "SlowZoneTwo")
        {
            speed *= 0.8f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            speed *= 5.0f;
        }
        if (collision.tag == "SlowZoneOne")
        {
            speed *= 1.1111f;
        }
        if (collision.tag == "SlowZoneTwo")
        {
            speed *= 1.25f;
        }
    }

 

}
