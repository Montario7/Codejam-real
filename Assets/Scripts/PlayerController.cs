using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : ControllerBase
{
    public float moveSpeed = 5f; // Speed of the player movement
    private Rigidbody2D rb;
    private bool useAccelerometer;
    private bool useGyroscope;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Check once if the device has an accelerometer or gyroscope
        useAccelerometer = SystemInfo.supportsAccelerometer;
        useGyroscope = SystemInfo.supportsGyroscope;

        if (!useAccelerometer && !useGyroscope)
        {
            Debug.LogError("No accelerometer or gyroscope found.");
        }
    }

    void Update()
    {
        Vector2 movement = Vector2.zero;

        if (useAccelerometer)
        {
            // Use accelerometer input for movement
            float moveHorizontal = Input.acceleration.x;
            float moveVertical = Input.acceleration.y;
            movement += new Vector2(moveHorizontal, moveVertical); // Combine if both are used
        }

        if (useGyroscope)
        {
            // Use gyroscope input for movement
            float moveHorizontal = Input.gyro.rotationRateUnbiased.x;
            float moveVertical = Input.gyro.rotationRateUnbiased.y;
            movement += new Vector2(moveHorizontal, moveVertical); // Combine if both are used
        }

        if (movement != Vector2.zero)
        {
            rb.velocity = movement * moveSpeed;

            // Play sound when player moves
            SoundManager.instance.PlaySound();
        }
    }
}

