using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float loadDelay = 1f;
    
    
    void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
        //Debug.Log($"{this.name}**Triggered by **{other.gameObject.name}");  
    }


    void StartCrashSequence()
    {
        GetComponent<PlayerControls>().enabled = false;
        Invoke("ReloadLevel", loadDelay);
    }


    void ReloadLevel()
    {
        int currentSceneIndex = (SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(currentSceneIndex);
    }



}