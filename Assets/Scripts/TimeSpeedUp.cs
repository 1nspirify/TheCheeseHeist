using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TimeSpeedUp : MonoBehaviour
{
    public GameObject Boost;
    private float originalTimeScale; // ��������� ������������ �������� timeScale
    [SerializeField] private float countdown = 7.5f; // �������� ������ �� 7.5 ������

    private void Start()
    {
        originalTimeScale = Time.timeScale; // ��������� ������������ �������� timeScale
    }

    public void TimeBooster()
    {
        // �������� ������
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
        }
        else
        {
            // �������� ����� � ������� ����
            Time.timeScale = 1.5f;
            Boost.SetActive(true);
        }

        // ��������������� ������������ �������� timeScale
        if (countdown <= 0 && Time.timeScale != originalTimeScale)
        {
            Time.timeScale = originalTimeScale;
            Boost.SetActive(false);
        }
    }
}
