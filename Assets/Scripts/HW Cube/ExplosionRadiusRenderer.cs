using UnityEngine;

[RequireComponent(typeof(Cube))]
public class ExplosionRadiusRenderer : MonoBehaviour
{
    private bool _isMouseOver = false;

    void OnMouseOver()
    {
        _isMouseOver = true;
    }

    void OnMouseExit()
    {
        _isMouseOver = false;
    }

    void OnDrawGizmos()
    {
        Cube cube = gameObject.GetComponent<Cube>();

        if (_isMouseOver)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, cube.explosionRadius);
        }
    }
}
