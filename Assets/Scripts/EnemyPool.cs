using UnityEngine;
using System.Collections.Generic;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private int _initialPoolSize = 5;

    private Queue<Enemy> _pool = new();

    private void Awake()
    {
        for (int i = 0; i < _initialPoolSize; i++)
        {
            CreateEnemy();
        }
    }

    public Enemy GetEnemy()
    {
        if (_pool.Count == 0)
            CreateEnemy();

        return _pool.Dequeue();
    }

    public void ReturnEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
        _pool.Enqueue(enemy);
    }

    private void CreateEnemy()
    {
        Enemy enemy = Instantiate(_enemyPrefab, transform);
        enemy.gameObject.SetActive(false);
        _pool.Enqueue(enemy);
    }
}