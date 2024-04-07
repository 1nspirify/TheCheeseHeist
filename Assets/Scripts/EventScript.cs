using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EventScript : MonoBehaviour
{
    public GameObject Effect;
    public List<Material> MaterialList; // List of materials to modify
   

    private void Start()
    {
       
        foreach (Material material in MaterialList)
        {
            // Set the alpha channel to 0
            Color color = material.color;
            color.a = 1f;
            material.color = color;
        }
        GetComponent<ObjectInterAction>().OnObjectTapped += HandleObjectTapped;
    }

    public void HandleObjectTapped()
    {

        // Iterate through each material in the list
        foreach (Material material in MaterialList)
        {
            // Set the alpha channel to 0
            Color color = material.color;
            color.a = 0f;
            material.color = color;
        }
        Instantiate(Effect, transform.position, Quaternion.identity);
       

    }
}