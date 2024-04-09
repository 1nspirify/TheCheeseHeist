using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public GameObject Prefab;
    public Transform objectAppeared;
    public Transform StartPos;
    public Transform EndPos;

    public float DestroyTimer = 1.5f;
    public float ObjectSpeed = 1f;
    public float DelayAtEnd = 0.5f; // ���������� ��� �������� � EndPos

    private bool movingForward = true;
    private bool isWaiting = false; // ���� ��� ��������, ��������� �� ������ � ��������� ��������

    void Update()
    {
        if (isWaiting) return; // ���� ������ �������, �� ��������� ��������� ���

        Vector3 EndPosPoint = EndPos.localPosition;
        Vector3 StartPosPoint = StartPos.localPosition;
        Vector3 MousePoint = objectAppeared.localPosition;

        if (MousePoint.z >= EndPosPoint.z && movingForward)
        {
            StartCoroutine(WaitAtEnd());
        }
        else if (MousePoint.z <= StartPosPoint.z && !movingForward)
        {
            movingForward = true;
        }

        float moveSpeed = ObjectSpeed * Time.deltaTime;
        Vector3 moveDirection = movingForward ? Vector3.forward : Vector3.back;
        objectAppeared.Translate(moveDirection * moveSpeed);
        Destroy(Prefab, DestroyTimer);
    }

    IEnumerator WaitAtEnd()
    {
        isWaiting = true; // ������������� ���� ��������
        yield return new WaitForSeconds(DelayAtEnd); // ������� ������������� �����
        movingForward = false; // ������ ����������� ��������
        isWaiting = false; // ������� ���� ��������
    }
}