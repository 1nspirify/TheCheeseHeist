using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;

public class StopWatchObjectInterAction : MonoBehaviour
{
    // ������� ������� ��� �������
    public event System.Action OnObjectTapped;

    private void OnEnable()
    {
        // ������������� �� ������� �������
        GetComponent<TapGesture>().Tapped += OnTapped;
    }

    private void OnDisable()
    {
        // ������������ �� ������� �������
        GetComponent<TapGesture>().Tapped -= OnTapped;
    }

    private void OnTapped(object sender, System.EventArgs e)
    {
        // �������� ������� �������
        OnObjectTapped?.Invoke();

    }
}
