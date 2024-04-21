using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{

    [SerializeField] private float _forceExplosion;

    public void StartExplosion(List<Cube> cubes, float radiusExplosion)
    {
        foreach(Cube cube in cubes)
        {
            cube.GetComponent<Rigidbody>().AddExplosionForce(_forceExplosion, transform.position, radiusExplosion);
        }
    }
}
