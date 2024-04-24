using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Cube : MonoBehaviour
{
    private int _scaleMultiplier = 2;
    private Renderer _renderer;

    public Explode Explosion { get; private set; }
    public int ChanceClone { get; private set; } = 100;

    private void Awake()
    {
        Explosion = GetComponent<Explode>();
        _renderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        ChangeColor();
    }

    public void OnSpawn(int chanceCloneParent, Vector3 scaleParent, float radiusExplosion, float forceExplosion)
    {
        transform.localScale = scaleParent/ _scaleMultiplier;
        ChanceClone = chanceCloneParent/ _scaleMultiplier;
        Explosion.IncreaseExplosion(radiusExplosion, forceExplosion);
    }

    private void ChangeColor()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value);

        _renderer.material.color = randomColor;
    }
}
