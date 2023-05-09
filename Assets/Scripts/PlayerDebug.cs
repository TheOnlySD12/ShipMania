using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDebug : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            this.GetComponent<PlayerBasicControls>().ChangeAmmo(1);
        }
        if (Input.GetKeyDown("2"))
        {
            this.GetComponent<PlayerBasicControls>().ChangeAmmo(2);
        }
        if (Input.GetKeyDown("p"))
        {
            Instantiate(GameObject.Find("MiniGunPowerUp"), new Vector2(-2,7), new Quaternion());
        }
    }
}
