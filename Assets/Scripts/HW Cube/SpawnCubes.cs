using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    [SerializeField] private Cube _prefab;

    private int _minCount = 2;
    private int _maxCount = 6;

    public List<Cube> CreateCubes(Cube selectedCube)
    {
        var cubes = new List<Cube>();
        int countCubes = Random.Range(_minCount, _maxCount);

        for (int i = 0; i < countCubes; i++)
        {
            var cube = Instantiate(_prefab, selectedCube.transform.position, Quaternion.identity);
            cube.Init(selectedCube);

            cubes.Add(cube);
        }

        return cubes;
    }
}
