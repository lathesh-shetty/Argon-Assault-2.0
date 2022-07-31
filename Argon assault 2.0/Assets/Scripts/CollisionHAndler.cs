using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHAndler : MonoBehaviour
{
  [SerializeField] float loadDelay = 1f;
  [SerializeField] ParticleSystem crashVFX;

    
    void OnTriggerEnter(Collider other) 
    {
    StartCrashSequence();    
    }
    void StartCrashSequence()
    {
        crashVFX.Play();
        GetComponent<PlayerController>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;

        Invoke("ReloadLevel", loadDelay);
       
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
