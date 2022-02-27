using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchEle : MonoBehaviour
{
    public GameObject eleObject;
    private void Start()
    {
        switchFunction();
    }
    void Update()
    {

    }

    public void switchFunction()
    {
        if(Time.deltaTime % 2 == 0)
        {
            eleObject.SetActive(false);
        }
        if (Time.deltaTime % 2 == 1)
        {
            eleObject.SetActive(true); ;
        }
    }
}
