using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float MinX = 0f;
    [SerializeField] float MaxX = 0f;
    [SerializeField] int damageAmount;
    Animator animator;
    AudioSource audioSource1;
    SpriteRenderer spriteRenderer;
    bool movingRight = true;
    GameManager eh;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        eh = FindObjectOfType<GameManager>();
        audioSource1 = GetComponent<AudioSource>();

    }

    IEnumerator FlashRed()
    {
        // Change the color to red
        spriteRenderer.material.color = Color.red;

        // Wait for a short duration (you can adjust this as needed)
        yield return new WaitForSeconds(0.5f);

        // Change the color back to white
        spriteRenderer.material.color = Color.white;
    }

   

    // Method to handle taking damage
    public void TakeDamage(int damageAmount)
    {
        eh.Ehealth -= damageAmount;
    }
   void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Get the mouse position in the game world
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f; // Ensure the z-coordinate is appropriate for 2D games

            // Perform a collision check at the mouse position
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePos);

            // Check if the collision is with this enemy
            if (hitCollider != null && hitCollider.gameObject == gameObject)
            {
                // Reduce enemy health
                TakeDamage(10); // You can change the damage value as needed
                StartCoroutine(FlashRed());
                audioSource1.Play();
            }
        }
        if (eh.Ehealth <= 0)
        {
            // Destroy the enemy object
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


