using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private Vector3 starPos;

    [SerializeField] float frequency = 5f;
    [SerializeField] float magnitude = 5f;
    [SerializeField] float offset = 0f;
    [SerializeField] bool right = false;
    [SerializeField] bool up = false;


    void Start()
    {
        starPos = transform.position;
    }
    void Update()
    {
        if (right == true)
        {
            transform.position = starPos + transform.right * Mathf.Sin(Time.time * frequency + offset) * magnitude;
        }
        if (up == true)
        {
            transform.position = starPos + transform.up * Mathf.Sin(Time.time * frequency + offset) * magnitude;
        }
    }
}
