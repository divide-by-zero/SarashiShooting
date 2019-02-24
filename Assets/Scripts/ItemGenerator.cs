using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    private const int ItemNum = 15;

    [SerializeField] private GameObject _item;
    [SerializeField] private Renderer _renderer;

    private float _width;

    private void Awake()
    {
        _width = _renderer.bounds.size.x / 2;
        for (var i = 0; i < ItemNum; i++)
        {
            var subPosition = new Vector3(Random.Range(-_width, _width), 16, Random.Range(-_width, _width));
            Instantiate(_item, subPosition, Quaternion.identity);
        }
    }
}