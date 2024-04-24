using System.Collections.Generic;
using UnityEngine;

public class CubeCreator : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private int _minCountClone = 2;
    private int _maxCountClone = 6;

    public List<Cube> CreatCubes(Cube cubeParent)
    {
        List<Cube> cubes = new List<Cube>();

        int cloneCount = Random.Range(_minCountClone, _maxCountClone + 1);

        for (int i = 0; i < cloneCount; i++)
        {
            Cube cube = Instantiate(_cubePrefab, cubeParent.transform.position, Quaternion.identity);
            cube.OnSpawn(cubeParent.ChanceClone, cubeParent.transform.localScale, cubeParent.Explosion.RadiusExplosion, cubeParent.Explosion.ForceExplosion);
            cubes.Add(cube);
        }

        return cubes;
    }
}
