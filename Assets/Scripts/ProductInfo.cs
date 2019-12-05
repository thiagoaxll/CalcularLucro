/*
COMPANY: TgzsGames
PROJECT: Calcular Lucro
AUTHOR: Thiago Z Silva 
VERSION: 1.0
CREATION DATE: 3/6/2019 1
*/

using System;
using System.Collections.Generic;
using UnityEngine;


public class ProductInfo : MonoBehaviour
{
    private CalculateController calculateController;
    public Product product = new Product();
    public int id;


    void Awake()
    {
        calculateController = FindObjectOfType(typeof(CalculateController)) as CalculateController;
    }

    private void Start()
    {
        Vector2 size = transform.localScale;
        size.x = size.x / 720 * Screen.width;
        size.y = size.y / 1280 * Screen.height;
        transform.localScale = size;
    }


    public void CalculateWindow()
    {
        if (!RegisteredProductsController.editMenuIsOpen)
        {
            calculateController.product = product;
            GeneralController.instance.WhichWindowToShow(2);
            calculateController.FillAllTexts();
        }

    }

}
