/*
COMPANY: TgzsGames
PROJECT: Calcular Lucro
AUTHOR: Thiago Z Silva 
VERSION: 1.0
CREATION DATE: 3/6/2019 1
*/
using UnityEngine;

public class ProductInfo : MonoBehaviour
{
    private RegisteredProductsController registeredProductsController;
    private CalculateController calculateController;
    public Product product = new Product();
    private AddProductController controller;

    void Awake()
    {
        registeredProductsController = FindObjectOfType(typeof(RegisteredProductsController)) as RegisteredProductsController;
        calculateController = FindObjectOfType(typeof(CalculateController)) as CalculateController;
        controller = FindObjectOfType(typeof(AddProductController)) as AddProductController;
    }


    public void CallCalculateWindow()
    {
        calculateController.product = product;
        GeneralController.instance.WhichWindowToShow(2);
        calculateController.FillAllTexts();

    }



}
