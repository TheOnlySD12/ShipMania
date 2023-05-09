using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
#pragma warning disable 0414
    public float bulletDamage;
    public float bulletSpeed;
    public float bulletFireRate;

    public float damageRadius;
    public int explosionDamage;

#pragma warning restore 0414
    void Awake()
    {
        if (this.name.Contains("1"))
        {
            bulletDamage = 1;
            bulletSpeed = 15;
            bulletFireRate = 1.8f;
        }

        if (this.name.Contains("2"))
        {
            bulletDamage = 0.1f;
            bulletSpeed = 16;
            bulletFireRate = 9;
        }

        if (this.name.Contains("3"))
        {
            bulletDamage = 1;
            bulletSpeed = 14;
            bulletFireRate = 0.7f;


        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.name.Contains("3"))
        {
            Explode();
        }

    }

    public void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, damageRadius);
        foreach (Collider2D collider in colliders)
        {
            EnemyBehaviour health = collider.gameObject.GetComponent<EnemyBehaviour>();
            if (health != null)
            {
                health.TakeDamage(explosionDamage);
            }
        }
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        // Draw a wire sphere with the same radius as the damageRadius.
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, damageRadius);
    }
}
