/*
COMPANY: TgzsGames
PROJECT: Calcular Lucro
AUTHOR: Thiago Z Silva 
VERSION: 1.0
CREATION DATE: 3/9/2019 1
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.IO;

public class GeneralController : MonoBehaviour
{

    const string PRODUCT_PATH = "/StreamingAssets/Products.json";

    [SerializeField] private AddProductController addProductController;
    [SerializeField] private RegisteredProductsController registeredProductsController;
    [SerializeField] private CalculateController calculateController;

    [Header("Objetos")]
    public GameObject[] windows;
    [Header("Status")]
    public int whichWindowsIsOpen;

    public static GeneralController instance { get; private set; }

    public JSONObject jsonData;

    public List<string> registredProducts = new List<string>();


    private void Awake()
    {
        LoadJsonObject();
        instance = this;
        WhichWindowToShow(0);
    }


    public void WhichWindowToShow(int whichWindow)
    {
        switch (whichWindow)
        {
            case 0:
                registeredProductsController.product.Clear();
                LoadJsonObject();
                registeredProductsController.ShowRegisteredWindow();
                break;
            case 1:
                addProductController.DestroyAllFillContent();
                registeredProductsController.DestroyAllProducts();
                LoadJsonObject();
                addProductController.ClearInfo();
                break;
            case 2:
                registeredProductsController.DestroyAllProducts();
                break;
        }

        whichWindowsIsOpen = whichWindow;

        foreach (GameObject temp in windows)
        {
            temp.SetActive(false);
        }

        windows[whichWindowsIsOpen].SetActive(true);
        windows[whichWindowsIsOpen].GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
    }


    public void LoadJsonObject()
    {
        jsonData = (JSONObject)JSON.Parse(File.ReadAllText(Application.dataPath + PRODUCT_PATH));
    }


    public void SaveJsonObject()
    {
        File.WriteAllText(Application.dataPath + PRODUCT_PATH, jsonData.ToString());
    }

}
