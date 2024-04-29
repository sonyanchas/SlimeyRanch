using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    AudioSource audioSource;
    [SerializeField] float Speed = 0f;
    [SerializeField] float jump = 0f;
    bool isMoving = false;
    bool isJumping = false;
    Animator animator;
    GameManager gm;
    Collision2D collision;
    public int health = 100;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();  // create a reference to our animator component
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        animator.SetBool("Left", false);
        animator.SetBool("Right", false);
        animator.SetBool("Up", false);

        if (transform.position.y > -6.66f)
        {
            if (gm.Lives <= 0)
            {
               Time.timeScale = 0;
            }
            else
            {
                transform.position = new Vector3(-6.49f, -3.25f, 0f);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Right", true); //set the right parameters true
            animator.SetBool("Left", false);
            animator.SetBool("Up", false);
            isMoving = true;
            transform.Translate(Speed * Time.deltaTime * Vector2.right);
            if (!audioSource.isPlaying /*&& collision.gameObject.CompareTag("Floor")*/)
            {
                audioSource.Play();
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Left", true);
            animator.SetBool("Right", false);
            animator.SetBool("Up", false);
            isMoving = true;
            transform.Translate(Speed * Time.deltaTime * Vector2.left);
            if (!audioSource.isPlaying /*&& collision.gameObject.CompareTag("Floor")*/)
            {
                audioSource.Play();
            }
        }
        else
        {
            isMoving = false;
            audioSource.Stop();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
            rb.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);



        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gm.Health -= 10;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gm.Health -= 10;
        }

    }
    }






