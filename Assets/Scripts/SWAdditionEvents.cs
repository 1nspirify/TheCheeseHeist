using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWAdditionEvents : MonoBehaviour
{
    // Reference to TimeSpeedUp
    public TimeSpeedUp _timeSpeedUp;

    private void Start()
    {
        _timeSpeedUp = FindObjectOfType<TimeSpeedUp>();
    }

    // Override the HandleObjectTapped method
    public void HandleObjectTapped()
    {

        _timeSpeedUp.TimeBooster();
    }
}
