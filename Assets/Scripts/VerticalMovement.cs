using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    public float max = 2f;
    public float speed = 1f;

    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Mathf.Sin(Time.time * speed) * max;

        transform.position = startPos + new Vector3(direction, 0, 0);
    }
}
