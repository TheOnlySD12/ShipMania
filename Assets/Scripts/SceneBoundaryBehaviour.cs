using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBoundaryBehaviour : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Contains("Bullet"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.name.Contains("PowerUp"))
        {
            Destroy(collision.gameObject);
        }
        
    }
}
