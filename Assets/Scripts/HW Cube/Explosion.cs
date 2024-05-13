using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void Explode(GameObject gameObject)
    {
        gameObject.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, 
            gameObject.transform.position, 
            _explosionRadius);
    }
}
