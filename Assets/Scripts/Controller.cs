using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Controller : MonoBehaviour
{
    private Vector2 velocity;
    private Rigidbody2D rb2D;
    AudioSource audioSource;

    LevelStar Index;
    [SerializeField] ParticleSystem burner;
    private void Awake()
    {
        Index = GameObject.Find("Tucy").GetComponent<LevelStar>();
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.isKinematic = true;

    }
    public void Sound()
    {
        audioSource.Play();
    }
    void OnMouseDown() // on hold -> boast high krna hai, particle effect, filhal color change he thik
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if(Index.levelIndex < 6)
        {
            burner.startLifetime = 1f;
        }
        else if (Index.levelIndex < 11 && Index.levelIndex > 5)
        {
            burner.startLifetime = 1.7f;
        }
        else if (Index.levelIndex < 16 && Index.levelIndex > 10)
        {
            burner.startLifetime = 1.2f;
        }
        else if (Index.levelIndex < 21 && Index.levelIndex > 15)
        {
            burner.startLifetime = 2f;
        }
        else if (Index.levelIndex < 26 && Index.levelIndex > 19)
        {
            burner.startLifetime = 1f;
        }

    }
    void OnMouseUp() // on not hold -> boast Low krna hai, particle effect, filhal color chnage he thik
    {
        if (Index.levelIndex < 6)
        {
            burner.startLifetime = 0.3f;
        }
        else if (Index.levelIndex < 11 && Index.levelIndex > 5)
        {
            burner.startLifetime = 1f;
        }
        else if (Index.levelIndex < 16 && Index.levelIndex > 10)
        {
            burner.startLifetime = 0.5f;
        }
        else if (Index.levelIndex < 21 && Index.levelIndex > 15)
        {
            burner.startLifetime = 1f;
        }
        else if (Index.levelIndex < 26 && Index.levelIndex > 19)
        {
            burner.startLifetime = 0.5f;
        }
        //anim.SetTrigger("cIdle");
    }
    void OnMouseDrag()
    {
       // if (EventSystem.current.IsPointerOverGameObject())
         //   return;

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        velocity = new Vector2((mousePosition.x - rb2D.position.x) * 12f, (mousePosition.y - rb2D.position.y) * 12f);

        if ((velocity * Time.fixedDeltaTime).x != mousePosition.x
        && (velocity * Time.fixedDeltaTime).y != mousePosition.y)
        {
            rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);
        }
        if (Index.levelIndex < 6)
        {
            burner.startLifetime = 1f;
        }
        else if (Index.levelIndex < 11 && Index.levelIndex > 5)
        {
            burner.startLifetime = 1.7f;
        }
        else if (Index.levelIndex < 16 && Index.levelIndex > 10)
        {
            burner.startLifetime = 1.2f;
        }
        else if (Index.levelIndex < 21 && Index.levelIndex > 15)
        {
            burner.startLifetime = 2f;
        }
        else if (Index.levelIndex < 26 && Index.levelIndex > 19)
        {
            burner.startLifetime = 1f;
        }
    }
}
