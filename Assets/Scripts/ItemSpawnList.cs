using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnList : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // ������ �������� ��� ������
    public Transform[] spawnPoints; // ����� ��������
    public float[] spawnChances; // ����������� ��������� ��� ������� �������
    public float spawnTimeMin = 1f; // ����������� ����� ����� ��������
    public float spawnTimeMax = 5f; // ������������ ����� ����� ��������

    private int lastSpawnPointIndex = -1; // ������ ��������� ����� ��������

    private void Start()
    {
        Invoke("SpawnObject", Random.Range(spawnTimeMin, spawnTimeMax));
    }

    private void SpawnObject()
    {
        if (objectsToSpawn.Length != spawnChances.Length)
        {
            Debug.LogError("������: ������� objectsToSpawn � spawnChances ������ ���� ���������� �����!");
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

        // ���������, ����� ����� ����� �������� �� ��������� � ��������� ��������������
        while (spawnPointIndex == lastSpawnPointIndex)
        {
            spawnPointIndex = Random.Range(0, spawnPoints.Length);
        }

        lastSpawnPointIndex = spawnPointIndex; // ��������� ��������� �������������� ����� ��������

        Vector3 spawnDirection = spawnPoints[spawnPointIndex].forward; // �������� ����������� �� ��� Z �� ����� ��������
        Instantiate(objectsToSpawn[objectIndex], spawnPoints[spawnPointIndex].position, Quaternion.LookRotation(spawnDirection));

        Invoke("SpawnObject", Random.Range(spawnTimeMin, spawnTimeMax));
    }
}