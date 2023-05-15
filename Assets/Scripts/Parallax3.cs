using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax3 : MonoBehaviour
{
    float starSpeed = 0;
    // Start is called before the first frame update
    void Update()
    {
        starSpeed = Input.GetAxis("Vertical")/-300;
        transform.position += new Vector3(0, -4  * Time.deltaTime + starSpeed);

        if (transform.position.y < -19.6)
        {
            transform.position = new Vector3(transform.position.x, 19.6f);
        }
    }

}
