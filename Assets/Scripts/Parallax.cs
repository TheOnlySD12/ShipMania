using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -1 * Time.deltaTime);
       
        if (transform.position.y < -19.6)
        {
            transform.position = new Vector3(transform.position.x, 19.6f);
        }
    }

}
