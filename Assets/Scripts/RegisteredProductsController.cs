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

    private AddProductController controller;

    private List<GameObject> allProductsBtn = new List<GameObject>();

    public List<Product> product = new List<Product>();

    public int indexTotalProducts;
    public List<string> registredProducts = new List<string>();


    private void Awake()
    {
        controller = FindObjectOfType(typeof(AddProductController)) as AddProductController;
    }

    private void Start()
    {
        GetAllRegisteredProductNames();
        for (int i = 0; i < registredProducts.Count; i++)
        {
            product.Add(LoadProductsFromJson());
            indexTotalProducts++;
            Debug.Log("XD");
        }
    }


    private void DestroyAllProducts()
    {
        foreach (GameObject temp in allProductsBtn)
        {
            Destroy(temp.gameObject);
        }
    }


    public void InstantiateProducts()
    {
        // DestroyAllProducts();

        // GameObject temp = Instantiate(productsBtn);
        // temp.transform.SetParent(productsBtnHolder.transform);
        // temp.GetComponent<ProductInfo>().product = controller.product;
        // temp.GetComponentInChildren<Text>().text = controller.product.name;
        // allProductsBtn.Add(temp);

        //LoadProductsFromJson();
    }


    private void GetAllRegisteredProductNames()
    {
        for (int i = 0; i < AddProductController.jsonData["RegisteredProductes"]["products"].Count; i++)
        {
            registredProducts.Add(AddProductController.jsonData["RegisteredProductes"]["products"][i]);
        }
    }


    public Product LoadProductsFromJson()
    {
        Product tempProduct = new Product();
        ItemInfo tempItemIngredientes = new ItemInfo();
        List<ItemInfo> itemIngredientes = new List<ItemInfo>();

        tempProduct.name = registredProducts[indexTotalProducts];
        tempProduct.price = AddProductController.jsonData[registredProducts[indexTotalProducts]]["price"];
        tempProduct.quantity = AddProductController.jsonData[registredProducts[indexTotalProducts]]["quantity"];

        for (int i = 0; i < AddProductController.jsonData[registredProducts[indexTotalProducts]]["ingredients"].Count; i++)
        {
            if (i % 4 == 0 || i == 0)
            {
                tempItemIngredientes.itemName = AddProductController.jsonData[registredProducts[indexTotalProducts]]["ingredients"][i];
                tempItemIngredientes.price = AddProductController.jsonData[registredProducts[indexTotalProducts]]["ingredients"][i + 1];
                tempItemIngredientes.amount = AddProductController.jsonData[registredProducts[indexTotalProducts]]["ingredients"][i + 2];
                tempItemIngredientes.usedAmmount = AddProductController.jsonData[registredProducts[indexTotalProducts]]["ingredients"][i + 3];
                itemIngredientes.Add(tempItemIngredientes);
            }
        }
        tempProduct.ingredients = itemIngredientes;
        return tempProduct;
    }


}
