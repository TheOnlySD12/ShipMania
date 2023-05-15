using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax2 : MonoBehaviour
{
    float starSpeed = 0;
    void Update()
    {
        transform.position += new Vector3(0, -2 * Time.deltaTime + starSpeed);
        starSpeed = Input.GetAxis("Vertical") / -600;
        if (transform.position.y < -19.6)
        {
            transform.position = new Vector3(transform.position.x, 19.6f);
        }
    }

}
