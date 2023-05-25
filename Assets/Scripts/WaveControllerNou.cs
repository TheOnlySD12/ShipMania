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

        foreach(GameObject enemy in enemyList)
        {
            enemy.SetActive(false);
        }
        foreach(GameObject waypointGroup in waveParentList)
        {
            waypointGroup.SetActive(true);
        }
    }

    private void Update()
    {
        spawningTimer -= Time.deltaTime;
        //if(/*instantiatedEnemyList.Count != 0*/)
        {
            //enemiesLeftAlive = instantiatedEnemyList.Count;
        }
        
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
                
                clone.SetActive(true);
                //instantiatedEnemyList.Add(clone);

                enemiesLeftAlive++;
                enemiesLeftToSpawn--;
                spawningTimer = currentSpawnDelay;
            }
        }
        Debug.Log("aaaaaaaaaaaaa");
    }


    void NextWave()
    {
        //waveParentList[waveNumber].SetActive(false);
        waveNumber++;
        //waveParentList[waveNumber].SetActive(true);

        if (waveNumber == 0)
        {
            currentEnemy = enemyList[0];
            currentSpawnDelay = 1;
            enemiesLeftToSpawn = 10;
        }
    }
}
