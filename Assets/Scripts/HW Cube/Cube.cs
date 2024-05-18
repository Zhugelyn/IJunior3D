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

    private int _increaseExplosionForce = 200;
    private int _increasieExplosionRadius = 1;

    public float SeparationFactor { get; private set; }
    public int MaxExplosionForce { get; private set; }
    public int ExplosionRadius { get; private set; }

    public void Init(Cube previousCube)
    {
        var color = Random.ColorHSV(_hueMin, _hueMax);
        GetComponent<MeshRenderer>().material.color = color;

        var scale = previousCube.transform.localScale / _scalingFactor;
        transform.localScale = scale;

        SeparationFactor = previousCube.SeparationFactor / _divisionMultiplier;
        MaxExplosionForce = previousCube.MaxExplosionForce + _increaseExplosionForce;
        ExplosionRadius = previousCube.ExplosionRadius + _increasieExplosionRadius;
    }

    private void Awake()
    {
        MaxExplosionForce = 400;
        ExplosionRadius = 2;

        SeparationFactor = 100;
    }

    private void OnMouseUpAsButton()
    {
        if (ChanceCalculator.GetSuccessStatus(SeparationFactor))
        {
            var cubes = _spawnCubes.CreateCubes(this);
            _explosion.Explode(transform.position, cubes);
        }

        _explosion.Explode(transform.position, ExplosionRadius, MaxExplosionForce);

        Destroy(gameObject);
    }
}