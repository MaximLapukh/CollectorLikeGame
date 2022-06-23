using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DrawingLine : MonoBehaviour
{
    [SerializeField] Transform _from;
    [SerializeField] Transform _to;
    private LineRenderer _line;
    void Start()
    {
        _line = GetComponent<LineRenderer>();
    }
    public void SetFromTo(Transform from, Transform to)
    {
        _from = from;
        _to = to;
    }
    void Update()
    {
        _line.SetPosition(0, _from.position);
        _line.SetPosition(1, _to.position);
    }
}
