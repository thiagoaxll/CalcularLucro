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
