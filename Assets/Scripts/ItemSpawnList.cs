using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnList : MonoBehaviour
{
    public List<GameObject> models; // ������ � ��������
    public List<Transform> spawnPoints; // ������ (spawn points)
    public float spawnInterval = 2f; // �������� ����� ���������� �������

    private void Start()
    {
        // ��������� �������� ��� ���������� ��������� �������
        StartCoroutine(SpawnRandomModel());
    }

    private IEnumerator SpawnRandomModel()
    {
        while (true)
        {
            // �������� ��������� ������ ������ (spawn point)
            Transform spawnPoint = GetRandomSpawnPoint();

            // ������� ��������� ������ �� ������
            GameObject randomModel = models[Random.Range(0, models.Count)];

            // ��������� ������ � ��������� �����
            Instantiate(randomModel, spawnPoint.position, spawnPoint.rotation);

            // ������ ��������� �������� �� ���������� ���������
            float randomSpawnInterval = Random.Range(spawnInterval * 0.5f, spawnInterval * 1.5f);
            yield return new WaitForSeconds(randomSpawnInterval);
        }
    }

    private Transform GetRandomSpawnPoint()
    {
        // �������� ��������� ������ �� ������ spawnPoints
        int randomIndex = Random.Range(0, spawnPoints.Count);

        return spawnPoints[randomIndex];
    }
}