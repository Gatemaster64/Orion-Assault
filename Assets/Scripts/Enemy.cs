using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
     // script to instantiate enemy vfx and parent it under empty gameobject.

    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 15;

    [SerializeField] int maxHealth = 4; // The maximum health of the enemy
    int currentHealth; // The current health of the enemy


    ScoreBoard scoreBoard;


    void Start()
        // Find first object in project named scoreboard.
    {
        currentHealth = maxHealth; // set the current health to the maximum health at the start
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

     void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        

    }

    void ProcessHit()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        currentHealth -= 1; // reduce the current health by 1 when hit by the player
        if (currentHealth <= 0)
        {
            KillEnemy(); // if the current health is less than or equal to 0, call the KillEnemy method
        }
        scoreBoard.IncreaseScore(scorePerHit);
    }

    void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }

    
}
