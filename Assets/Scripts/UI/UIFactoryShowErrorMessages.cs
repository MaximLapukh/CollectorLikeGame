using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIFactoryShowErrorMessages : MonoBehaviour
{
    [SerializeField] List<Factory> _factories;
    [SerializeField] Text _text;

    void Update()
    {
        var message = "";
        foreach (var factory in _factories)
        {
            var haveProducts = factory.HaveProducts();
            var haveSpace = factory.HaveSpace();
            if (haveProducts && haveSpace) continue;

            var factoryMsg = $" {factory} had stopped:";
            if(!haveProducts && !haveSpace)
            {
                factoryMsg += $" havn't products and space!";
            }else if (!haveProducts)
            {
                factoryMsg += $" havn't products!";
            }else if (!haveSpace)
            {
                factoryMsg += $" havn't space!";
            }

            message += factoryMsg + "\n";
        }
        _text.text = message;
    }
}
