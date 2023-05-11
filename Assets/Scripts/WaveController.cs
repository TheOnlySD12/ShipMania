using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    GameObject[] listaInamici;
    GameObject[] listaWaveParenturi;
    int numarInamiciInViata;
    int waveNumber = -1;
    
    private void Start()
    {
        listaInamici = new GameObject[GameObject.FindGameObjectsWithTag("Enemy").Length];
        listaWaveParenturi = new GameObject[GameObject.FindGameObjectsWithTag("WaveParent").Length];

        for(int x = 0; x < listaInamici.Length; x++)
        {
            listaInamici[x] = GameObject.Find("Enemy " + x);
        }
        foreach(GameObject gameObject in listaInamici)
        {
            gameObject.SetActive(false);
        }

        for(int x = 0; x < listaWaveParenturi.Length; x++)
        {
            listaWaveParenturi[x] = GameObject.Find("Wave " + x + " Parent");
        }
        foreach(GameObject gameObject in listaWaveParenturi)
        {
            gameObject.SetActive(false);
        }


    }

    float timer;
    float numaratoareInamici = 12;

      public GameObject inamic;
    private void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0 && numaratoareInamici > 0)
        {
            inamic = GameObject.Instantiate(listaInamici[0], this.transform.position, new Quaternion());
            inamic.SetActive(true);
            timer = 0.5f;
            numaratoareInamici--;
        }

        if(numaratoareInamici <= 0)
        {
            NextWave();
        }
    }

    void NextWave()
    {
        waveNumber++;

        listaWaveParenturi[waveNumber - 1].SetActive(false);
        listaWaveParenturi[waveNumber].SetActive(true);

        if (waveNumber == 0)
        {
            numaratoareInamici = 12;
            inamic = listaInamici[0];
        }
        
        
        if (waveNumber == 1)
        {
            numaratoareInamici = 3;
            inamic = listaInamici[1];
        }

    }
}
