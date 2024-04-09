using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TimeSpeedUp : MonoBehaviour
{
    public GameObject Boost;
    private float originalTimeScale;
    [SerializeField] private float countdown = 7.5f;
    public float TimeScale =1.95f;

    public void TimeBooster()
    {
        originalTimeScale = Time.timeScale;
        Invoke(nameof(BoostTime),0f);
    }

    private void BoostTime()
    {
        Time.timeScale = TimeScale;
        Boost.SetActive(true);
        StartCoroutine(RestoreTime());
    }

    private IEnumerator RestoreTime()
    {
        yield return new WaitForSeconds(7.5f); // ∆дем 7.5секунду
        Time.timeScale = originalTimeScale;
        Boost.SetActive(false);
    }
}
