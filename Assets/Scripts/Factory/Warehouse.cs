using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warehouse : MonoBehaviour
{
    [SerializeField] int _maxSize;
    [Header("Sort")]
    [SerializeField] int _rows = 1;
    [SerializeField] int _cols = 1;
    [SerializeField] Vector3 _offset;
    [SerializeField] Vector3 _pading;
    protected List<Product> _products;

    private void Awake()
    {
        _products = new List<Product>();
    }
  
    public void SortProducts()
    {
        int row = 0;
        int col = 0;
        int hight = 0;
        for (int curProduct = 0; curProduct < _products.Count; curProduct++)
        {
            _products[curProduct].transform.localRotation = Quaternion.Euler(Vector3.zero);
            _products[curProduct].transform.localPosition = new Vector3(row * _pading.x, hight * _pading.y, col * _pading.z) + _offset;
            col++;
            if(col >= _cols)
            {
                col = 0;
                row++;
                if(row >= _rows)
                {
                    row = 0;
                    hight++;
                }
            }
        }
      
    }
    public Product TryTakeProductWithType(ProductType productType)
    {
        Product product = null;
        foreach (var item in _products)
        {
            if (item.GetProductType() == productType)
            {
                product = item;
            }
        }
        if (product != null) { _products.Remove(product); SortProducts(); }

        return product;
    }
    public virtual bool TryAddProduct(Product product)
    {
        if (_products.Count >= _maxSize) return false;
        _products.Add(product);
        product.transform.SetParent(transform);
        SortProducts();
        return true;
    }
    public Product TakeProduct()
    {
        var product = _products[_products.Count - 1];
        _products.Remove(product);
        SortProducts();
        return product;
    }
    public bool HaveAnyProducts() => _products.Count > 0;
    public bool HaveSpace() => _products.Count < _maxSize;
}
