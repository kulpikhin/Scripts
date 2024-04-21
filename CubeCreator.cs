using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCreator : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private int _minCLone = 2;
    private int _maxCLone = 6;

    public List<Cube> CreatCubes(Cube cubeParent)
    {
        List<Cube> cubes = new List<Cube>();

        int cloneCount = Random.Range(_minCLone, _maxCLone + 1);

        for (int i = 0; i < cloneCount; i++)
        {
            Cube cube = Instantiate(_cubePrefab, cubeParent.transform.position, Quaternion.identity);
            cube.OnSpawn(cubeParent.ChanceClone, cubeParent.transform.localScale);
            cubes.Add(cube);
        }

        return cubes;
    }
}
