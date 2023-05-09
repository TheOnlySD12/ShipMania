using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.down * 3;
    }
}
