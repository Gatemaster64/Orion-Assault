using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
     // script to instantiate enemy vfx and parent it under empty gameobject.

    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;

    ScoreBoard scoreBoard;

    void Start()
        // Find first object in project named scoreboard.
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

     void OnParticleCollision(GameObject other)
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }
}
