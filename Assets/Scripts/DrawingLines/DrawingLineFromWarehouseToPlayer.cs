using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingLineFromWarehouseToPlayer : MonoBehaviour
{
    [SerializeField] DrawingLine _linePref;
    [SerializeField] Transform _player;
    void Start()
    {
        var warehouses = GameObject.FindGameObjectsWithTag(nameof(Warehouse));
        foreach (var item in warehouses)
        {
            DrawingLine line =  Instantiate(_linePref);
            line.SetFromTo(_player, item.GetComponent<Transform>());
            line.transform.SetParent(transform);
        }
    }

}
