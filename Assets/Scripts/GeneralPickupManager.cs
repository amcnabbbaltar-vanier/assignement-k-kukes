using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float rotateSpeed = 30f;
    public float hoverHeight = 0.05f;
    public float hoverSpeed = 1f;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, startPos.y + Mathf.Sin(Time.time * hoverSpeed) * hoverHeight, transform.position.z);
    }
}
