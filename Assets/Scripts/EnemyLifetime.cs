using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class EnemyLifetime : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 5f;

    private Enemy _enemy;
    private Coroutine _lifeRoutine;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnDisable()
    {
        StopLifeRoutine();
    }

    public void StartTimer()
    {
        StopLifeRoutine();
        _lifeRoutine = StartCoroutine(LifeRoutine(_lifeTime));
    }

    private IEnumerator LifeRoutine(float lifeTime)
    {
        var wait = new WaitForSeconds(lifeTime);

        yield return wait;
        _enemy.Die();
        _lifeRoutine = null;
    }

    private void StopLifeRoutine()
    {
        if (_lifeRoutine != null)
        {
            StopCoroutine(_lifeRoutine);
            _lifeRoutine = null;
        }
    }
}