using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHAndler : MonoBehaviour
{
  [SerializeField] float loadDelay = 1f;
    
    void OnTriggerEnter(Collider other) 
    {
    StartCrashSequence();    
    }
    void StartCrashSequence()
    {
   GetComponent<PlayerController>().enabled = false;
        Invoke("ReloadLevel", loadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
