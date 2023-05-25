using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasicControls : MonoBehaviour
{
    Rigidbody2D body;

    bool hasBullet;

    public Canvas canvasText;

    [SerializeField] float gunTimer;
    float firerate = 2; //cu cat e mai mare, cu atat mai repede trage
    GameObject clone;
    [SerializeField] GameObject currentAmmo;

    float fireRateModifier = 1;

    public Animator animator;


    float moveSpeed_base = 8;
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        ChangeAmmo(0);
    }


    void Update()
    {
        
        //movement
        body.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * moveSpeed_base;

        //lupta
        gunTimer -= Time.deltaTime;

        if (Input.GetButton("Fire1") && gunTimer < 0)
        {
            gunTimer = 1 / (firerate * fireRateModifier);
            clone = Instantiate(currentAmmo, body.position, new Quaternion());
            clone.GetComponent<Rigidbody2D>().velocity = Vector2.up * currentAmmo.GetComponent<BulletBehaviour>().bulletSpeed;
            clone.layer = 7;

        }

        if (hasBullet)
        {
            canvasText.gameObject.SetActive(false);
            Destroy(GameObject.Find("BalancedPowerUp"));
            Destroy(GameObject.Find("BombPowerUp"));
            Destroy(GameObject.Find("MiniGunPowerUp"));
        }

        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput < 0)
        {
            // Play the animation for moving left
            animator.SetBool("IsMovingLeft", true);
        }
        else if (horizontalInput > 0)
        {
            // Play the animation for moving right
            animator.SetBool("IsMovingRight", true);
        }
        else
        {
            // Stop both animations if the player isn't moving
            animator.SetBool("IsMovingLeft", false);
            animator.SetBool("IsMovingRight", false);
        }

    }
    public void ChangeAmmo(int type)
    {
        currentAmmo = GameObject.Find("Bullet " + type.ToString());
        firerate = currentAmmo.GetComponent<BulletBehaviour>().bulletFireRate;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("FireRate"))
        {
            Destroy(collision.gameObject);
            fireRateModifier *= 1.25f;
        }
    }



}
