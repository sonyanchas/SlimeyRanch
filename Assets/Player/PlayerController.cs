using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    
    public string sceneName;
    Rigidbody2D rb;
    AudioSource audioSource1;
    AudioSource audioSource2;
    [SerializeField] float Speed = 0f;
    [SerializeField] float jump = 0f;
    bool isMoving = false;
    bool isJumping = false;
    Animator animator;
    GameManager gm;
    Collision2D collision;
    Renderer ren;
    public int health = 100;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource1 = GetComponent<AudioSource>();
        audioSource2 = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();  // create a reference to our animator component
        gm = FindObjectOfType<GameManager>();
        ren = GetComponent<Renderer>();
    }

    IEnumerator FlashRed()
    {
        // Change the color to red
        ren.material.color = Color.red;

        // Wait for a short duration (you can adjust this as needed)
        yield return new WaitForSeconds(0.5f);

        // Change the color back to white
        ren.material.color = Color.white;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {


        if  (gm.Health == 0 || gm.Healthbar.fillAmount <= 0.01f)
            {
            gm.Lives -= 1;
            transform.position = new Vector3(-6.49f, -3.25f, 0f);
            gm.Health += 100;
            gm.Healthbar.fillAmount = 100;

        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gm.Health -= 10;
            StartCoroutine(FlashRed());
            gm.UpdateHealthBar();
            audioSource2.Play();
        } 
     



    }


    void OnTriggerEnter2D(Collider2D collision)
    {


        if (gm.Health == 0 || gm.Healthbar.fillAmount <= 0.01f)
        {
            gm.Lives -= 1;
            transform.position = new Vector3(-6.49f, -3.25f, 0f);
            gm.Health += 100;
            gm.Healthbar.fillAmount = 100;

        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            gm.GetSceneChange();
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            gm.Health -= 10;
            StartCoroutine(FlashRed());
            gm.UpdateHealthBar();
            audioSource2.Play();
        }
    }

    void Update()
    {
        animator.SetBool("Left", false);
        animator.SetBool("Right", false);
        animator.SetBool("Up", false);
        

        if (transform.position.y < -8f)
        {
            if (gm.Lives <= 0)
            {
               Time.timeScale = 0;
            }
            else
            {
                gm.Lives -= 1;
                transform.position = new Vector3(-6.49f, -3.25f, 0f);
                gm.Health += 100;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Right", true); //set the right parameters true
            animator.SetBool("Left", false);
            animator.SetBool("Up", false);
            isMoving = true;
            transform.Translate(Speed * Time.deltaTime * Vector2.right);
            if (!audioSource1.isPlaying)
            {
                audioSource1.Play();
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Left", true);
            animator.SetBool("Right", false);
            animator.SetBool("Up", false);
            isMoving = true;
            transform.Translate(Speed * Time.deltaTime * Vector2.left);
            if (!audioSource1.isPlaying)
            {
                audioSource1.Play();
            }
        }
        else
        {
            isMoving = false;
            audioSource1.Stop();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
            rb.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);

        }
     

    }
    
}







