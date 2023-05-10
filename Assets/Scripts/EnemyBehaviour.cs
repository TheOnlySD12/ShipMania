using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
#pragma warning disable 0414
    int speed;
    float health;
#pragma warning restore 0414
    int nextWaypointNumber = 1;
    int numberOfActiveWaypoints;
    GameObject[] waypointArray;

    float distanceToNextWaypoint;

    Rigidbody2D body;
    float moveSpeed = 1;

    [SerializeField] float moveTimer = 0;

    void Awake()
    {
        if (this.name.Contains("1")) { moveSpeed = 1; }

        
        numberOfActiveWaypoints = GameObject.FindGameObjectsWithTag("Waypoint").Length;
        waypointArray = new GameObject[numberOfActiveWaypoints];
        
        for(int x = 0; x < numberOfActiveWaypoints; x++)  // toate waypointurile active de pe scena sunt puse, in ordine, intr-un array.
        {
            waypointArray[x] = GameObject.Find("Waypoint " + (x+1));
        }

        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveTimer -= Time.deltaTime;
        if (moveTimer <= 0)
        {
            moveTimer = (distanceToNextWaypoint / moveSpeed) / 10;
            
            nextWaypointNumber++;
            
            /*transform.right = waypointArray[nextWaypointNumber].transform.position - this.transform.position;*/
            distanceToNextWaypoint = Mathf.Abs((waypointArray[nextWaypointNumber].transform.position - this.transform.position).magnitude);
            body.velocity = (waypointArray[nextWaypointNumber].transform.position - this.transform.position) * moveSpeed;
            Debug.Log(nextWaypointNumber);
        }

        Debug.Log(waypointArray[0]);
        Debug.Log(moveTimer);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
    }
    
}
