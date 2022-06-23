using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduceWarehouse : Warehouse
{
    [SerializeField] Product _produceProductPref;
    public void TryCreateProduct()
    {
        if (HaveSpace())
        {
            var product = Instantiate(_produceProductPref);
            TryAddProduct(product);
        }
    }
}
