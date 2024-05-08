using UnityEngine;

public class Movement : MonoBehaviour
{
    private const string Speed = "Speed";

    [SerializeField] private float _speed = 5f;
    [SerializeField] private Animator _animator;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_animator != null)
            _animator.SetFloat(Speed, _speed);
        transform.Translate(transform.forward * _speed * Time.deltaTime);
    }
}
