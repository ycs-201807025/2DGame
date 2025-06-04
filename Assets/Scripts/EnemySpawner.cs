using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;

    [SerializeField]
    private GameObject Boss;

    private float[] arrPosX = {-6f, -3f, 0f, 3f, 6f };

    [SerializeField]
    private float sapwnInterval = 1.5f;
    void Start()
    {
        StartEnemyRoutine();
    }
    void StartEnemyRoutine()
    {
        StartCoroutine("EnemyRoutine");
    }

    IEnumerator EnemyRoutine()
    {
        yield return new WaitForSeconds(3f);

        float moveSpeed = 5f;
        int spawnCount = 0;
        int enemyIndex = 0;

        while (true)
        {
            foreach (float posX in arrPosX)
            {
                //int index = Random.Range(0, enemies.Length);//랜덤생성
                SpawnEnemy(posX, enemyIndex, moveSpeed);
            }

            spawnCount++;
            if (spawnCount % 10 == 0)
            {
                enemyIndex++;
                moveSpeed += 2;
            }

            if(enemyIndex >= enemies.Length)
            {
                SpawnBoss();
                enemyIndex = 0;
                moveSpeed = 5f; // 보스 스폰 후 속도 초기화
            }

            yield return new WaitForSeconds(sapwnInterval);
        }
        
    }

    void SpawnEnemy(float posX, int index, float moveSpeed)
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);

        if(Random.Range(0,5) == 0)
        {
            index++;
        }
       

        if (index >= enemies.Length)
        {
            index = enemies.Length - 1; 
        }

        GameObject enmeyObject = Instantiate(enemies[index], spawnPos, Quaternion.identity);
        Enemy enemy = enmeyObject.GetComponent<Enemy>();
        enemy.SetMoveSpeed(moveSpeed);
    }

    void SpawnBoss()
    {
        Instantiate(Boss, transform.position, Quaternion.identity);
    }
}
