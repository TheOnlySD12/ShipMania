using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    float spawningTimer = 0;
    float spawningRate;

    int enemiesAlive = 0;
    int enemiesLeftToSpawn;
    GameObject enemyObject;
    int waveNumber = 0;
    GameObject[] waypointList;

    int numberOfWaveParents;
    GameObject[] waveParentArray;
    void Start()
    {
        waypointList = GameObject.FindGameObjectsWithTag("Waypoint");
        foreach(GameObject waypoint in waypointList)
        {
            //waypoint.SetActive(false);
        }

        for (int x = 0; x < numberOfWaveParents; x++)  // toate parenturile active de pe scena sunt puse, in ordine, intr-un array.
        {
            waveParentArray[x] = GameObject.Find("Wave " + (x+1) + " Parent");
        }

        foreach(GameObject parent in waveParentArray)
        {
            parent.SetActive(false);
        }
    }

    void Update()
    {
        spawningTimer -= Time.deltaTime;
        
        if(enemiesAlive == 0)
        {
            //waveParentArray[waveNumber].SetActive(false);

            waveNumber++;

            waveParentArray[waveNumber].SetActive(true);
            
            if (waveNumber == 1) { spawningRate = 1; enemiesLeftToSpawn = 12; enemyObject = GameObject.Find("Enemy 1"); }

            
        }
        
        if(spawningTimer <= 0 && enemiesLeftToSpawn > 0)
        {
            spawningTimer = spawningRate;
            Instantiate(enemyObject, transform.position, new Quaternion());
            
        }
        
        enemiesAlive = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
    
    
}
