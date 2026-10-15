using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Vector3[] _points;

    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _acceleration = 10f;
    [SerializeField] private float _arrivalDistance = 0.05f;

    [SerializeField] private bool _loop = true;

    private int _targetIndex;
    private int _direction = 1;

    private void FixedUpdate()
    {
        if (_points == null || _points.Length < 2)
            return;

        Vector3 target = _points[_targetIndex];
        Vector3 toTarget = target - _rigidbody.position;

        if (toTarget.sqrMagnitude <= _arrivalDistance * _arrivalDistance)
        {
            AdvanceTarget();

            target = _points[_targetIndex];
            toTarget = target - _rigidbody.position;
        }

        Vector3 goalVelocity = toTarget.normalized * _speed;

        _rigidbody.linearVelocity = Vector3.MoveTowards(
            _rigidbody.linearVelocity,
            goalVelocity,
            _acceleration * Time.fixedDeltaTime
        );
    }

    private void AdvanceTarget()
    {
        if (_loop)
        {
            _targetIndex = (_targetIndex + 1) % _points.Length;
            return;
        }

        _targetIndex += _direction;

        if (_targetIndex >= _points.Length)
        {
            _targetIndex = _points.Length - 2;
            _direction = -1;
        }
        else if (_targetIndex < 0)
        {
            _targetIndex = 1;
            _direction = 1;
        }
    }
}