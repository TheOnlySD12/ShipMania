using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
#pragma warning disable 0414
    float health;
#pragma warning restore 0414

    GameObject[] listaPuncte;
    Rigidbody2D body;

    float viteza = 5;

    private void Awake()
    {
        listaPuncte = new GameObject[GameObject.FindGameObjectsWithTag("Waypoint").Length];
        body = GetComponent<Rigidbody2D>();
        
        for(int x = 0; x < GameObject.FindGameObjectsWithTag("Waypoint").Length; x++)
        {
            listaPuncte[x] = GameObject.Find("Waypoint " + x);
            Debug.Log(listaPuncte[x]);
        }
    
        
    }

    int urmatorulPunct = -1;
    float distantaPanaLaUrmPct;
    float timer;

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            urmatorulPunct++;
            distantaPanaLaUrmPct = (listaPuncte[urmatorulPunct].transform.position - this.transform.position).magnitude;
            body.velocity = (listaPuncte[urmatorulPunct].transform.position - this.transform.position).normalized * viteza;
            timer = distantaPanaLaUrmPct / viteza;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Bullet"))
        {
            TakeDamage(collision.gameObject.GetComponent<BulletBehaviour>().bulletDamage);
            Destroy(collision.gameObject);
        }
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    
}
