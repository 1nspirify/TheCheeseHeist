using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemSpawnList : MonoBehaviour
{
    public List<GameObject> models; // —писок с модел€ми
    public List<Transform> spawnPoints; // —писок (spawn points)
    public float spawnInterval = 2f; // »нтервал между по€влением моделей

    private void Start()
    {
        // «апускаем корутину дл€ случайного по€влени€ моделей
        StartCoroutine(SpawnRandomModel());
    }

    private IEnumerator SpawnRandomModel()
    {
        while (true)
        {
            // ¬ыбираем случайный пустой объект (spawn point)
            Transform spawnPoint = GetRandomSpawnPoint();

            // ¬ыбираем случайный индекс модели на основе веро€тностей
            int randomModelIndex = PickOne(GetModelProbabilities());

            // —оздаем модель из списка с выбранным индексом
            GameObject randomModel = models[randomModelIndex];

            // ѕо€вление модели в выбранной точке
            Instantiate(randomModel, spawnPoint.position, spawnPoint.rotation);

            // «адаем случайный интервал до следующего по€влени€
            float randomSpawnInterval = Random.Range(spawnInterval * 0.5f, spawnInterval * 1.5f);
            yield return new WaitForSeconds(randomSpawnInterval);
        }
    }

    private Transform GetRandomSpawnPoint()
    {
        // ¬ыбираем случайный индекс из списка spawnPoints
        int randomIndex = Random.Range(0, spawnPoints.Count);
        return spawnPoints[randomIndex];
    }

    private float[] GetModelProbabilities()
    {
        // «десь вы можете задать веро€тности дл€ каждой модели
        // Ќапример, если у вас есть 4 модели, вы можете задать их веро€тности как {0.85f, 0.05f, 0.05f, 0.05f}
        // Ёто будет соответствовать 85% веро€тности дл€ первой модели и 5% дл€ каждой из остальных трех
        // ¬еро€тности должны суммироватьс€ до 1.0
        // ¬еро€тности можно настроить в соответствии с вашими требовани€ми
        // ¬озвращаем массив веро€тностей
        return new float[] { 0.85f, 0.85f, 0.05f, 0.05f };
    }

    private int PickOne(float[] prob)
    {
        int index = 0;
        float r = Random.value;
        while (r > 0)
        {
            r -= prob[index];
            index++;
        }
        index--;
        return index;
    }
}