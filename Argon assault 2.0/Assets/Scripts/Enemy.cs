using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitpoint = 2;


    Scoreboard scoreBoard;
    GameObject parentGameObject;

     void Start() 
    {
        scoreBoard = FindObjectOfType<Scoreboard>(); 
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidbody();

    }

   void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }


    void OnParticleCollision(GameObject other)
    {
       ProcessHit();
       if(hitpoint<1)
       {
       KillEnemy();
       }
    }
     void ProcessHit()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
        hitpoint--;
        scoreBoard.IncreaseScore(scorePerHit);
      
    }

      void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
    }


}
