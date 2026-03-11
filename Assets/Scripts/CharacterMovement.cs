using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f;
    private float baseSpeed = 5f;
    public float jumpForce = 5f;
    private float jumpTimer = 0f;
    private Rigidbody rb;
    private float horizontalInput;
    private bool speedOrbPicked = false;
    private float speedTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        speed = baseSpeed;

        if (Input.GetButton("Jump"))
        {
            jumpTimer += Time.deltaTime;
            if (jumpTimer >= 3f) {
                rb.AddForce(Vector3.up * (jumpForce + jumpTimer), ForceMode.Impulse);
                jumpForce = 5f;
                jumpTimer = 0f;
            }
        } else if(Input.GetButtonUp("Jump")) {
            rb.AddForce(Vector3.up * (jumpForce + jumpTimer), ForceMode.Impulse);
            jumpForce = 5f;
            jumpTimer = 0f;
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
    }
}
