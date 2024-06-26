using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] private int bg_speed = 10; // ��� ��ũ�� �ӵ�

    // Start is called before the first frame update
    void Start()
    {
        // �ƹ� ���۵� �������� ����
    }

    // Update is called once per frame
    void Update()
    {
        // ����� �Ʒ��� �̵���ŵ�ϴ�. �̵� �ӵ��� bg_speed�� ���� �����Ӻ��� ����� �ð��� ���� �����˴ϴ�.
        transform.Translate(Vector2.down * bg_speed * Time.deltaTime, Space.Self);

        // ����� y ��ġ�� -12.0���� ������ Ȯ���մϴ�. (ȭ�� �Ʒ��� ����� ����)
        if (transform.position.y < -7.0f)
        {
            // ����� ���� 24 ������ŭ ���� �̵����Ѽ� ȭ�� �Ʒ������� ��� �κ��� �����մϴ�.
            transform.position = transform.position + new Vector3(0f, 15.0f, 0f);
        }
    }
}
