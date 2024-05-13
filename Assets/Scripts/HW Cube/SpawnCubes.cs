using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    private float _scalingFactor = 2;

    public void CreateCubes(Transform transform)
    {
        int countCubes = Random.Range(2, 6);

        for (int i = 0; i < countCubes; i++)
        {
            var color = Random.ColorHSV(0, 1);
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
