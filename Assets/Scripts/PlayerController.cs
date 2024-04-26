using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player movement
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the device has an accelerometer
        if (SystemInfo.supportsAccelerometer)
        {
            // Use accelerometer input for movement
            float moveHorizontal = Input.acceleration.x;
            float moveVertical = Input.acceleration.y;

            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            rb.velocity = movement * moveSpeed;
        }
        // Check if the device has a gyroscope (if accelerometer is not available)
        else if (SystemInfo.supportsGyroscope)
        {
            // Use gyroscope input for movement
            float moveHorizontal = Input.gyro.rotationRateUnbiased.x;
            float moveVertical = Input.gyro.rotationRateUnbiased.y;

            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            rb.velocity = movement * moveSpeed;
        }
        else
        {
            Debug.LogError("No accelerometer or gyroscope found.");
        }
    }
}

