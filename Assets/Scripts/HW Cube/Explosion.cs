using UnityEngine;
using System.Collections.Generic;

public class Explosion : MonoBehaviour
{
    private float _minExplosionForce = 0;

    public void Explode(Vector3 explosionPosition, float explosionRadius, float maxExplosionForce)
    {
        foreach (var item in GetExplodableObjects(explosionPosition, explosionRadius))
        {
            var explosionForce = CalculateExplosionForceFromDistance(explosionPosition,
                item.transform.position,
                explosionRadius,
                maxExplosionForce);

            item.AddExplosionForce(explosionForce, explosionPosition, explosionRadius);
        }
    }

    public void Explode(Vector3 explosionPosition, List<Cube> cubes)
    {
        foreach (var cube in cubes)
        {
            var rigidbody = cube.GetComponent<Rigidbody>();
            var explosionForce = CalculateExplosionForceFromDistance(explosionPosition,
                                                                cube.transform.position,
                                                                cube.ExplosionRadius,
                                                                cube.MaxExplosionForce);

            rigidbody.AddExplosionForce(explosionForce, explosionPosition, cube.ExplosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObjects(Vector3 position, float explosionRadius)
    {
        Collider[] hits = Physics.OverlapSphere(position, explosionRadius);

        var cubes = new List<Rigidbody>();

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent(out Cube cube) && hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);
        }

        return cubes;
    }

    private float CalculateExplosionForceFromDistance(Vector3 firstPostion,
        Vector3 secondPosition,
        float explosionRadius,
        float maxExplosionForce)
    {
        var distance = Mathf.Abs(Vector3.Distance(firstPostion, secondPosition));

        if (distance == 0)
            return maxExplosionForce;

        var delta = 1 - (distance / explosionRadius);

        return Mathf.Lerp(_minExplosionForce, maxExplosionForce, delta);
    }
}
