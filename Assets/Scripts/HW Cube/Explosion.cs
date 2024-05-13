using UnityEngine;
using System.Collections.Generic;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void Explode(GameObject gameObject)
    {
        foreach (var item in GetExplodableObjects(gameObject.transform.position))
            item.AddExplosionForce(_explosionForce,
                gameObject.transform.position,
                _explosionRadius);

        Debug.Log("Explode");
    }

    private List<Rigidbody> GetExplodableObjects(Vector3 position)
    {
        Collider[] hits = Physics.OverlapSphere(position, _explosionRadius);

        var cubes = new List<Rigidbody>();

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent(out Cube cube) && hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);
        }

        return cubes;
    }
}
