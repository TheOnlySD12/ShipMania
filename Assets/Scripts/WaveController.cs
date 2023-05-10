using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    GameObject[] listaInamici;
    public GameObject inamic;

    private void Start()
    {
        listaInamici = new GameObject[GameObject.FindGameObjectsWithTag("Enemy").Length];

        for(int x = 0; x < GameObject.FindGameObjectsWithTag("Enemy").Length; x++)
        {
            listaInamici[x] = GameObject.Find("Enemy " + x);
        }
        foreach(GameObject gameObject in listaInamici)
        {
            gameObject.SetActive(false);
        }

    }

    float timer;
    float numaratoareInamici = 12;
    
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
    }
}
