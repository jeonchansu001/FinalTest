using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBulletCtrl : MonoBehaviour
{
    [SerializeField] private int b_speed = 10; // �Ѿ��� �̵� �ӵ�
    public int dmg ;

    // Update is called once per frame
    void Update()
    {
        // �Ѿ��� ���� �̵���ŵ�ϴ�. �̵� �ӵ��� b_speed�� ���� �����Ӻ��� ����� �ð��� ���� �����˴ϴ�.
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
        // �Ѿ� ��� ���� ���� �߰�
        // ��: SpriteRenderer�� ����Ͽ� ��������Ʈ ����
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = GetBulletSprite(buttonIndex);

        Debug.Log("Dragon bullet appearance changed to index: " + buttonIndex);
    }

    private Sprite GetBulletSprite(int buttonIndex)
    {
        // �ε����� ���� �Ѿ� ��������Ʈ ��ȯ ���� �߰�
        // ����: ��������Ʈ �迭���� �ش� �ε����� ��������Ʈ ��ȯ
        Sprite[] bulletSprites = new Sprite[] { /* ��������Ʈ �迭 */ };
        return bulletSprites[buttonIndex];
    }
}
