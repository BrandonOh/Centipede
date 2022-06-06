using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CV_EnemySpawn : MonoBehaviour
{
    public GameObject SkeletonPrefab;
    public Transform Spawner;
    public static int enemyCount;

    private float elapsedTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        while (enemyCount < 2 && elapsedTime > 1)
        {
            SpawnEnemy();
            CV_EnemySpawn.enemyCount++;
            elapsedTime = 0;
        }
        elapsedTime += Time.deltaTime;
    }

    public void SpawnEnemy()
    {
        Vector3 spawnPos = Spawner.position;
        System.Random random = new System.Random();
        int rnd = random.Next(1, 5);
        float adjustedLocX = spawnPos.x + rnd;
        Vector3 adjustedPosition = new Vector3(adjustedLocX, Spawner.position.y + 5, Spawner.position.z);
        //spawnPosition = Spawner.position + random;
        GameObject Enemy = Instantiate(SkeletonPrefab, adjustedPosition, Spawner.rotation);
    }
}
