using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public Transform objectAppeared;
    public Transform StartPos;
    public Transform EndPos;
    public int Multiplier = 2; 

    // Добавим флаг, чтобы определить направление движения
    private bool movingForward = true;

    void Update()
    {
        Vector3 EndPosPoint = EndPos.localPosition;
        Vector3 StartPosPoint = StartPos.localPosition;
        Vector3 MousePoint = objectAppeared.localPosition;

        // Если объект достиг точки EndPos, меняем направление на обратное
        if (MousePoint.z >= EndPosPoint.z && movingForward)
        {
            movingForward = false;
        }
        // Если объект достиг точки StartPos, меняем направление на вперед
        else if (MousePoint.z <= StartPosPoint.z && !movingForward)
        {
            movingForward = true;
        }

        // Двигаем объект в зависимости от текущего направления
        float moveSpeed = 0.2f*Multiplier * Time.deltaTime;
        Vector3 moveDirection = movingForward ? Vector3.forward : Vector3.back;
        objectAppeared.Translate(moveDirection * moveSpeed);
    }
}