using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControls : MonoBehaviour
{
    [Header("General Setup Settings")]
    // variables for adjusting controlspeed and range to constrain movement.
    [Tooltip("How fast ship moves up and down based upon player input")]
    [SerializeField] float controlSpeed = 8f;
    [Tooltip("Set the range for how far the ship can go horizontally")]
    [SerializeField] float xRange = 10f;
    [Tooltip("Set the range for how far the ship can go vertically")]
    [SerializeField] float yRange = 7f;

    // Declaring an array for the lasers.
    [Header("Laser gun array")]
    [Tooltip("Add all player lasers here")]
    [SerializeField] GameObject[] lasers;



    [Header("Screen position based tuning")]
    [Tooltip("Field to change the amount the ship rotates up or down based upon the position")]
    [SerializeField] float positionPitchFactor = -2f;
    [Tooltip("Field to change the amount the ship rotates left or right based upon the position")]
    [SerializeField] float positionYawFactor = 2f;

    [Header("Player Input based tuning")]
    [Tooltip("Field to change the amount the ship rotates up or down based upon the player input")]
    [SerializeField] float controlPitchFactor = -10f;
    [Tooltip("Field to change the amount the ship rolls left or right based upon the player input")]
    [SerializeField] float controlRollFactor = -20f;

    // Declaring variables for xthrow and ythrow.
    float xThrow;
    float yThrow;



    void Update()
    {
        // variables to get the Horizontal & Vertical input & Firing input

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
        // then do the method to set lasers active, Else do the method to deactivate lasers.
        // Use bool true/false statement to check if the button is being pressed.

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

        // for each GameObject in the array lasers, do the underlying code.
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
}
