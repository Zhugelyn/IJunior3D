using UnityEngine;

[RequireComponent(typeof(Cube))]
public class ExplosionRadiusRenderer : MonoBehaviour
{
    private bool isMouseOver = false;

    void OnMouseOver()
    {
        isMouseOver = true;
    }

    void OnMouseExit()
    {
        isMouseOver = false;
    }

    void OnDrawGizmos()
    {
        Cube cube = gameObject.GetComponent<Cube>();

        if (isMouseOver)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, cube.explosionRadius);
        }
    }
}
