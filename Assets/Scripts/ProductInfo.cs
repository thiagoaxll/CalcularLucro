/*
COMPANY: TgzsGames
PROJECT: Calcular Lucro
AUTHOR: Thiago Z Silva 
VERSION: 1.0
CREATION DATE: 3/6/2019 1
*/
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
