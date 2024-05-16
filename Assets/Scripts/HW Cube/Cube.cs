using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), 
    typeof(Collider),
    typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private SpawnCubes _spawnCubes;
    [SerializeField] private Explosion _explosion;

    private int _divisionMultiplier = 2;
    private float _scalingFactor = 2;

    private float _hueMin = 0f;
    private float _hueMax = 1f;

    public int SeparationFactor { get; private set; }

    public void Init(Cube previousCube)
    {
        var color = Random.ColorHSV(_hueMin, _hueMax);
        GetComponent<MeshRenderer>().material.color = color;

        var scale = previousCube.transform.localScale / _scalingFactor;
        transform.localScale = scale;

        SeparationFactor = previousCube.SeparationFactor * _divisionMultiplier;
    }

    private void Awake()
    {
        SeparationFactor = 1;
    }

    private void OnMouseUpAsButton()
    {
        if (ChanceCalculator.GetSuccessStatus(SeparationFactor))
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