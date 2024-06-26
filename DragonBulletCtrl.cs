using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBulletCtrl : MonoBehaviour
{
    [SerializeField] private int b_speed = 10; // 총알의 이동 속도
    public int dmg ;

    // Update is called once per frame
    void Update()
    {
        // 총알을 위로 이동시킵니다. 이동 속도는 b_speed와 이전 프레임부터 경과한 시간에 따라 결정됩니다.
        transform.Translate(Vector2.up * b_speed * Time.deltaTime, Space.Self);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BulletBorder")
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    public void ChangeAppearance(int buttonIndex)
    {
        // 총알 모양 변경 로직 추가
        // 예: SpriteRenderer를 사용하여 스프라이트 변경
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = GetBulletSprite(buttonIndex);

        Debug.Log("Dragon bullet appearance changed to index: " + buttonIndex);
    }

    private Sprite GetBulletSprite(int buttonIndex)
    {
        // 인덱스에 따른 총알 스프라이트 반환 로직 추가
        // 예제: 스프라이트 배열에서 해당 인덱스의 스프라이트 반환
        Sprite[] bulletSprites = new Sprite[] { /* 스프라이트 배열 */ };
        return bulletSprites[buttonIndex];
    }
}
