using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawn : MonoBehaviour
{
    public GameObject asteroid1;
    public GameObject asteroid2;
    public GameObject asteroid3;
    public GameObject stars;

    float asteroidDis1;
    float asteroidDis2;
    float asteroidDis3;
    float starDist;

    public float aSpawnTime1 = 6.0f;
    public float aSpawnTime2 = 2.0f;
    public float aSpawnTime3 = 2.0f;
    public float starSpawnTime = 3f;

    void Start()
    {
        StartCoroutine(Spawn1());
        // StartCoroutine(Spawn2());
        //StartCoroutine(Spawn3());

        StartCoroutine(starSpawn());
    }

    private void FixedUpdate()
    {
        asteroidDis1 = asteroidDis1 - 0.22f;
        asteroidDis2 = asteroidDis2 - 0.3f;
        asteroidDis3 = asteroidDis3 - 0.4f;
        starDist = starDist - 0.2f;
    }

    public void Spawner1()
    {
        GameObject astero1 = Instantiate(asteroid1);
        astero1.transform.localPosition = new Vector3(Random.Range(-14, 14), -asteroidDis1, 0);
    }

    IEnumerator Spawn1()
    {
        Spawner1();
        while (true)
        {
            yield return new WaitForSeconds(aSpawnTime1);
            Spawner1();
        }
    }


    /* public void Spawner2()
     {
         GameObject astero2 = Instantiate(asteroid2);
         astero2.transform.localPosition = new Vector3(Random.Range(-14, 14), -asteroidDis2, 0);
     }

     IEnumerator Spawn2()
     {
         Spawner2();
         while (true)
         {
             yield return new WaitForSeconds(aSpawnTime2);
             Spawner2();
         }
     }


     public void Spawner3()
     {
         GameObject astero3 = Instantiate(asteroid3);
         astero3.transform.localPosition = new Vector3(Random.Range(-14, 14), -asteroidDis3, 0);
     }

     IEnumerator Spawn3()
     {
         Spawner3();
         while (true)
         {
             yield return new WaitForSeconds(aSpawnTime3);
             Spawner3();
         }
     }*/

    public void StarSpawner()
    {
        GameObject star = Instantiate(stars);
        star.transform.localPosition = new Vector3(Random.Range(-14, 14), -starDist, 0);
    }

    IEnumerator starSpawn()
    {
        StarSpawner();
        while (true)
        {
            yield return new WaitForSeconds(starSpawnTime);
            StarSpawner();
        }
    }
}
