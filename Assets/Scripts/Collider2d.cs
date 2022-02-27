using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider2d : MonoBehaviour
{
    [SerializeField] GameObject camera;
    public GameObject lastSign;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "last")
        {
            camera.GetComponent<CameraMovement>().enabled = false;
            lastSign.SetActive(false);
        }
    }
}

