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


    public void Delete()
    {
        GeneralController.instance.RemoveProductFromJson(index);
    }


    public void Edit()
    {

    }
}
