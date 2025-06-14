using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    [SerializeField]
    private TextMeshProUGUI text; // 코인 UI 텍스트

    [SerializeField]
    private GameObject gameOverPanel; // 게임 오버 패널

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
                player.Upgrade(); // 플레이어 업그레이드 메소드 호출
            }
        }
    }

    public void SetGameOver()
    {
        isGameOver = true;

        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        if (enemySpawner != null)
        {
            enemySpawner.StopEnemyRoutine(); // 적 스폰 중지
        }

        Invoke("ShowGameOverPanel", 1f); // 1초 후 게임 오버 패널 표시
    }

    void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true); // 게임 오버 패널 활성화
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene"); // 게임 씬 재시작
    }
}
