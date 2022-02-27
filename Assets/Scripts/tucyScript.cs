using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;


public class tucyScript : MonoBehaviour
{

    public static tucyScript Instance { set; get; }

    private GameObject[] allObs;
    private GameObject[] allSat;
    private GameObject[] allEle;
    private GameObject lastObject;


    public GameObject tucy;  //if starcount > 0 then proceed.

    public GameObject mainPanel;
    public GameObject pausePanel;
    public GameObject completePanel;
    public GameObject deathAdPanel;
    public GameObject pauseButton;
    public GameObject NoStarPanel;
    public GameObject continuePanel;
    public GameObject noStarText;

    public GameObject camera;
    public Animator playeranim;
    public Animator contAnim;
    public Animator lightAnim;

    int starScore =0;
    public Text starScoreText;

    public GameObject boomEffect1;
    public GameObject boomEffect2;
    public GameObject boomEle;
    public GameObject starEffect;

    public GameObject quote;

    public GameObject deathcollider; // offing the 2dcollider if completed

    public GameObject contrl; //regain life

    public Transform tucyTele;
    public Transform contrlTele;

    Controller cont;

    private void Awake()
    {
        Instance = this;
        cont = GameObject.Find("Controller").GetComponent<Controller>();
    }
    private void Start()
    {
        lastObject = GameObject.FindWithTag("last");

        allObs = GameObject.FindGameObjectsWithTag("obs");
        allSat = GameObject.FindGameObjectsWithTag("sat");
        allEle = GameObject.FindGameObjectsWithTag("ele");



        StartCoroutine(sometime());
        Time.timeScale = 1;
        contAnim.SetTrigger("come");


        continuePanel.SetActive(false);
        NoStarPanel.SetActive(false);
        mainPanel.SetActive(false);
        completePanel.SetActive(false);
        deathAdPanel.SetActive(false);
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        completePanel.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "obs")
        {
            cont.Sound();
            Debug.Log(collision.name);
            camera.GetComponent<AudioSource>().volume = 0.12f;
            camShakeForObs.Instance.ShakeIt();
            Instantiate(boomEffect1, transform.position, Quaternion.identity);
            Invoke("DeathWithAd", 0.4f);

            gameObject.SetActive(false);

        }
        if (collision.gameObject.tag == "sat" || collision.gameObject.tag == "last")
        {
            cont.Sound();
            Debug.Log(collision.name);
            camera.GetComponent<AudioSource>().volume = 0.12f;
            camShakeForObs.Instance.ShakeIt();
            Instantiate(boomEffect2, transform.position, Quaternion.identity);
            Invoke("DeathWithAd", 0.4f);
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "ele")
        {
            cont.Sound();
            camera.GetComponent<AudioSource>().volume = 0.12f;
            Debug.Log(collision.name);
            camShakeForObs.Instance.ShakeIt();
            Instantiate(boomEle, transform.position, Quaternion.identity);
            Invoke("DeathWithAd", 0.4f);
            gameObject.SetActive(false);
        }

        if (collision.gameObject.name == "Collider2d")
        {
            cont.Sound();

            camera.GetComponent<AudioSource>().volume = 0.12f;
            Debug.Log(collision.name);

            camShakeForObs.Instance.ShakeIt();
            DeathWithAd();
            gameObject.SetActive(false);

        }

