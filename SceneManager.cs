using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    void Awake()
    {
        // ���ϴ� ȭ�� �ػ󵵸� �����մϴ�.
        int setWidth = 1200;
        int setHeight = 2400;
        // ȭ�� ������ ���� ���� �����մϴ�.
        Screen.orientation = ScreenOrientation.Portrait;
        // ���� ��ġ�� �ػ󵵸� �����ɴϴ�.
        int deviceW = Screen.width;
        int deviceH = Screen.height;

        // ���ϴ� �ػ󵵷� ȭ�� �ػ󵵸� �����մϴ�.
        Screen.SetResolution(setWidth, (int)((float)deviceH / deviceW * setWidth), true);

        // ������ �ػ��� ���� ���� ������ ��ġ �ػ��� ���� ���� �������� ���� ���
        if ((float)setWidth / setHeight < (float)deviceW / deviceH)
        {
            // ���ο� ���� ������ ����մϴ�.
            float newW = ((float)setWidth / setHeight) / ((float)deviceW / deviceH);
            // ī�޶� ����Ʈ�� �缳���Ͽ� ���ο� ���� ������ �����մϴ�.
            Camera.main.rect = new Rect((1f - newW) / 2f, 0f, newW, 1f);
        }
        else
        {
            // ������ �ػ��� ���� ���� ������ ��ġ �ػ��� ���� ���� �������� ū ���
            // ���ο� ���� ������ ����մϴ�.
            float newH = ((float)setWidth / setHeight) / ((float)deviceW / deviceH);
            // ī�޶� ����Ʈ�� �缳���Ͽ� ���ο� ���� ������ �����մϴ�.
            Camera.main.rect = new Rect(0f, (1f - newH) / 2f, 1f, newH);
        }
    }
}
