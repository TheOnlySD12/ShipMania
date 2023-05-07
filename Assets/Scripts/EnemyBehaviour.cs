using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
#pragma warning disable 0414
    int speed;

#pragma warning restore 0414
    void Awake()
    {
        if (this.name.Contains("1"))
        {
            speed = 1;
        }
    }

    void Update()
    {

    }

}
