using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string Speed = "Speed";
    private readonly string Horizontal = "Horizontal";
    private readonly string Vertical = "Vertical";

    [SerializeField] private float _speed = 5f;
    [SerializeField] private Animator _animator;

    private void Update()
    {
        if (_animator != null)
            _animator.SetFloat(Speed, _speed);
        Vector3 direction = new Vector3(Input.GetAxis(Horizontal), 0f, Input.GetAxis(Vertical));

        transform.Translate(_speed * Time.deltaTime * direction);
    }
}
