using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    [SerializeField] private float _radiusExplosion;
    [SerializeField] private float _forceExplosion;

    private string _maskCubeName = "Cube";
    private float _multiplierExplosion = 1.3f;

    public float RadiusExplosion => _radiusExplosion;
    public float ForceExplosion => _forceExplosion;

    public void StartExplosion(Vector3 parentPosition)
    {
        foreach (Cube cube in GetNearCubes(parentPosition))
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

    private List<Cube> GetNearCubes(Vector3 parentPosition)
    {
        Collider[] hits = Physics.OverlapSphere(parentPosition, _radiusExplosion, LayerMask.GetMask(_maskCubeName));

        List<Cube> cubes = new List<Cube>();

        foreach (Collider hit in hits)
        {
            cubes.Add(hit.GetComponent<Cube>());
        }

        return cubes;
    }

    private float GetNormilizeDistance(Cube cube)
    {
        float distance = Vector3.Distance(transform.position, cube.transform.position);
        return Mathf.InverseLerp(0, _radiusExplosion, distance);
    }
}
