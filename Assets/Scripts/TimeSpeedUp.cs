using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TimeSpeedUp : MonoBehaviour
{
    public GameObject Boost;
    private float originalTimeScale; // Сохраняем оригинальное значение timeScale
    [SerializeField] private float countdown = 7.5f; // Обратный отсчет на 7.5 секунд

    private void Start()
    {
        originalTimeScale = Time.timeScale; // Сохраняем оригинальное значение timeScale
    }

    public void TimeBooster()
    {
        // Обратный отсчет
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
        }
        else
        {
            // Ускоряем время в полтора раза
            Time.timeScale = 1.5f;
            Boost.SetActive(true);
        }

        // Восстанавливаем оригинальное значение timeScale
        if (countdown <= 0 && Time.timeScale != originalTimeScale)
        {
            Time.timeScale = originalTimeScale;
            Boost.SetActive(false);
        }
    }
}
