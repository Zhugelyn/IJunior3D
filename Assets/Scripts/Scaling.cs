using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaling : MonoBehaviour
{
    [SerializeField] private float _speedScaling;

    private float _scalingSlowdown = 5;

    private void Update()
    {
        Rescaling();
    }

    private void Rescaling()
    {
        Vector3 scale = transform.localScale; 
        scale.x += _speedScaling / _scalingSlowdown;
        scale.y += _speedScaling / _scalingSlowdown;
        scale.z += _speedScaling / _scalingSlowdown;

        transform.localScale = scale;
    }
}
