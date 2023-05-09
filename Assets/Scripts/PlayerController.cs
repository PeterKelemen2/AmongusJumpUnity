using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
// using UnityEditor.UIElements;
// using UnityEditorInternal;
using UnityEngine;
// using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //bool isGrounded = true;
    public GameManager gameManager;
    Rigidbody rb;
    public GameObject tile;

    float speed = 5f;
    public float upForce = 20f;
    private float physicsMultiplier = 1f;

    public float speedMultiplier;

    public float maxHeight = 0;

    public bool playerIsDead = false;

    [SerializeField] private int coinsCollected = 0;
    [SerializeField] private int allCoinsGot;

    // Start is called before the first frame update
    void Start()
    {
        readAllCoinsFromFile();

        Physics.gravity *= physicsMultiplier;
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.AddForce(Vector3.up * upForce, ForceMode.Impulse);

        
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("tile"))
        {
            // Debug.Log("Triggered jump");
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            rb.AddForce(Vector3.up * upForce, ForceMode.Impulse);
        }
        
        if (other.CompareTag("Coin"))
        {
            Debug.Log("Coin aquired");
            other.gameObject.SetActive(false);
            coinsCollected++;
            allCoinsGot++;

        }

        if (other.CompareTag("MainCamera"))
        {
            playerIsDead = true;
        }
    }
    static readonly string saveFile = @"Assets\CoinsSave.txt";

    public bool getDeathStatus()
    {
        if (playerIsDead)
        {
            return true;
        }
        return false;
    }

    private void readAllCoinsFromFile()
    {
        if (File.Exists(saveFile))
        {
            Debug.Log("File Found!");
            string amount = File.ReadLines(saveFile).Last();            
            allCoinsGot = Int32.Parse(amount);
            Debug.Log("Player Controller allCoinsGot = " + allCoinsGot);
        }
    }

    public int getCoinsCollected()
    {
        return coinsCollected;
    }

    public int getAllCoinsFromGameManager()
    {
        return gameManager.giveAllCoinsToPlayerController();
    }

    public int allCoinsGotGiver()
    {
        return allCoinsGot;
    }

    void Update()
    {
        checkMaxHeight();

        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Manual jump");
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.AddForce(Vector3.up * upForce, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.D) && transform.position.x < 5)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            
            //rb.AddForce(Vector3.right * speed, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.A) && transform.position.x > -5)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            // rb.AddForce(Vector3.left * speed, ForceMode.Impulse);
        }
    }

    void checkMaxHeight()
    {
        if (transform.position.y > maxHeight)
        {
            maxHeight = transform.position.y;
        }
        //Debug.Log("Max Height: " + maxHeight); // 3,5 for one jump
    }

    public void turnOffPhysics()
    {
        physicsMultiplier = 0;
    }

}
