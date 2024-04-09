using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnList : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // массив объектов дл€ спавна
    public Transform[] spawnPoints; // точки респавна
    public float[] spawnChances; // веро€тности по€влени€ дл€ каждого объекта
    public float spawnTimeMin = 1f; // минимальное врем€ между спавнами
    public float spawnTimeMax = 5f; // максимальное врем€ между спавнами

    private int lastSpawnPointIndex = -1; // »ндекс последней точки респавна

    private void Start()
    {
        Invoke("SpawnObject", Random.Range(spawnTimeMin, spawnTimeMax));
    }

    private void SpawnObject()
    {
        if (objectsToSpawn.Length != spawnChances.Length)
        {
            Debug.LogError("ќшибка: массивы objectsToSpawn и spawnChances должны быть одинаковой длины!");
            return;
        }

        float totalChance = 0f;
        foreach (var chance in spawnChances)
        {
            totalChance += chance;
        }

        float randomPoint = Random.Range(0, totalChance);
        int objectIndex = 0;

        for (float currentChance = spawnChances[0]; objectIndex < spawnChances.Length - 1; objectIndex++)
        {
            if (randomPoint < currentChance)
                break;

            currentChance += spawnChances[objectIndex + 1];
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // ѕровер€ем, чтобы нова€ точка респавна не совпадала с последней использованной
        while (spawnPointIndex == lastSpawnPointIndex)
        {
            spawnPointIndex = Random.Range(0, spawnPoints.Length);
        }

        lastSpawnPointIndex = spawnPointIndex; // ќбновл€ем последнюю использованную точку респавна

        Vector3 spawnDirection = spawnPoints[spawnPointIndex].forward; // ѕолучаем направление по оси Z от точки респавна
        Instantiate(objectsToSpawn[objectIndex], spawnPoints[spawnPointIndex].position, Quaternion.LookRotation(spawnDirection));

        Invoke("SpawnObject", Random.Range(spawnTimeMin, spawnTimeMax));
    }
}