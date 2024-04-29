using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float MinX = 0f;
    [SerializeField] float MaxX = 0f;
    [SerializeField] float health, maxHealth = 10;
    public int damageamount = 2;
    Animator animator;
    SpriteRenderer spriteRenderer;
    bool movingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = maxHealth; 
    }

    public void takedamage(float damageamount)
    {
        if (Input.GetButtonDown("Fire1") == true)
        {
            health -= damageamount;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    // FixedUpdate is called at fixed time intervals
    void FixedUpdate()
    {
        // Move the enemy
        if (movingRight)
        {
            transform.Translate(Vector3.right * Speed * Time.fixedDeltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * Speed * Time.fixedDeltaTime);
        }

        // Check if the enemy reaches the boundaries
        if (transform.position.x >= MaxX)
        {
            movingRight = false;
            animator.SetBool("runleft", true);
        }
        else if (transform.position.x <= MinX)
        {
            movingRight = true;
            animator.SetBool("runright", true);
        }
        else
        {
            // If not at the boundaries, stop running animation
            animator.SetBool("runleft", false);
            animator.SetBool("runright", false);
        }
    }
    
 }


