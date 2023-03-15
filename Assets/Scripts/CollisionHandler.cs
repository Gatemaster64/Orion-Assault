using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem crashVFX;

    ParticleSystem parSystem;

    bool isTransitioning = false;
    bool collisionDisabled = false;

    void Start()
    {
        parSystem = GetComponent<ParticleSystem>();
    }




    void OnTriggerEnter(Collider other)
    {

        if (isTransitioning || collisionDisabled) { return; }

        StartCrashSequence();
        //Debug.Log($"{this.name}**Triggered by **{other.gameObject.name}");  
    }


    void StartCrashSequence()
    {
        isTransitioning = true;
        crashVFX.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<PlayerControls>().enabled = false;
        Invoke("ReloadLevel", loadDelay);
    }


    void ReloadLevel()
    {
        int currentSceneIndex = (SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(currentSceneIndex);
    }



}
