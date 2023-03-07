using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControls : MonoBehaviour
{
    // variables for adjusting controlspeed and range to constrain movement.

    [SerializeField] float controlSpeed = 10f;

    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 7f;




    void Update()
    {
        // variables to get the Horizontal & Vertical input

        ProcessTranslation();
        ProcessRotation();
    }

     void ProcessRotation()
    {
        transform.localRotation = Quaternion.Euler(xRange - 30f, 30f, 0f);
    }




    void ProcessTranslation()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
