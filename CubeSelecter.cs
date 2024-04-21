using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSelecter : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float _radiusExplosion;


    private float _maxRayLength = 100f;

    private int _maxChanceClone = 101;
    private CubeCreator _cubeCreator;

    private void Start()
    {
        _cubeCreator = FindObjectOfType<CubeCreator>();
    }

    private void Update()
    {
        SelecetCube();
    }

    private void SelecetCube()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _maxRayLength, ~layerMask))
            {
                if (hit.collider.TryGetComponent(out Cube cube))
                {
                    SelectAction(cube);
                }
            }
        }
    }

    private List<Cube> GetNearCubes()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _radiusExplosion);

        List<Cube> cubes = new List<Cube>();

        foreach (Collider hit in hits)
        {
            if (hit.TryGetComponent(out Cube cube))
            {
                cubes.Add(cube);
            }
        }

        return cubes;
    }

    private void SelectAction(Cube cube)
    {
        if (Random.Range(0, _maxChanceClone) <= cube.ChanceClone)
        {
            List<Cube> cubes = _cubeCreator.CreatCubes(cube);
            cube.Explosion.StartExplosion(cubes, _radiusExplosion);
        }
        else
        {
            cube.Explosion.StartExplosion(GetNearCubes(), _radiusExplosion);
        }

        Destroy(cube.gameObject);
    }
}
