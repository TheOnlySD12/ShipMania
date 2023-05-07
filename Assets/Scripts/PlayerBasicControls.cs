using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasicControls : MonoBehaviour
{
    Rigidbody2D body;

    float moveSpeed_base = 4;
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        body.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * moveSpeed_base;
    }
}
