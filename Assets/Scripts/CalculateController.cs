/*
COMPANY: TgzsGames
PROJECT: Calcular Lucro
AUTHOR: Thiago Z Silva 
VERSION: 1.0
CREATION DATE: 3/6/2019 1
*/
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CalculateController : MonoBehaviour
{


    [SerializeField] private TextMeshProUGUI productNameTxt;
    [SerializeField] private TextMeshProUGUI productQuantityTxt;
    [SerializeField] private TextMeshProUGUI productPriceTxt;
    [SerializeField] private TextMeshProUGUI productCostTxt;
    [SerializeField] private TextMeshProUGUI productProfitTxt;

    [Space(20)]
    [SerializeField] private TextMeshProUGUI allProductCostTxt;
    [SerializeField] private TextMeshProUGUI allProductProfitTxt;

    [Space(20)]
    [SerializeField] private TextMeshProUGUI allIngredientsTxt;




    private RegisteredProductsController registeredProductsController;
    [Space(30)]
    public Product product = new Product();
    private AddProductController controller;


    private float totalCost;

    void Start()
    {
        registeredProductsController = FindObjectOfType(typeof(RegisteredProductsController)) as RegisteredProductsController;
        controller = FindObjectOfType(typeof(AddProductController)) as AddProductController;
        FillAllTexts();
    }


    public void FillAllTexts()
    {
        totalCost = CalculateAllIngredientsCost();

        productNameTxt.text = product.name;
        productPriceTxt.text = "Preço de Venda: R$ " + product.price.ToString("F2");

        productQuantityTxt.text = "X " + product.quantity.ToString();

        productCostTxt.text = "Custo Unitário: R$ " + (totalCost / product.quantity).ToString("F2");
        productProfitTxt.text = "Lucro Unitário: R$ " + (((product.price * product.quantity) - totalCost) / product.quantity).ToString("F2");

        allProductCostTxt.text = "Custo Total: R$ " + totalCost.ToString("F2");
        allProductProfitTxt.text = "Lucro Total: R$ " + (((product.price * product.quantity) - totalCost)).ToString("F2");

        allIngredientsTxt.text = CalculateIndividualIngredients();

    }


    private string CalculateIndividualIngredients()
    {
        string standart = " : R$ ";
        string value = "";
        for (int i = 0; i < product.ingredients.Count; i++)
        {
            value += product.ingredients[i].itemName + standart + CalculatePricePerItem(
                product.ingredients[i].price, product.ingredients[i].amount, product.ingredients[i].usedAmmount).ToString("F2") + "\n";
        }
        return value;
    }


    private float CalculateAllIngredientsCost()
    {
        float totalCost = 0;
        for (int i = 0; i < product.ingredients.Count; i++)
        {
            totalCost += CalculatePricePerItem(product.ingredients[i].price, product.ingredients[i].amount, product.ingredients[i].usedAmmount);
        }
        return totalCost;
    }


    public float CalculatePricePerItem(float price, float amount, float usedAmount)
    {
        return (price * usedAmount) / amount;
    }


    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }


}
