using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
#pragma warning disable 0414
    public float bulletDamage;
    public float bulletSpeed;
#pragma warning restore 0414
    void Awake()
    {
        if (this.name.Contains("1"))
        {
            bulletDamage = 1;
            bulletSpeed = 15;
        }

        if (this.name.Contains("2"))
        {
            bulletDamage = 0.2f;
            bulletSpeed = 16;
        }
    
    
    
    }

}
