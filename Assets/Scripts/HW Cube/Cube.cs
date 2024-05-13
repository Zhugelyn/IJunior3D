using UnityEngine;

class Cube : MonoBehaviour
{
    [SerializeField] private SpawnCubes _spawnCubes;
    [SerializeField] private Explosion _explosion;

    private static int _attemptNumber = 0;
    private ChanceCalculator _chanceCalculator;

    private void Awake()
    {
        _chanceCalculator = new ChanceCalculator();
    }

    private void OnMouseUpAsButton()
    {
        SetPropertiesForTheSelectedCube();

        if (_chanceCalculator.GetSuccessStatus(_attemptNumber))
        {
            _spawnCubes.CreateCubes(transform);
            _explosion.Explode(gameObject);
        }

        _attemptNumber++;
    }

    private void SetPropertiesForTheSelectedCube()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
    }
}