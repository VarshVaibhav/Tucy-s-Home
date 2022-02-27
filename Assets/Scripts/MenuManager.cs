using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject classicPanel;
    public GameObject classicButton;
    public GameObject gemPanel;

    private void Start()
    {
        classicPanel.SetActive(false);
        classicButton.SetActive(true);
        gemPanel.SetActive(true);
    }
    public void openClassicPanel()
    {
        classicPanel.SetActive(true);
        classicButton.SetActive(false);
        gemPanel.SetActive(false);
    }
    public void closeClassicPanel()
    {
        classicPanel.SetActive(false);
        classicButton.SetActive(true);
        gemPanel.SetActive(true);
    }
}
