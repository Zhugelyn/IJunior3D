using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float _speedRotation = 5f;

    private void Update()
    {
        RotateCube();
    }

    private void RotateCube()
    {
        transform.Rotate(Vector3.up, _speedRotation);
    }
}
