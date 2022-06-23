using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] string _nameFactory; 
    [SerializeField] List<KeepWarehouse> _needProducts;
    [SerializeField] List<ProduceWarehouse> _produceProducts;
    [SerializeField] float _produceRate;

    private float _produceTimer;
    void Start()
    {
        _produceTimer = _produceRate;
    }

    void Update()
    {
        if (!HaveProducts()) return;
        if (!HaveSpace()) return;
        if(_produceTimer < 0)
        {
            TryCreateProducts();
            _produceTimer = _produceRate;
        }
        else if(_produceTimer > 0 ){
            _produceTimer -= Time.deltaTime;
        }
    }

    public bool HaveProducts()
    {
        if(_needProducts != null && _needProducts.Count > 0)
        {
            foreach (var item in _needProducts)
            {
                if (!item.HaveAnyProducts()) return false;
            }
        }
        return true;
    }
    public bool HaveSpace()
    {
        if (_produceProducts != null)
        {
            foreach (var item in _produceProducts)
            {
                if (!item.HaveSpace()) return false;
            }
            return true;
        }
        return false;
    }
    private void TryCreateProducts()
    {
        RemoveNeedProducts();
        foreach (var item in _produceProducts)
        {
            item.TryCreateProduct();
        }
    }
    private void RemoveNeedProducts()
    {
        if(_needProducts != null)
        {
            foreach (var item in _needProducts)
            {
                Destroy(item.TakeProduct().gameObject);
            }
        }
    }
    public override string ToString()
    {
        return _nameFactory;
    }

}
