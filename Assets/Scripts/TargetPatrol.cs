using UnityEngine;

public class TargetPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private bool _loop = true;

    private int _currentWaypointIndex;

    private void Update()
    {
        if (_waypoints == null || _waypoints.Length == 0)
            return;

        Transform targetPoint = _waypoints[_currentWaypointIndex];

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPoint.position,
            _moveSpeed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
            UpdateWaypointIndex();
    }

    private void UpdateWaypointIndex()
    {
        _currentWaypointIndex++;

        if (_currentWaypointIndex >= _waypoints.Length)
        {
            if (_loop)
                _currentWaypointIndex = 0;
            else
                enabled = false;
        }
    }
}