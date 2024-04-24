using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSelecter : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;    

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

    private List<Cube> GetNearCubes(Cube cubeParent)
    {
        Collider[] hits = Physics.OverlapSphere(cubeParent.transform.position, cubeParent.Explosion.RadiusExplosion);

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
            _cubeCreator.CreatCubes(cube);
        }
        else
        {
            cube.Explosion.StartExplosion(GetNearCubes(cube));
        }

        Destroy(cube.gameObject);
    }
}
