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

    private void Awake()
    {
        _chanceCalculator = new ChanceCalculator();
    }

    private void OnMouseUpAsButton()
    {
        SetPropertiesValueForTheSelectedCube();

        if (_chanceCalculator.GetSuccessStatus(_separationFactor))
        {
            _spawnCubes.CreateCubes(this);
        }

        var rigidbody = GetComponent<Rigidbody>();
        _explosion.Explode(rigidbody);
    }

    private void SetPropertiesValueForTheSelectedCube()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
    }

    public void SetPropertiesValueTheNewCube(Cube previousCube)
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
}