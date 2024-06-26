using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject buttonPanel; // 버튼 패널
    public Button[] buttons; // UI 버튼 배열
    public DragonCtrl dragonCtrl; // 드래곤 컨트롤러 참조
    public DragonBulletCtrl dragonBullet;
    private int selectedButtonIndex;
    public GameObject[] enemyObjs;
    public Transform[] spawnPoints;
    public GameObject gameOverSet;
    public float maxSpawnDelay;
    private int score;
    public float curSpawnDelay;
    public Text scoreText;

    public void AddScore(int amount)
    {
        score += amount; // 점수 증가
        Debug.Log("현재 점수: " + score);
    }

    /*
    public void SelectButton(int buttonIndex)
    {
        selectedButtonIndex = buttonIndex;
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        SetButtonsActive(false, selectedButtonIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; // 게임 일시정지
        SetButtonsActive(true, selectedButtonIndex);
    }

    public void ResumeGame(int buttonIndex)
    {
        // 플레이어 모습 변경
        dragonCtrl.ChangeAppearance(buttonIndex);

        // 드래곤 총알 모양 변경
        dragonBullet.ChangeAppearance(buttonIndex);

        // 필요한 경우, 게임 재개 로직 추가
        Time.timeScale = 1f;

        // 버튼 패널 비활성화
        SetButtonsActive(false, buttonIndex);

        Debug.Log("Game Resumed with button index: " + buttonIndex);
    }

    private void SetButtonsActive(bool isActive, int buttonIndex)
    {
        // 버튼 패널 활성화/비활성화
        if (buttonPanel != null)
        {
            buttonPanel.SetActive(isActive);
            Debug.Log("Button panel set to " + isActive);
        }
        else
        {
            Debug.LogError("Button panel is not assigned!");
        }

        // 드래곤과 총알의 모습 변경
        if (dragonCtrl != null && dragonBullet != null && buttonIndex >= 0)
        {
            dragonCtrl.ChangeAppearance(buttonIndex);
            dragonBullet.ChangeAppearance(buttonIndex);
        }
        else
        {
            if (dragonCtrl == null)
                Debug.LogError("DragonCtrl is not assigned!");
            if (dragonBullet == null)
                Debug.LogError("DragonBullet is not assigned!");
            if (buttonIndex < 0)
                Debug.LogError("Button index is invalid!");
        }
    }
    */
    void Update()
    {
        curSpawnDelay += Time.deltaTime;

        if (curSpawnDelay > maxSpawnDelay)
        {
            SpawnEnemy();
            maxSpawnDelay = Random.Range(0.5f, 3f);
            curSpawnDelay = 0;
        }
    }

    void SpawnEnemy()
    {
        int ranEnemy = Random.Range(0, 3);
        int ranPoint = Random.Range(0, 5);
        Instantiate(enemyObjs[ranEnemy], spawnPoints[ranPoint].position, spawnPoints[ranPoint].rotation);
    }


    public void gameOver()
    {
        gameOverSet.SetActive(true);
    }

    /*public void gameRetry()
    {
        SceneManager.LoadScene(0);
    }*/
}