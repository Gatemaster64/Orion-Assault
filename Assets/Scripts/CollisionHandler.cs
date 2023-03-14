using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 1f;
    private void OnCollisionEnter (Collision other)
    // When colliding with something get information of the other object collided with 
    {
        StartCrashSequence();
        //Debug.Log(this.name + "--Collided with--" + other.gameObject.name);
    }
    
    void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
        //Debug.Log($"{this.name}**Triggered by **{other.gameObject.name}");  
    }


    void StartCrashSequence()
    {
        GetComponent<PlayerControls>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }


    void ReloadLevel()
    {
        int currentSceneIndex = (SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(currentSceneIndex);
    }



}
