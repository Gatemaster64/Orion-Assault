using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    // script to destroy the vfx after certain amount of time.
    // script need to be applied to the object to destroy.


    [SerializeField] float timeTillDestroy = 3f;
    void Start()
    {
        Destroy(gameObject, timeTillDestroy);
    }
}
