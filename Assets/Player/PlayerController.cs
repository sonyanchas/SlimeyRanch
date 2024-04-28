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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
      
        if (Input.GetKey(KeyCode.D))
        {
            isMoving = true;
            transform.Translate(Speed * Time.deltaTime * Vector2.right);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
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
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
        }

    }
}