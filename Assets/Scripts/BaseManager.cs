using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class BaseManager : MonoBehaviour
{
    public virtual void Initialize()
    {
        Debug.Log("BaseManager initialized.");
    }

    public void LogMessage(string message)
    {
        Debug.Log(message);
    }
}
