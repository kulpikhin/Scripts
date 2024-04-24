using UnityEngine;

public class CubeSelecter : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private CubeCreator _cubeCreator;

    private float _maxRayLength = 100f;
    private int _maxChanceClone = 101;

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

    private void SelectAction(Cube cube)
    {
        if (Random.Range(0, _maxChanceClone) <= cube.ChanceClone)
        {
            _cubeCreator.CreatCubes(cube);
        }
        else
        {
            cube.Explosion.StartExplosion(cube.transform.position);
        }

        Destroy(cube.gameObject);
    }
}
