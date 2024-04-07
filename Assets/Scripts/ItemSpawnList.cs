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

            // �������� ��������� ������ ������ �� ������ ������������
            int randomModelIndex = PickOne(GetModelProbabilities());

            // ������� ������ �� ������ � ��������� ��������
            GameObject randomModel = models[randomModelIndex];

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

    private float[] GetModelProbabilities()
    {
        // ����� �� ������ ������ ����������� ��� ������ ������
        // ��������, ���� � ��� ���� 4 ������, �� ������ ������ �� ����������� ��� {0.85f, 0.05f, 0.05f, 0.05f}
        // ��� ����� ��������������� 85% ����������� ��� ������ ������ � 5% ��� ������ �� ��������� ����
        // ����������� ������ ������������� �� 1.0
        // ����������� ����� ��������� � ������������ � ������ ������������
        // ���������� ������ ������������
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