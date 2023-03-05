using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControls : MonoBehaviour
{

    [SerializeField] float controlSpeed = 10f;
     // Update is called once per frame
    void Update()
    {
        

        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float yOffset = yThrow * Time.deltaTime * controlSpeed;

        float newXpos = transform.localPosition.x + xOffset;
        float newypos = transform.localPosition.y + yOffset;

        transform.localPosition = new Vector3 (newXpos, newypos ,transform.localPosition.z);
        
    }
}
