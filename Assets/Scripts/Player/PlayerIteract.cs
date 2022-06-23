using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIteract : MonoBehaviour
{
    [SerializeField] float _collectSpeed;
    [SerializeField] Warehouse _invetory;

    private Warehouse _lastWarehouse;
    private float _collectTimer;
    private void Update()
    {
        if(_collectTimer <= 0 && _lastWarehouse != null)
        {
            IteractWithWarehouse(_lastWarehouse);
            _collectTimer = _collectSpeed;
        }else if(_collectTimer > 0)
        {
            _collectTimer -= Time.deltaTime;
        }
    }

    private void IteractWithWarehouse(Warehouse warehouse)
    {
        var produceWarehouse = warehouse as ProduceWarehouse;
        if(produceWarehouse != null)
        {
            if (produceWarehouse.HaveAnyProducts() && _invetory.HaveSpace())
            {
                _invetory.TryAddProduct(produceWarehouse.TakeProduct());
            }
        }
      
        var keepWarehouse = warehouse as KeepWarehouse;
        if (keepWarehouse != null && keepWarehouse.HaveSpace())
        {
            var product = _invetory.TryTakeProductWithType(keepWarehouse.GetProductType());
            if(product != null)
                keepWarehouse.TryAddProduct(product);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Warehouse>(out var warehouse))
        {
            _lastWarehouse = warehouse;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _lastWarehouse = null;
    }
}
