using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] GameObject tucyGameobject;
    [SerializeField] GameObject connectionLost;


    public GameObject continuePanel;
    void Start()
    {
        Advertisement.Initialize("4268633", true);
        Advertisement.AddListener(this);
    }

    public void PlayRewardedAd()
    {
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");
        }
        else
        {
            StartCoroutine(connection());
            Debug.Log("not able to play");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Readyyyyy");
    }

    public void OnUnityAdsDidError(string message)
    {

    }

    public void OnUnityAdsDidStart(string placementId)
    {

    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
        {
            tucyScript.Instance.ContinueGame();
            Debug.Log("Finisheeddddddddddddddd");
        }
    }
    IEnumerator connection()
    {
        connectionLost.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        connectionLost.SetActive(false);
    }
}
