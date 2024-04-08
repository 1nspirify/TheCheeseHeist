using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiceAdditionEvents : MonoBehaviour
{
    // Reference to PointsCollector
    public PointsCollector _pointsCollector;

    private void Start()
    {
        _pointsCollector = FindObjectOfType<PointsCollector>();
        GetComponent<ObjectInterAction>().OnObjectTapped += HandleObjectTapped;
    }

    // Override the HandleObjectTapped method
    public void HandleObjectTapped()
    {
         _pointsCollector.PointsAdd();
    }
}
