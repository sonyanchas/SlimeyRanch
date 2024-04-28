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
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();  // create a reference to our animator component
    }

    void Update()
    {
        animator.SetBool("Left", false);
        animator.SetBool("Right", false);
        

        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Right", true); //set the right parameters true
            animator.SetBool("Left", false);
            isMoving = true;
            transform.Translate(Speed * Time.deltaTime * Vector2.right);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Left", true);
            animator.SetBool("Right", false);
            isMoving = true;
            transform.Translate(Speed * Time.deltaTime * Vector2.left);
            if (!audioSource.isPlaying)
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
            rb.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
        }

    }
}