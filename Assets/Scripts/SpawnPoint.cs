using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private Transform _target;

    public void Spawn()
    {
        if (_enemyPool is null || _target is null)
            return;

        Enemy enemy = _enemyPool.GetEnemy();

        enemy.Death += OnEnemyDeath;
        enemy.gameObject.SetActive(true);
        enemy.transform.position = transform.position;
        enemy.Initialize(_target);
    }

    private void OnEnemyDeath(Enemy enemy)
    {
        enemy.Death -= OnEnemyDeath;
        _enemyPool.ReturnEnemy(enemy);
    }
}