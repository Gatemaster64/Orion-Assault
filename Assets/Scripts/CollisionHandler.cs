using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter (Collision other)
    // When colliding with something get information of the other object collided with 
    {
        Debug.Log(this.name + "--Collided with--" + other.gameObject.name);
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{this.name}**Triggered by **{other.gameObject.name}");  
    }

}
