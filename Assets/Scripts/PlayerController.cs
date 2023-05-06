using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //bool isGrounded = true;
    public GameManager gameManager;
    Rigidbody rb;
    public GameObject tile;
    float speed = 5;
    public float upForce = 13;
    public float physicsMultiplier = 1;
    float auxPM;
    public float speedMultiplier;
    bool jumped = false;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= physicsMultiplier;
        rb = GetComponent<Rigidbody>();
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered jump");
        // rb.AddForce(Vector3.up * upForce/2, ForceMode.Impulse);


    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(Vector3.up * upForce, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.D) && transform.position.x < 5)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A) && transform.position.x > -5)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
