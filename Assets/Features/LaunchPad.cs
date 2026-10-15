using UnityEngine;

public enum Layers
{
    Default, Terrain, Launch
}

public class LaunchPad : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _range = 5f;

    private Vector3 _startPosition;
    private State _state = State.Idle;

    private enum State
    {
        Idle,
        Launching,
        Returning
    }

    private void Awake()
    {
        _startPosition = _rigidbody.position;
    }

    private void FixedUpdate()
    {
        switch (_state)
        {
            case State.Launching:
                if (Vector3.Distance(_rigidbody.position, _startPosition) >= _range)
                {
                    _state = State.Returning;
                    return;
                }

                _rigidbody.linearVelocity = transform.up * _speed;
                break;

            case State.Returning:
                Vector3 direction = _startPosition - _rigidbody.position;

                if (direction.magnitude <= _speed * 0.5f * Time.fixedDeltaTime)
                {
                    _rigidbody.position = _startPosition;
                    _rigidbody.linearVelocity = Vector3.zero;
                    _state = State.Idle;
                    return;
                }

                _rigidbody.linearVelocity = direction.normalized * (_speed * 0.5f);
                break;
        }
    }

    public bool TryLaunch()
    {
        if (_state != State.Idle)
            return false;

        _state = State.Launching;
        return true;
    }
}