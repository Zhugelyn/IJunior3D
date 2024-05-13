using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    private float _scalingFactor = 2;

    private int _minCount = 2;
    private int _maxCount = 6;
    private float _hueMin = 0f;
    private float _hueMax = 1f;

    public void CreateCubes(Transform transform)
    {
        int countCubes = Random.Range(_minCount, _maxCount);

        for (int i = 0; i < countCubes; i++)
        {
            var color = Random.ColorHSV(_hueMin, _hueMax);
            var cube = Instantiate(_prefab, transform.position, Quaternion.identity);
            cube.GetComponent<MeshRenderer>().material.color = color;

            var scale = cube.transform.localScale;
            scale.x = transform.localScale.x / _scalingFactor;
            scale.y = transform.localScale.y / _scalingFactor;
            scale.z = transform.localScale.z / _scalingFactor;

            cube.transform.localScale = scale;
        }
    }
}
