using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] float Speed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
           transform.Translate(Speed * Time.deltaTime * Vector2.right);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Speed * Time.deltaTime * Vector2.left);
        }
    }
}
