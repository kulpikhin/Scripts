using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Explode : MonoBehaviour
{
    [SerializeField] private float _radiusExplosion;
    [SerializeField] private float _forceExplosion;

    private float _multiplierExplosion = 1.3f;

    public float RadiusExplosion => _radiusExplosion;
    public float ForceExplosion => _forceExplosion;

    public void StartExplosion(List<Cube> cubes)
    {
        foreach (Cube cube in cubes)
        {
            float normilizeDistance = 1 - GetNormilizeDistance(cube);

            if (normilizeDistance > 0)
                cube.GetComponent<Rigidbody>().AddExplosionForce(ForceExplosion * normilizeDistance, transform.position, _radiusExplosion);
        }
    }

    public void IncreaseExplosion(float radiusParenet, float forceParent)
    {
        _radiusExplosion = radiusParenet * _multiplierExplosion;
        _forceExplosion = forceParent * _multiplierExplosion;
    }

    private float GetNormilizeDistance(Cube cube)
    {
        float distance = Vector3.Distance(transform.position, cube.transform.position);
        return Mathf.InverseLerp(0, _radiusExplosion, distance);
    }
}
