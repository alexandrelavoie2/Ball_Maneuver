using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;


public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI levelText;
    public GameObject winTextObject;

    public int forceConst = 0;
    private bool canJump;
    public float jumpHeight = 0f;
    public bool isGrounded;
    
    private Rigidbody rb;
    private int level;
    
    private float movementX;
    private float movementY;

    // Program starts
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        level = 1;
        SetlevelText();
        winTextObject.SetActive(false);
        isGrounded = true;

    }
    void SetlevelText()
    {
        levelText.text = "Level: " + level.ToString();
        if(level >= 5)
        {
            winTextObject.SetActive(true);
        }
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void OnJump()
    { 

        if (isGrounded == true)

        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);

        if(canJump)
        {
            canJump = false;
            rb.AddForce(0, forceConst, 0, ForceMode.Impulse);
            
        }

    }        
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false);
            level = level + 1;
            SetlevelText();
        }
    }
    void Update()
    { 
    }

    void OnCollisionEnter(Collision gameObject)
    {
        isGrounded = true;
    }
    void OnCollisionExit(Collision gameObject)
    { 
        isGrounded = false;
    }



}





