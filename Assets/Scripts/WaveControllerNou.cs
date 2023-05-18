using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveControllerNou : MonoBehaviour
{
    
    
    
    //variabile universale
    float spawningTimer;
    GameObject[] enemyList;
    GameObject[] waveParentList;
    List<GameObject> instantiatedEnemyList;

    //caracteristici waveuri
    //  enemiesLeftAlive
    GameObject currentEnemy;
    float currentSpawnDelay;

    
    //conditii wave
    int waveNumber;
    int enemiesLeftToSpawn;
    int enemiesLeftAlive;
    GameObject clone;

    private void Start()
    {
        enemyList = new GameObject[GameObject.FindGameObjectsWithTag("Enemy").Length];
        waveParentList = new GameObject[GameObject.FindGameObjectsWithTag("WaveParent").Length];

        for (int i = 0; i < enemyList.Length; i++)
        {
            enemyList[i] = GameObject.Find("Enemy " + i);
        }
        for (int i = 0; i < waveParentList.Length; i++)
        {
            waveParentList[i] = GameObject.Find("Wave " + i + " Parent");
        }
    }

    private void Update()
    {
        spawningTimer -= Time.deltaTime;
        enemiesLeftAlive = instantiatedEnemyList.Count;
        
        if (enemiesLeftToSpawn <=0)
        {
            
            
            if (enemiesLeftAlive <= 0)
            {
                NextWave();
            }
        }
        else
        {
            if (spawningTimer <= 0)
            {
                clone = Instantiate(currentEnemy, this.transform.position, new Quaternion());
                instantiatedEnemyList.Add(clone);

                enemiesLeftAlive++;
                enemiesLeftToSpawn--;
                spawningTimer = currentSpawnDelay;
            }
        }    
    }


    void NextWave()
    {
        waveNumber++;

        if(waveNumber == 0)
        {
            currentEnemy = enemyList[0];
            currentSpawnDelay = 1;
            enemiesLeftToSpawn = 10;
        }
    }
}
