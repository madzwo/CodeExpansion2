using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuffStar : MonoBehaviour
{
    float speed = 15f;
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
    private ParticleSystem ps;
    private int hurtTime;
    private GameManager gm;
    public CircleCollider2D hitBox;

    // adding a firerate
    public float fireRate;
    public float timeTillFire;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        ballRender = this.GetComponentInChildren<SpriteRenderer>();
        ps = this.GetComponent<ParticleSystem>();
        hurtTime = 300;
        gm = GameManager.instance;
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = ballRender.bounds.extents.x; //extents = size of width / 2
        objectHeight = ballRender.bounds.extents.y; //extents = size of height / 2

        timeTillFire = fireRate;
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
        BallColor();
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
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            transform.Translate(Vector2.up);
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            transform.Translate(Vector2.down);
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            transform.Translate(Vector2.left);
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            transform.Translate(Vector2.right);
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
        transform.position = Vector2.Lerp(transform.position, mousePosition, speed * Time.deltaTime);
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

    private void BallColor()
    {
        if (shotColor)
        {
            ballRender.color = Color.white;
        }
        else
        {
            ballRender.color = Color.black;
        }
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
            hurtTime = 300;
            gm.PlayerHit();
        }
        
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
    }
}
