using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    private EnemyMovement _movement;
    private EnemyLifetime _lifetime;

    public event Action<Enemy> Death;

    private void Awake()
    {
        _movement = GetComponent<EnemyMovement>();
        _lifetime = GetComponent<EnemyLifetime>();
    }

    public void Initialize(Transform target)
    {
        _movement.SetTarget(target);
        _lifetime.StartTimer();
    }

    public void Die()
    {
        Death?.Invoke(this);
    }
}