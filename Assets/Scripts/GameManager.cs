using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    [SerializeField]
    private TextMeshProUGUI text; // ���� UI �ؽ�Ʈ

    [SerializeField]
    private GameObject gameOverPanel; // ���� ���� �г�

    private int coin = 0;

    [HideInInspector]
    public bool isGameOver = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void IncreaseCoin()
    {
        coin++;
        text.SetText(coin.ToString());

        if (coin % 30 == 0)
        {
            Player player = FindObjectOfType<Player>();
            if (player != null)
            {
                player.Upgrade(); // �÷��̾� ���׷��̵� �޼ҵ� ȣ��
            }
        }
    }

    public void SetGameOver()
    {
        isGameOver = true;

        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        if (enemySpawner != null)
        {
            enemySpawner.StopEnemyRoutine(); // �� ���� ����
        }

        Invoke("ShowGameOverPanel", 1f); // 1�� �� ���� ���� �г� ǥ��
    }

    void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true); // ���� ���� �г� Ȱ��ȭ
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene"); // ���� �� �����
    }
}
