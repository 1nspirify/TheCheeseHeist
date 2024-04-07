using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EventScript : MonoBehaviour
{
    public GameObject Effect; 
    public Material ObjectMaterial; 
    private PointsCollector pointsCollector;

    private void Start()
    {
        pointsCollector = FindObjectOfType<PointsCollector>();
        ObjectMaterial.color = new Color(ObjectMaterial.color.r, ObjectMaterial.color.g, ObjectMaterial.color.b, 1f);
        GetComponent<ObjectInterAction>().OnObjectTapped += HandleObjectTapped;
    }

    public void HandleObjectTapped()
    {

        ObjectMaterial.color = new Color(ObjectMaterial.color.r, ObjectMaterial.color.g, ObjectMaterial.color.b, 0f);
        Instantiate(Effect, transform.position, Quaternion.identity);
        pointsCollector.PointsAdd();

    }
}