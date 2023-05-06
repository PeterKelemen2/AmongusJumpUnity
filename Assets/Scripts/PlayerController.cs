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
    public float upForce = 20;
    public float physicsMultiplier = 1;

    public float speedMultiplier;



    // Start is called before the first frame update
    void Start()
    {
        
        Physics.gravity *= physicsMultiplier;
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.AddForce(Vector3.up * upForce, ForceMode.Impulse);
    }

    public void OnTriggerStay(Collider other)
    {
        Debug.Log("Triggered jump");
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        rb.AddForce(Vector3.up * upForce, ForceMode.Impulse);
    }

    

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Manual jump");
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
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
