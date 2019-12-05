/*
COMPANY: TgzsGames
PROJECT: Calcular Lucro
AUTHOR: Thiago Z Silva 
VERSION: 1.0
CREATION DATE: 3/12/2019 
*/
using UnityEngine;

public class EditMenu : MonoBehaviour
{
    public int index;
    public Product editProduct = new Product();

    private void Start()
    {
        Vector2 size = transform.localScale;
        size.x = size.x / 720 * Screen.width;
        size.y = size.y / 1280 * Screen.height;
        transform.localScale = size;
    }

    public void Delete()
    {
        GeneralController.instance.RemoveProductFromJson(index);
        GeneralController.instance.WhichWindowToShow(0);
        Destroy(this.gameObject);
    }


    public void Edit()
    {
        GeneralController.instance.WhichWindowToShow(1);
        GeneralController.instance.EditProduct(index);
        Destroy(this.gameObject);
    }
}