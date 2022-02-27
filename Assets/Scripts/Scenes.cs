using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void Arcade()
    {
        SceneManager.LoadScene("Arcade");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
