using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnList : MonoBehaviour
{
    public List<GameObject> models; // Список с моделями
    public List<Transform> spawnPoints; // Список (spawn points)
    public float spawnInterval = 2f; // Интервал между появлением моделей

    private void Start()
    {
        // Запускаем корутину для случайного появления моделей
        StartCoroutine(SpawnRandomModel());
    }

    private IEnumerator SpawnRandomModel()
    {
        while (true)
        {
            // Выбираем случайный пустой объект (spawn point)
            Transform spawnPoint = GetRandomSpawnPoint();

            // Создаем случайную модель из списка
            GameObject randomModel = models[Random.Range(0, models.Count)];

            // Появление модели в выбранной точке
            Instantiate(randomModel, spawnPoint.position, spawnPoint.rotation);

            // Задаем случайный интервал до следующего появления
            float randomSpawnInterval = Random.Range(spawnInterval * 0.5f, spawnInterval * 1.5f);
            yield return new WaitForSeconds(randomSpawnInterval);
        }
    }

    private Transform GetRandomSpawnPoint()
    {
        // Выбираем случайный индекс из списка spawnPoints
        int randomIndex = Random.Range(0, spawnPoints.Count);

        return spawnPoints[randomIndex];
    }
}