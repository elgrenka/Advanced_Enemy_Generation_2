using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private float _spawnInterval = 2f;

    private Coroutine _spawnRoutine;

    private void OnEnable()
    {
        _spawnRoutine = StartCoroutine(SpawnRoutine(_spawnInterval));
    }

    private void OnDisable()
    {
        if (_spawnRoutine != null)
            StopCoroutine(_spawnRoutine);
    }

    private IEnumerator SpawnRoutine(float interval)
    {
        var wait = new WaitForSeconds(interval);

        while (enabled)
        {
            yield return wait;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        if (_spawnPoints == null || _spawnPoints.Length == 0)
            return;

        int randomIndex = Random.Range(0, _spawnPoints.Length);
        _spawnPoints[randomIndex].Spawn();
    }
}