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
    }
}
