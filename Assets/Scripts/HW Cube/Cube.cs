using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), 
    typeof(Collider),
    typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private SpawnCubes _spawnCubes;
    [SerializeField] private Explosion _explosion;

    private ChanceCalculator _chanceCalculator;

    public int _separationFactor = 1;
    private int _divisionMultiplier = 2;
    private float _scalingFactor = 2;

    private float _hueMin = 0f;
    private float _hueMax = 1f;

    public void Init(Cube previousCube)
    {
        var color = Random.ColorHSV(_hueMin, _hueMax);
        GetComponent<MeshRenderer>().material.color = color;

        var scale = transform.localScale;
        scale.x = previousCube.transform.localScale.x / _scalingFactor;
        scale.y = previousCube.transform.localScale.y / _scalingFactor;
        scale.z = previousCube.transform.localScale.z / _scalingFactor;
        transform.localScale = scale;

        _separationFactor = previousCube._separationFactor * _divisionMultiplier;
    }

    private void Awake()
    {
        _chanceCalculator = new ChanceCalculator();
    }

    private void OnMouseUpAsButton()
    {
        GetComponent<Collider>().enabled = false;

        if (_chanceCalculator.GetSuccessStatus(_separationFactor))
        {
            var cubes = _spawnCubes.CreateCubes(this);
            var rigidbodies = GetRigidbodies(cubes);
            var rigidbody = GetComponent<Rigidbody>();
            _explosion.Explode(rigidbody, rigidbodies);
        }

        Destroy(gameObject);
    }

    private List<Rigidbody> GetRigidbodies(List<Cube> cubes)
    {
        var rigidbodies = new List<Rigidbody>();

        foreach (var cube in cubes)
            rigidbodies.Add(cube.GetComponent<Rigidbody>());

        return rigidbodies;
    }
}