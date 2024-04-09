using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class CountdownTimer : MonoBehaviour
{
    public Text Instructions;
    public Text countdownText; // ������ �� ��������� ���� ��� ����������� �������
    public Text StartText;

    private void Start()
    {
        // ������������� TimeScale �� 0 ��� ������
        Time.timeScale = 0f;

        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        int timeLeft = 5; // ��������� �������� �������

        // ���� ���������� ����� ������ ��� ����� ����
        while (timeLeft >= 1)
        {
            // ���������� ������� ����� � ��������� ����
            countdownText.text = timeLeft.ToString();

            // ���� ���� �������
            yield return new WaitForSecondsRealtime(1f);

            // ��������� ���������� ����� �� ���� �������
            timeLeft--;
        }

        // ����� ���������� ��������� ������� ����� ��������� �����-���� ��������
        // ��������, ��������� �������, ������� ������ ����������� �� ���������� �������
        Debug.Log("����� �����!");
        countdownText.gameObject.SetActive(false);
        Instructions.gameObject.SetActive(false);
        StartText.gameObject.SetActive(true);
        Destroy(StartText, 0.4f);
        
        

        // �������� TimeScale �� 1 ����� ���������� ��������
        Time.timeScale = 1f;
    }
}
