using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject buttonPanel; // ��ư �г�
    public Button[] buttons; // UI ��ư �迭
    public DragonCtrl dragonCtrl; // �巡�� ��Ʈ�ѷ� ����
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
        score += amount; // ���� ����
        Debug.Log("���� ����: " + score);
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
        Time.timeScale = 0f; // ���� �Ͻ�����
        SetButtonsActive(true, selectedButtonIndex);
    }

    public void ResumeGame(int buttonIndex)
    {
        // �÷��̾� ��� ����
        dragonCtrl.ChangeAppearance(buttonIndex);

        // �巡�� �Ѿ� ��� ����
        dragonBullet.ChangeAppearance(buttonIndex);

        // �ʿ��� ���, ���� �簳 ���� �߰�
        Time.timeScale = 1f;

        // ��ư �г� ��Ȱ��ȭ
        SetButtonsActive(false, buttonIndex);

        Debug.Log("Game Resumed with button index: " + buttonIndex);
    }

    private void SetButtonsActive(bool isActive, int buttonIndex)
    {
        // ��ư �г� Ȱ��ȭ/��Ȱ��ȭ
        if (buttonPanel != null)
        {
            buttonPanel.SetActive(isActive);
            Debug.Log("Button panel set to " + isActive);
        }
        else
        {
            Debug.LogError("Button panel is not assigned!");
        }

        // �巡��� �Ѿ��� ��� ����
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