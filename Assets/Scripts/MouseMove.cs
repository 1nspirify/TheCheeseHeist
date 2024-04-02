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
        // Перемещение объекта Mouse вперед
        Mouse.transform.localPosition += Vector3.forward * Time.deltaTime;

        // Проверка, достиг ли объект Mouse позиции EndPos
        if (Mouse.transform.position.z >= EndPos.transform.position.z)
        {
            // Если достиг, изменяем направление на обратное
            Mouse.transform.forward = -Mouse.transform.forward;
        }

        // Проверка, достиг ли объект Mouse позиции StartPos
        if (Mouse.transform.position.z < StartPos.transform.position.z)
        {
            // Если достиг, снова изменяем направление на вперед
            Mouse.transform.forward = Vector3.forward;
        }
    }
}