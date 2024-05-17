using UnityEngine;
using System.Collections.Generic;

public class Explosion : MonoBehaviour
{
    private float _minExplosionForce = 0;

    public void Explode(Cube cube)
    {
        var rigidbody = cube.GetComponent<Rigidbody>();
        var position = rigidbody.transform.position;
        var explosionRadius = cube.ExplosionRadius;

        foreach (var item in GetExplodableObjects(position, explosionRadius))
        {

            var explosionForce = CalculateExplosionForceFromDistance(position,
                item.transform.position,
                explosionRadius,
                cube.MaxExplosionForce);

            item.AddExplosionForce(explosionForce, position, explosionRadius);
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
