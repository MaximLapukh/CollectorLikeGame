using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour
{
    [SerializeField] ProductType _productType;
    public ProductType GetProductType() => _productType;
}
public enum ProductType
{
    Type0,
    Type1,
    Type2
}