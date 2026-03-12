using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // This code contains the power-up pickups as well
    private Vector3 startPos;

    public float speed = 5f;
    private float baseSpeed = 5f;

    public float jumpForce = 5f;
    private float jumpTimer = 0f;
    private bool isOnGround = false;
    private float pastJumpForce = 0f;

    private Rigidbody rb;

    private float horizontalInput;

    private bool speedOrbPicked = false;
    private float speedTimer = 0f;

    private bool hasDoubleJump = false;
    private float doubleJumpTimer = 0f;
    private bool doubleJumpCalled = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        speed = baseSpeed;

        if (Input.GetButton("Jump"))
        {
            jumpTimer += Time.deltaTime;
            if (jumpTimer >= 3f && isOnGround) {
                rb.AddForce(Vector3.up * (jumpForce + jumpTimer), ForceMode.Impulse);
                pastJumpForce = jumpForce + jumpTimer;
                isOnGround = false;
                jumpForce = 5f;
                jumpTimer = 0f;
            }
        } else if(Input.GetButtonUp("Jump")) {
            if (isOnGround) {
               rb.AddForce(Vector3.up * (jumpForce + jumpTimer), ForceMode.Impulse);
                pastJumpForce = jumpForce + jumpTimer;
                jumpForce = 5f;
                jumpTimer = 0f;
                isOnGround = false; 
            } else if (!isOnGround && hasDoubleJump && !doubleJumpCalled) {
                rb.AddForce(Vector3.up * (pastJumpForce), ForceMode.Impulse);
                doubleJumpCalled = true;
            }
            
        }
        else {
            jumpTimer = 0f;
            jumpForce = 5f;
        }

        if (Input.GetButtonDown("Run"))
        {
            if (speed == 5f || speed == 7f) {
                baseSpeed = speed * 2;
            } else {
                baseSpeed = speed / 2;
            }
        }


        if(speedOrbPicked == true) 
        {
            speedTimer += Time.deltaTime;
            if (speedTimer >= 5f)
            {
                baseSpeed = 5f;
                speedOrbPicked = false;
                speedTimer = 0f;
            }
        }

        if (hasDoubleJump == true)
        {
            doubleJumpTimer += Time.deltaTime;
            if (doubleJumpTimer >= 30f)
            {
                hasDoubleJump = false;
                doubleJumpTimer = 0f;
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 moveVector = transform.position + horizontalInput * Vector3.right * speed * Time.deltaTime;
        rb.MovePosition(moveVector);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SpeedOrb")
        {
            baseSpeed = 7f;
            Destroy(other.gameObject);
            speedOrbPicked = true;
        }

        if (other.gameObject.tag == "Ground")
        {
            isOnGround = true;
            doubleJumpCalled = false;
        }

        if (other.gameObject.tag == "DoubleJumpOrb")
        {
            Destroy(other.gameObject);
            hasDoubleJump = true;
        }

        if (other.gameObject.tag == "ScoreOrb")
        {
            Destroy(other.gameObject);
            GameManager.Instance.AddScore(50);
        }

        if (other.gameObject.tag == "Trap")
        {
            GameManager.Instance.TakeDamage(1);
            transform.position = startPos;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isOnGround = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathFloor"))
        {
            print("AAA");
            GameManager.Instance.TakeDamage(1);
            transform.position = startPos;
        }
    }
}
