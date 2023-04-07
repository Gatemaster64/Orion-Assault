using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Enemy : MonoBehaviour
{
     // script to instantiate enemy vfx and parent it under empty gameobject.

    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int scorePerHit = 15;

    [SerializeField] int maxHealth = 4; // The maximum health of the enemy
    int currentHealth; // The current health of the enemy

    // Member variable for scoreboard and parentGameObject.
    // The Gameobject "SpawnAtRuntime" is used as the parent of the spawned vfx particles.
    ScoreBoard scoreBoard;
    GameObject parentGameObject;


    void Start()
    // Find first object in project named scoreboard.
    {

        currentHealth = maxHealth; // set the current health to the maximum health at the start
        scoreBoard = FindObjectOfType<ScoreBoard>();
        // Assign the SpawnAtRuntime GameObject as the parent GameObject.
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidBody();
    }

    void AddRigidBody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        // Sets the parent of the Transform component of vfx to the Transform component of parentGameObject 
        vfx.transform.parent = parentGameObject.transform;


        currentHealth -= 1; // reduce the current health by 1 when hit by the player
        if (currentHealth <= 0)
        {
            KillEnemy(); // if the current health is less than or equal to 0, call the KillEnemy method
        }
        
    }

    void KillEnemy()
    {
        scoreBoard.IncreaseScore(scorePerHit);
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);

        // Sets the parent of the Transform component of vfx to the Transform component of parentGameObject 
        vfx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
    }

    
}
