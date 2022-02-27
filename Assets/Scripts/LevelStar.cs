using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStar : MonoBehaviour
{
    public int levelStar;
    public int levelIndex;
    


    public GameObject bigStarEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "redstar")
        {
            Destroy(other.gameObject);

            Instantiate(bigStarEffect, new Vector3(transform.position.x, transform.position.y, -9), Quaternion.identity);
            levelStar++;
            Debug.Log(levelStar);
        }
    }

    /* public void BackAndSave(string _Levelname)
     {
         //PlayerPrefs.SetInt("Save" + levelIndex, countStar);
         if (levelStar > PlayerPrefs.GetInt("Savestarrr" + levelIndex))
         {
             PlayerPrefs.SetInt("Savestarrr" + levelIndex, levelStar);

         }
         // PlayerPrefs.SetInt("Save" + levelIndex, countStar);
         Debug.Log(PlayerPrefs.GetInt("Savestarrr" + levelIndex, levelStar));

         SceneManager.LoadScene(_Levelname);
         //SceneManager.LoadScene(0);
         Time.timeScale = 1;

     }*/
    public void toMenu()
    {
        //PlayerPrefs.SetInt("Save" + levelIndex, countStar);
        if (levelStar > PlayerPrefs.GetInt("Savestarrr" + levelIndex))
        {
            PlayerPrefs.SetInt("Savestarrr" + levelIndex, levelStar);

        }
        // PlayerPrefs.SetInt("Save" + levelIndex, countStar);
        Debug.Log(PlayerPrefs.GetInt("Savestarrr" + levelIndex, levelStar));

        SceneManager.LoadScene("Menu");
        //SceneManager.LoadScene(0);
        Time.timeScale = 1;

    }
    public void toRetry()
    {
        //PlayerPrefs.SetInt("Save" + levelIndex, countStar);
        if (levelStar > PlayerPrefs.GetInt("Savestarrr" + levelIndex))
        {
            PlayerPrefs.SetInt("Savestarrr" + levelIndex, levelStar);

        }
        // PlayerPrefs.SetInt("Save" + levelIndex, countStar);
        Debug.Log(PlayerPrefs.GetInt("Savestarrr" + levelIndex, levelStar));

        SceneManager.LoadScene("Level"+levelIndex);
        //SceneManager.LoadScene(0);
        Time.timeScale = 1;

    }
    public void toNext()
    {
        //PlayerPrefs.SetInt("Save" + levelIndex, countStar);
        if (levelStar > PlayerPrefs.GetInt("Savestarrr" + levelIndex))
        {
            PlayerPrefs.SetInt("Savestarrr" + levelIndex, levelStar);

        }
        // PlayerPrefs.SetInt("Save" + levelIndex, countStar);
        Debug.Log(PlayerPrefs.GetInt("Savestarrr" + levelIndex, levelStar));

        SceneManager.LoadScene("Level" +(levelIndex+1));
        //SceneManager.LoadScene(0);
        Time.timeScale = 1;

    }
}
