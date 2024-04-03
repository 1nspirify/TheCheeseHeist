using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatchRotation : MonoBehaviour
{
    [SerializeField] private Transform _arrow;
    [SerializeField] private Transform _bigArrow;
    public float Speed = 45f;
    public float FasterSpeed = 180f;

    private float _currentRotationY = 0f; // ����������� ���� �������� �� ��� Y

    void Update()
    {
        // ����������� ����������� ���� �������� �� ��� Y
        _currentRotationY += Speed * Time.deltaTime;

        // ��������� ���� �������� � ��������
        _arrow.eulerAngles = new Vector3(0f, _currentRotationY, 0f);
        _bigArrow.eulerAngles = new Vector3(0f, _currentRotationY * FasterSpeed / Speed, 0f);
    }
}
