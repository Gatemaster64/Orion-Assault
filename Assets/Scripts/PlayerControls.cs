using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControls : MonoBehaviour
{
    // variables for adjusting controlspeed and range to constrain movement.

    [SerializeField] float controlSpeed = 8f;

    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 7f;

    // Declaring an array for the lasers.
    [SerializeField] GameObject[] lasers;


    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;

    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlRollFactor = -20f;

    // Declaring variables for xthrow and ythrow.
    float xThrow;
    float yThrow;



    void Update()
    {
        // variables to get the Horizontal & Vertical input

        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessRotation()
    {
        // Get the pitch,yaw & roll and adjusting it based on the position & player input.

        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;

        float rollDueToControlThrow = xThrow * controlRollFactor;


        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = yawDueToPosition;
        float roll = rollDueToControlThrow;
        transform.localRotation = Quaternion.Euler(xRange - pitch, yaw, roll);
    }




    void ProcessTranslation()

    // Use variiables to get the player input.
    // Adjust the player movement by Time.deltaTime & Controlspeed variable
    // Also use clampedPos variable to constrain the movement.
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessFiring()
    {
        // if pushing fire button
        // then print shooting
        // else don't print shooting

        if (Input.GetButton("Fire1"))
        {
            SetLasersActive(true);
        }

        else
        {
            SetLasersActive(false);
        }


    }

    void SetLasersActive(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
}
