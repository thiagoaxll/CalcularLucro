/*
COMPANY: TgzsGames
PROJECT: Calcular Lucro
AUTHOR: Thiago Z Silva 
VERSION: 1.0
CREATION DATE: 25/02/2019
*/
using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using TMPro;
using SimpleJSON;


public class AddProductController : MonoBehaviour
{

    [Header("Classes")]
    public Product product = new Product();

    [Header("Objetos")]
    public GameObject fillInformation;

    [Header("Windows")]
    public GameObject[] windows;

    [Header("Referencias")]
    public GameObject fillInformationHolder;
    public GameObject addFillInformationBtn;

    [Header("Status")]
    public int whichWindowsIsOpen;
    [Space(20)]

    [Header("Texts")]
    public TMP_InputField priceTxt;
    public TMP_InputField quantityTxt;
    public TMP_InputField nameTxt;

    private float sellPrice;
    private int productQuantity;
    private string productName;

    private List<ItemInfo> ingredients = new List<ItemInfo>();
    private RegisteredProductsController registeredProductsController;

    private List<GameObject> fillContent = new List<GameObject>();


    private void Awake()
    {
        registeredProductsController = FindObjectOfType(typeof(RegisteredProductsController)) as RegisteredProductsController;
    }


    public void DestroyAllFillContent()
    {
        for (int i = 0; i < fillContent.Count; i++)
        {
            Destroy(fillContent[i]);
            fillContent.Remove(fillContent[i]);
        }
    }


    public void AddFillInformation()
    {
        GameObject temp = Instantiate(fillInformation);
        temp.transform.SetParent(fillInformationHolder.transform);
        addFillInformationBtn.transform.SetAsLastSibling();
        fillContent.Add(temp);
    }


    public void ItemName(string value)
    {
        productName = value;
    }


    public void SellPrice(string value)
    {
        value = value.Replace(",", ".");
        try { sellPrice = float.Parse(value); priceTxt.text = "R$ : " + sellPrice.ToString("F2"); }
        catch
        {
            sellPrice = 0;
            priceTxt.text = "";
        }
    }


    public void ProductQuantity(string value)
    {
        try { productQuantity = int.Parse(value); }
        catch
        {
            productQuantity = 0;
            quantityTxt.text = "";
        }
    }


    public void Save()
    {
        FillInformation[] tempItems = FindObjectsOfType(typeof(FillInformation)) as FillInformation[];
        foreach (FillInformation temp in tempItems)
        {
            ingredients.Add(temp.information);
        }

        product.name = productName;
        product.price = sellPrice;
        product.quantity = productQuantity;
        product.ingredients = ingredients;


        if (ingredients.Count > 0)
        {
            for (int i = 0; i < ingredients.Count; i++)
            {
                if (ingredients[i].itemName == "" || ingredients[i].price == 0 || ingredients[i].amount == 0 || ingredients[i].usedAmmount == 0)
                {
                    ingredients.Remove(ingredients[i]);
                }
            }
        }

        if (product.name != "" && product.price > 0 && product.quantity > 0 && ingredients.Count > 0)
        {
            StoreInfoInJson();
        }
        else
        {
            Debug.Log("Produto inválido");
        }

        GeneralController.instance.WhichWindowToShow(0);

    }


    public void ClearInfo()
    {
        nameTxt.text = "";
        priceTxt.text = "";
        quantityTxt.text = "";

        sellPrice = 0;
        productQuantity = 0;
        productName = "";
    }


    private void StoreInfoInJson()
    {

        string[] Productfields = { "name", "price", "quantity" };

        GeneralController.instance.jsonData[product.name].Add(Productfields[1], product.price);
        GeneralController.instance.jsonData[product.name].Add(Productfields[2], product.quantity);
        GeneralController.instance.jsonData["RegisteredProductes"]["products"].Add(product.name);

        for (int i = 0; i < product.ingredients.Count; i++)
        {
            GeneralController.instance.jsonData[product.name]["ingredients"].Add(product.ingredients[i].itemName);
            GeneralController.instance.jsonData[product.name]["ingredients"].Add(product.ingredients[i].price);
            GeneralController.instance.jsonData[product.name]["ingredients"].Add(product.ingredients[i].amount);
            GeneralController.instance.jsonData[product.name]["ingredients"].Add(product.ingredients[i].usedAmmount);
        }

        GeneralController.instance.SaveJsonObject();
        GeneralController.instance.LoadJsonObject();
    }

}
