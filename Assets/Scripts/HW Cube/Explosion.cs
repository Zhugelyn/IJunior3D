using UnityEngine;
using System.Collections.Generic;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 20f;
    [SerializeField] private float _explosionForce = 500;

    public void Explode(Rigidbody rigidbody, List<Rigidbody> explodableObjects)
    {
        foreach (var item in explodableObjects)
            item.AddExplosionForce(_explosionForce,
                rigidbody.transform.position,
                _explosionRadius);
    }

    #region Неиспользуемые методы, ждут следующего задания.
    public void Explode(Rigidbody rigidbody)
    {
        foreach (var item in GetExplodableObjects(rigidbody.transform.position))
            item.AddExplosionForce(_explosionForce,
                rigidbody.transform.position,
                _explosionRadius);
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

    #endregion
}
