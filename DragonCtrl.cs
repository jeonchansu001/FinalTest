using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonCtrl : MonoBehaviour
{


    public Sprite[] appearances; // 플레이어의 다양한 모습 스프라이트 배열
    private SpriteRenderer spriteRenderer;
    public GameObject Basicbullet;
    public float fireRate = 0.25f;   // Bullet firing interval
    private float nextFireTime = 0f;

    public GameManager manager; // 수정된 부분
    public int life;
    public int score;

    public bool isHit;

    private Animator animator;

    public int level = 1; // Player's bullet level
    public int maxlevel = 10;

    public bool isTouchTop;
    public bool isTouchBottom;
    public bool isTouchRight;
    public bool isTouchLeft;

    public Transform firePos;
    public float moveSpeed = 5f; // Character movement speed
    /*
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        HandleMovement();
        HandleFiring();
    }
    */

    void HandleMovement()
    {
#if UNITY_EDITOR // Runs only in the Unity Editor
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // Set Z-axis value to 0 for 2D game
            transform.position = Vector3.Lerp(transform.position, mousePosition, moveSpeed * Time.deltaTime);
        }
#else // Runs on mobile devices
if (Input.touchCount > 0)
{
Touch touch = Input.GetTouch(0);
Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
touchPosition.z = 0; // Set Z-axis value to 0 for 2D game
transform.position = Vector3.Lerp(transform.position, touchPosition, moveSpeed * Time.deltaTime);
}
#endif
    }


    void HandleFiring()
    {
        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Fire();
        }
    }

    void Fire()
    {
        Instantiate(Basicbullet, firePos.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.CompareTag("Item"))
        {
            IncreaseLevel();
            Destroy(collision.gameObject); // 아이템 제거
        }
        */
        if (collision.gameObject.tag == "Border")
        {
            Debug.Log("Entered border: " + collision.gameObject.name);
            switch (collision.gameObject.name)
            {
                case "TopBoder":
                    isTouchTop = true;
                    break;
                case "BottomBoder":
                    isTouchBottom = true;
                    break;
                case "RightBoder":
                    isTouchRight = true;
                    break;
                case "LeftBoder":
                    isTouchLeft = true;
                    break;
            }
        }
        else if (collision.gameObject.tag == "Demon" || collision.gameObject.tag == "DemonBullet")
        {
            if (isHit)
                return;

            isHit = true;
            life--;

            if (life == 0)
            {
                manager.gameOver(); // 수정된 부분
            }

            gameObject.SetActive(false);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Item")
        {
            Item item = collision.gameObject.GetComponent<Item>();
            Destroy(collision.gameObject);
        }
    }

   /* void IncreaseLevel()
    {
        level++;
        if (level == 5)
        {
            GameManager.instance.PauseGame(); // 레벨 5에 도달하면 게임 일시정지 및 버튼 표시
        }
    }*/

    public void ChangeAppearance(int buttonIndex)
    {
        // 애니메이션 또는 외관 변경 로직 추가
        // 예: Animator를 사용하여 애니메이션 상태 변경
        Animator animator = GetComponent<Animator>();
        animator.SetInteger("AppearanceIndex", buttonIndex);

        Debug.Log("Dragon appearance changed to index: " + buttonIndex);
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            Debug.Log("Exited border: " + collision.gameObject.name);
            switch (collision.gameObject.name)
            {
                case "TopBoder":
                    isTouchTop = false;
                    break;
                case "BottomBoder":
                    isTouchBottom = false;
                    break;
                case "RightBoder":
                    isTouchRight = false;
                    break;
                case "LeftBoder":
                    isTouchLeft = false;
                    break;
            }
        }
    }
}