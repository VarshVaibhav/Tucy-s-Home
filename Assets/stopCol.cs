using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopCol : MonoBehaviour
{

    public GameObject camera;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "last")
        {
            camera.GetComponent<CameraMovement>().enabled = false;
            Destroy(collision.gameObject);
        }
    }
}