        if (collision.gameObject.tag == "star")
        {
            cameraShake.Instance.ShakeIt();
            //camAnim.SetTrigger("shake");
            starScore++;
            Instantiate(starEffect, new Vector3(transform.position.x, transform.position.y, -9), Quaternion.Euler(120,0,0));
            Debug.LogError("collliidddeed");

            Destroy(collision.gameObject);
            starScoreText.text = starScore.ToString();

            GameDataManager.AddStars(1);
        }
        if(collision.gameObject.tag == "complete")
        {
            camera.GetComponent<AudioSource>().enabled = false;
            StopCoroutine("colOff");
            Debug.Log("Stopped");
            lastObject.GetComponent<PolygonCollider2D>().enabled = false;

            foreach (GameObject o in allObs)
            {
                    o.GetComponent<CircleCollider2D>().enabled = false;
            }

            foreach (GameObject s in allSat)
            {
                    s.GetComponent<PolygonCollider2D>().enabled = false;
            }

            foreach (GameObject e in allEle)
            {
                e.GetComponent<EdgeCollider2D>().enabled = false;
            }

            deathcollider.GetComponent<EdgeCollider2D>().enabled = false;
            playeranim.SetTrigger("in");



            if (tucy.GetComponent<LevelStar>().levelStar > 0) // if the first level star is bigger than 0, second level can play
            {
                Invoke("completed", 3f);
            }
            else if(tucy.GetComponent<LevelStar>().levelStar == 0)
            {

                StartCoroutine(NoStar());
                Invoke("Uncompleted", 3f);

            }
            
            
        }
    }

    public void DeathWithAd() // if internet us in
    {
        camera.GetComponent<CameraMovement>().enabled = false;
        pauseButton.SetActive(false);
        StopCoroutine("colOff");
        mainPanel.SetActive(true);
        
        deathAdPanel.SetActive(true);

        quote.SetActive(false);
    }

    public void ContinueGame()
    {
        deathAdPanel.SetActive(false);
        continuePanel.SetActive(true);
    }

    public void regainLife() //after watching ad
    {
        pauseButton.SetActive(true);
        gameObject.SetActive(true);

        StartCoroutine("colOff");
        mainPanel.SetActive(false);
        tucy.transform.position = tucyTele.transform.position;
        contrl.transform.position = contrlTele.transform.position;

        continuePanel.SetActive(false);
        camera.GetComponent<AudioSource>().volume = 0.3f;


        if (deathcollider.GetComponent<Collider2d>().lastSign.activeInHierarchy == false)
        {
            camera.GetComponent<CameraMovement>().enabled = false;
        }
        else { camera.GetComponent<CameraMovement>().enabled = true; }


        lightAnim.SetTrigger("light");
    }
    public void toRetry() // when we press this level, we can move to the correspomding scene to play
    {
            SceneManager.LoadScene("Level" + tucy.GetComponent<LevelStar>().levelIndex);  
    }
    public void toMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Uncompleted()
    {
        pauseButton.SetActive(false);
        camera.GetComponent<CameraMovement>().enabled = false;
        mainPanel.SetActive(true);
        NoStarPanel.SetActive(true);
    }

    public void completed()
    {
        pauseButton.SetActive(false);
        camera.GetComponent<CameraMovement>().enabled = false;
        mainPanel.SetActive(true);
        completePanel.SetActive(true);
    }
    public void pauseActive()
    {
        mainPanel.SetActive(true);
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;
    }
    public void pauseDeactive()
    {
        mainPanel.SetActive(false);
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    IEnumerator sometime()
    {
        quote.SetActive(true);
        camera.GetComponent<CameraMovement>().enabled = false;
        yield return new WaitForSeconds(2);
        quote.SetActive(false);
        camera.GetComponent<CameraMovement>().enabled = true;
    }
    IEnumerator colOff()
    {
        Debug.Log("enum started");
        lastObject.GetComponent<PolygonCollider2D>().enabled = false;

        foreach(GameObject o in allObs)
        {
            o.GetComponent<CircleCollider2D>().enabled = false;
        }

        foreach (GameObject s in allSat)
        {
            s.GetComponent<PolygonCollider2D>().enabled = false;
        }

        foreach (GameObject e in allEle)
        {
            e.GetComponent<EdgeCollider2D>().enabled = false;
        }

        yield return new WaitForSeconds(4.8f);

        Debug.Log("enum stopped");
        lastObject.GetComponent<PolygonCollider2D>().enabled = true;

        foreach (GameObject o in allObs)
        {
            o.GetComponent<CircleCollider2D>().enabled = true;
        }
        foreach (GameObject s in allSat)
        {
            s.GetComponent<PolygonCollider2D>().enabled = true;
        }

        foreach (GameObject e in allEle)
        {
            e.GetComponent<EdgeCollider2D>().enabled = true;
        }

    }

    IEnumerator NoStar()
    {
        Debug.Log("text gayag");
        noStarText.SetActive(false);
        yield return new WaitForSeconds(3.2f);
        noStarText.SetActive(true);
    }
}
