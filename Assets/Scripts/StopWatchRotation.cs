using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatchRotation : MonoBehaviour
{
    [SerializeField] private Transform _arrow;
    [SerializeField] private Transform _bigArrow;
    public float Speed = 45f;
    public float FasterSpeed = 180f;

    private float _currentRotationY = 0f; // Ќакопленный угол вращени€ по оси Y

    void Update()
    {
        // ”величиваем накопленный угол вращени€ по оси Y
        _currentRotationY += Speed * Time.deltaTime;

        // ѕримен€ем угол вращени€ к стрелкам
        _arrow.eulerAngles = new Vector3(0f, _currentRotationY, 0f);
        _bigArrow.eulerAngles = new Vector3(0f, _currentRotationY * FasterSpeed / Speed, 0f);
    }
}
