using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float SpawnDelay = 2;
    public int MaxEnemiesCount = 10;

    public List<Enemy> EnemyPrefabs = new List<Enemy>();
    public List<Enemy> InstntiatedEnemies = new List<Enemy>();

    public GameObject EnemyHUDPrefab;
    public Vector3 EnemyHUDOffset = new Vector3(0, 1.2f, 0);

    void Start()
    {
        StartCoroutine(SpawnIEnumerator());
    }

    private IEnumerator SpawnIEnumerator()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnDelay);
            if (InstntiatedEnemies.Count < MaxEnemiesCount)
                Spawn();
        }
    }

    private void Spawn()
    {
     
        float randomAngle = Random.Range(0, 360);
        Vector3 randomPosition = new Vector3(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad));
        randomPosition *= GameSettings.Instance.WorldSize.magnitude / 2;

        int nextItemIndex = InstntiatedEnemies.Count < EnemyPrefabs.Count ? InstntiatedEnemies.Count : 0;
        var enemy = Instantiate(EnemyPrefabs[nextItemIndex], randomPosition, Quaternion.identity);
        InstntiatedEnemies.Add(enemy);

        var hud = Instantiate(EnemyHUDPrefab, randomPosition + EnemyHUDOffset, Quaternion.identity, enemy.transform);
        hud.GetComponentInChildren<HUDPanel>().Enemy = enemy;
    }
}
