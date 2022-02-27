using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : LevelStar
{
    [SerializeField] private bool unlocked; // default value is false;
    public Image unlockImage;
    public GameObject[] imageStar;

    public Sprite starSprite;

    private void Start()
    {
        // PlayerPrefs.DeleteAll(); //never to use, reset krna ho, ek baar use kro and comment kr do fhir.
        UpdateLevelStatus();
        //PlayerPrefs.GetInt("Save");
        PlayerPrefs.GetInt("Savestarrr" + base.levelIndex, base.levelStar);
        Debug.Log(PlayerPrefs.GetInt("Savestarrr" + base.levelIndex, base.levelStar));
    }

    private void Update()
    {
        UpdateLevelImage(); //TODO  move this method later
                            // UpdateLevelStatus(); //TODO move this method later


    }

    private void UpdateLevelStatus()
    {
        // if the current lv is 5, the pre  should be 4
        int PreviousLevelNum = int.Parse(gameObject.name) - 1;
        // if(PlayerPrefs.GetInt("Lv" + PreviousLevelNum.ToString()) > 0) // if the first level star is bigger than 0, second level can play
         //{
          //   unlocked = true;
         //}

        if (PlayerPrefs.GetInt("Savestarrr" + PreviousLevelNum.ToString()) > 0) // if the first level star is bigger than 0, second level can play
        {
            unlocked = true;
        }
    }

    private void UpdateLevelImage()
    {
        if (!unlocked) //MARKER if unlock is false means This level is locked;
        {
            unlockImage.gameObject.SetActive(true);
            for (int i = 0; i < imageStar.Length; i++)
            {
                imageStar[i].gameObject.SetActive(false);
            }
        }
        else // if unlocke is true mean This level can play
        {
            unlockImage.gameObject.SetActive(false);
            for (int i = 0; i < imageStar.Length; i++)
            {
                imageStar[i].gameObject.SetActive(true);
            }
            for (int i = 0; i < PlayerPrefs.GetInt("Savestarrr" + gameObject.name); i++)
           {
                imageStar[i].gameObject.GetComponent<Image>().sprite = starSprite;
            }
        }
    }
    public void PressSelection(string _Levelname) // when we press this level, we can move to the correspomding scene to play
    {
        if (unlocked)
        {
            SceneManager.LoadScene(_Levelname);
        }
    }
}
