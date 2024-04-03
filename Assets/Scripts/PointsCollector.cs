using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class PointsCollector : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI PointsCollectorText;

    public int Points = 0;
    public int GreyMouse;
    public int BlackMouse;
    public int WhiteMouse;

    // Start is called before the first frame update
    void Start()
    {
        PointsCollectorText.text = "POINTS: " + Points.ToString();
    }

 
    public void PointsAdd()
    {
        Points += BlackMouse; 
    }

    public void PointsRemove()
    {
        Points -= WhiteMouse;
    }
}
