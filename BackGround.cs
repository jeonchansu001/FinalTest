using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] private int bg_speed = 10; // 배경 스크롤 속도

    // Start is called before the first frame update
    void Start()
    {
        // 아무 동작도 수행하지 않음
    }

    // Update is called once per frame
    void Update()
    {
        // 배경을 아래로 이동시킵니다. 이동 속도는 bg_speed와 이전 프레임부터 경과한 시간에 따라 결정됩니다.
        transform.Translate(Vector2.down * bg_speed * Time.deltaTime, Space.Self);

        // 배경의 y 위치가 -12.0보다 작은지 확인합니다. (화면 아래로 벗어나는 지점)
        if (transform.position.y < -7.0f)
        {
            // 배경을 위로 24 단위만큼 순간 이동시켜서 화면 아래쪽으로 벗어난 부분을 보충합니다.
            transform.position = transform.position + new Vector3(0f, 15.0f, 0f);
        }
    }
}
