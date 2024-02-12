using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(transform.forward * _speed * Time.deltaTime);
    }
}
