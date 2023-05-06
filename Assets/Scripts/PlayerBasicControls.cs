using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasicControls : MonoBehaviour
{
    Rigidbody2D body;
    [SerializeField] float gunTimer;
    float firerate = 1; //cu cat e mai mare, cu atat mai repede trage
    GameObject clone;
    [SerializeField] GameObject currentAmmo;

    float moveSpeed_base = 4;
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        ChangeAmmo(1);
    }


    void Update()
    {
        
        
        
        //movement
        body.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * moveSpeed_base;

        //lupta
        gunTimer -= Time.deltaTime;

        if (Input.GetButton("Fire1") && gunTimer < 0)
        {
            gunTimer = 1 / firerate;
            clone = Instantiate(currentAmmo, body.position, new Quaternion());
            clone.GetComponent<Rigidbody2D>().velocity = Vector2.up * currentAmmo.GetComponent<BulletBehaviour>().bulletSpeed;
            clone.layer = 7;
            
        }
    }
    public void ChangeAmmo(int type)
    {
        currentAmmo = GameObject.Find("Bullet " + type.ToString());
    }
}
