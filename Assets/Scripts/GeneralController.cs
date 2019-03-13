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

    const string PRODUCT_PATH_PC = "/StreamingAssets/";
    const string PRODUCT_FILE = "Products.json";

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
    private TextAsset dataText;


    private void Awake()
    {

        CheckIfProductFileExists();
        LoadJsonObject();
        instance = this;
        WhichWindowToShow(0);
    }


    private void CheckIfProductFileExists()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        if(!File.Exists(Application.persistentDataPath + "/Products.json"))
        {
            CreateProductFile();
        }
#endif
#if UNITY_EDITOR || UNITY_EDITOR_WIN
        if (!File.Exists(Application.dataPath + "/StreamingAssets/Products.json"))
        {
            CreateProductFile();
        }
#endif
    }


    public void CreateProductFile()
    {
        dataText = Resources.Load("Products_Template") as TextAsset;
#if UNITY_ANDROID && !UNITY_EDITOR
        File.WriteAllText(Application.persistentDataPath + "/Products.json", dataText.ToString());
#endif

#if UNITY_EDITOR || UNITY_EDITOR_WIN
        File.WriteAllText(Application.dataPath + "/StreamingAssets/Products.json", dataText.ToString());
#endif
    }


    public void DelleteAllRegisteredProducts()
    {
        CreateProductFile();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }


    public void WhichWindowToShow(int whichWindow)
    {
        switch (whichWindow)
        {
            case 0:
                ClearRegisteredProductWindow();
                LoadJsonObject();
                break;
            case 1:
                ClearInstertProductWindow();
                LoadJsonObject();
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


    private void ClearRegisteredProductWindow()
    {
        registeredProductsController.product.Clear();
        registeredProductsController.ShowRegisteredWindow();
    }


    private void ClearInstertProductWindow()
    {
        registeredProductsController.DestroyAllProducts();
        addProductController.DestroyAllFillContent();
        addProductController.ClearInfo();
    }


    public void RemoveProductFromJson(int productToRemove)
    {
        LoadJsonObject();
        registredProducts.Remove(registredProducts[productToRemove]);
        registeredProductsController.product.Remove(registeredProductsController.product[productToRemove]);
        jsonData["RegisteredProducts"]["products"].Remove(jsonData["RegisteredProducts"]["products"][productToRemove]);
        jsonData.Remove(jsonData[productToRemove + 1]);
        SaveJsonObject();
    }


    public void EditProduct(int productToEdit)
    {
        Product tempProductToEdit = new Product();
        tempProductToEdit = registeredProductsController.product[productToEdit];
        RemoveProductFromJson(productToEdit);
        addProductController.EditProduct(tempProductToEdit);
    }


    public void LoadJsonObject()
    {

#if UNITY_EDITOR_WIN
        jsonData = (JSONObject)JSON.Parse(File.ReadAllText(Application.dataPath + PRODUCT_PATH_PC + PRODUCT_FILE));
#endif

#if UNITY_ANDROID && !UNITY_EDITOR
        jsonData = (JSONObject)JSON.Parse(File.ReadAllText(Application.persistentDataPath + "/" + PRODUCT_FILE));
#endif

    }


    public void SaveJsonObject()
    {
#if UNITY_EDITOR_WIN
        File.WriteAllText(Application.dataPath + PRODUCT_PATH_PC + PRODUCT_FILE, jsonData.ToString());
#endif

#if UNITY_ANDROID && !UNITY_EDITOR
        File.WriteAllText(Application.persistentDataPath + "/" + PRODUCT_FILE, jsonData.ToString());
#endif
    }

}
