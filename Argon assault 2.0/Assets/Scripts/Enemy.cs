using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitpoint = 2;

    Scoreboard scoreBoard;

     void Start() 
    {
        scoreBoard = FindObjectOfType<Scoreboard>();    
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
        vfx.transform.parent = parent;
        Destroy(gameObject);
        hitpoint--;
        scoreBoard.IncreaseScore(scorePerHit);
      
    }

      void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }


}
