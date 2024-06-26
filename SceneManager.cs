using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    void Awake()
    {
        // 원하는 화면 해상도를 설정합니다.
        int setWidth = 1200;
        int setHeight = 2400;
        // 화면 방향을 세로 모드로 설정합니다.
        Screen.orientation = ScreenOrientation.Portrait;
        // 현재 장치의 해상도를 가져옵니다.
        int deviceW = Screen.width;
        int deviceH = Screen.height;

        // 원하는 해상도로 화면 해상도를 설정합니다.
        Screen.SetResolution(setWidth, (int)((float)deviceH / deviceW * setWidth), true);

        // 설정한 해상도의 가로 세로 비율이 장치 해상도의 가로 세로 비율보다 작은 경우
        if ((float)setWidth / setHeight < (float)deviceW / deviceH)
        {
            // 새로운 가로 비율을 계산합니다.
            float newW = ((float)setWidth / setHeight) / ((float)deviceW / deviceH);
            // 카메라 뷰포트를 재설정하여 새로운 가로 비율을 적용합니다.
            Camera.main.rect = new Rect((1f - newW) / 2f, 0f, newW, 1f);
        }
        else
        {
            // 설정한 해상도의 가로 세로 비율이 장치 해상도의 가로 세로 비율보다 큰 경우
            // 새로운 세로 비율을 계산합니다.
            float newH = ((float)setWidth / setHeight) / ((float)deviceW / deviceH);
            // 카메라 뷰포트를 재설정하여 새로운 세로 비율을 적용합니다.
            Camera.main.rect = new Rect(0f, (1f - newH) / 2f, 1f, newH);
        }
    }
}
