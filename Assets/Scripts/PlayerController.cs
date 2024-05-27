using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class PlayerController : BaseManager
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Initialize(); // Call the base class initialization
    }

    void Update()
    {
        if (SystemInfo.supportsAccelerometer)
        {
            float moveHorizontal = Input.acceleration.x;
            float moveVertical = Input.acceleration.y;

            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            rb.velocity = movement * moveSpeed;
        }
        else if (SystemInfo.supportsGyroscope)
        {
            float moveHorizontal = Input.gyro.rotationRateUnbiased.x;
            float moveVertical = Input.gyro.rotationRateUnbiased.y;

            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            rb.velocity = movement * moveSpeed;
        }
        else
        {
            LogMessage("No accelerometer or gyroscope found."); // Use the base class method
        }
    }

    public override void Initialize()
    {
        base.Initialize();
        Debug.Log("PlayerController initialized.");
    }
}
