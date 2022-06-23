using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepWarehouse : Warehouse
{
    [SerializeField] ProductType _productType;
    public ProductType GetProductType() => _productType;
    public override bool TryAddProduct(Product product)
    {
        if(product.GetProductType() == _productType)
            return base.TryAddProduct(product);

        return false;
    }

}
