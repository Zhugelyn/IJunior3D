using UnityEngine;

public class CubeExplosion : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    [SerializeField] private Ray _ray;
    [SerializeField] private float _maxDistance = 10f;
    [SerializeField] private float _radius = 0.1f;

    [SerializeField] private GameObject _prefab;

    private void Update()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
            {
                var obj = hit.collider.gameObject.name;
                if (hit.collider.TryGetComponent(out Cube cube))
                {
                    Destroy(cube.gameObject);
                    CreateCubes(hit.transform);
                    Debug.Log(transform.position);
                }
                Debug.Log(obj);
            }
        }
    }

    private void CreateCubes(Transform transform)
    {
        var rnd = Random.Range(2, 6);

        for (int i = 0; i < rnd; i++)
        {
            var cube = Instantiate(_prefab, transform);
            var scale = cube.transform.localScale;
            scale.x /= 2;
            scale.y /= 2;
            scale.z /= 2;
            cube.transform.localScale = scale;
        }
    }
}
