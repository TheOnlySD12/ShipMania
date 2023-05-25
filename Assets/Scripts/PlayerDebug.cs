using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDebug : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            GetComponent<PlayerBasicControls>().ChangeAmmo(1);
        }
        if (Input.GetKeyDown("2"))
        {
            this.GetComponent<PlayerBasicControls>().ChangeAmmo(2);
        }
        if (Input.GetKeyDown("3"))
        {
            this.GetComponent<PlayerBasicControls>().ChangeAmmo(3);
        }
        if (Input.GetKeyDown("b"))
        {
            Instantiate(GameObject.Find("BombPowerUp"), new Vector2(4, 7), new Quaternion());
        }
        if (Input.GetKeyDown("p"))
        {
            Instantiate(GameObject.Find("MiniGunPowerUp"), new Vector2(-2,7), new Quaternion());
        }
        if (Input.GetKeyDown("f"))
        {
            Instantiate(GameObject.Find("FireRateUp"), new Vector2(0, 7), new Quaternion());
        }
        if (Input.GetKeyDown("n"))
        {
            Instantiate(GameObject.Find("BalancedPowerUp"), new Vector2(-4, 7), new Quaternion());
        }
    }

    public void BulletSelector(int ammo) {
        this.GetComponent<PlayerBasicControls>().ChangeAmmo(ammo);
    } 
}
