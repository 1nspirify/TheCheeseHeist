using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public GameObject Mouse;
    public GameObject StartPos;
    public GameObject EndPos;

    void Update()
    {
        // ����������� ������� Mouse ������
        Mouse.transform.localPosition += Vector3.forward * Time.deltaTime;

        // ��������, ������ �� ������ Mouse ������� EndPos
        if (Mouse.transform.position.z >= EndPos.transform.position.z)
        {
            // ���� ������, �������� ����������� �� ��������
            Mouse.transform.forward = -Mouse.transform.forward;
        }

        // ��������, ������ �� ������ Mouse ������� StartPos
        if (Mouse.transform.position.z < StartPos.transform.position.z)
        {
            // ���� ������, ����� �������� ����������� �� ������
            Mouse.transform.forward = Vector3.forward;
        }
    }
}