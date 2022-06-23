using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingLineFromFactoryToWarehouse : MonoBehaviour
{
    [SerializeField] DrawingLine _linePref;
    [SerializeField] List<Transform> _warehouses;
    void Start()
    {
        foreach (var item in _warehouses)
        {
            DrawingLine line = Instantiate(_linePref);
            line.SetFromTo(transform, item);
            line.transform.SetParent(transform);
        }
    }


}
