/*
COMPANY: TgzsGames
PROJECT: Calcular Lucro
AUTHOR: Thiago Z Silva 
VERSION: 1.0
CREATION DATE: 3/6/2019 1
*/
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections.Generic;

public class RegisteredProductsController : MonoBehaviour
{

    [Header("Objetos")]
    public GameObject productsBtnHolder;
    public GameObject productsBtn;

    public List<GameObject> allProductsBtn = new List<GameObject>();
    public List<Product> product = new List<Product>();
    public int indexTotalProducts;


    public void ShowRegisteredWindow()
    {
        DestroyAllProducts();
        GetAllRegisteredProductNames();

        for (int i = 0; i < GeneralController.instance.registredProducts.Count; i++)
        {
            product.Add(LoadProductsFromJson());
            indexTotalProducts++;
        }
        indexTotalProducts = 0;

        InstantiateProducts();
    }


    public void DestroyAllProducts()
    {
        foreach (GameObject temp in allProductsBtn)
        {
            Destroy(temp.gameObject);
        }
        allProductsBtn.Clear();

    }


    public void InstantiateProducts()
    {
        for (int i = GeneralController.instance.registredProducts.Count - 1; i >= 0; i--)
        {
            GameObject temp = Instantiate(productsBtn);
            temp.transform.SetParent(productsBtnHolder.transform);

            temp.GetComponent<ProductInfo>().product = product[i];
            temp.GetComponentInChildren<Text>().text = product[i].name;
            allProductsBtn.Add(temp);
        }
    }


    private void GetAllRegisteredProductNames()
    {
        GeneralController.instance.registredProducts.Clear();
        for (int i = 0; i < GeneralController.instance.jsonData["RegisteredProductes"]["products"].Count; i++)
        {
            GeneralController.instance.registredProducts.Add(GeneralController.instance.jsonData["RegisteredProductes"]["products"][i]);
        }
    }


    public Product LoadProductsFromJson()
    {
        Product tempProduct = new Product();
        ItemInfo tempItemIngredientes = new ItemInfo();
        List<ItemInfo> itemIngredientes = new List<ItemInfo>();

        tempProduct.name = GeneralController.instance.registredProducts[indexTotalProducts];
        tempProduct.price = GeneralController.instance.jsonData[GeneralController.instance.registredProducts[indexTotalProducts]]["price"];
        tempProduct.quantity = GeneralController.instance.jsonData[GeneralController.instance.registredProducts[indexTotalProducts]]["quantity"];

        for (int i = 0; i < GeneralController.instance.jsonData[GeneralController.instance.registredProducts[indexTotalProducts]]["ingredients"].Count; i++)
        {
            if (i % 4 == 0 || i == 0)
            {
                tempItemIngredientes.itemName = GeneralController.instance.jsonData[GeneralController.instance.registredProducts[indexTotalProducts]]["ingredients"][i];
                tempItemIngredientes.price = GeneralController.instance.jsonData[GeneralController.instance.registredProducts[indexTotalProducts]]["ingredients"][i + 1];
                tempItemIngredientes.amount = GeneralController.instance.jsonData[GeneralController.instance.registredProducts[indexTotalProducts]]["ingredients"][i + 2];
                tempItemIngredientes.usedAmmount = GeneralController.instance.jsonData[GeneralController.instance.registredProducts[indexTotalProducts]]["ingredients"][i + 3];
                itemIngredientes.Add(tempItemIngredientes);
            }
        }
        tempProduct.ingredients = itemIngredientes;
        return tempProduct;
    }


}
