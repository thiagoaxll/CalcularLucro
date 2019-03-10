/*
COMPANY: TgzsGames
PROJECT: Calcular Lucro
AUTHOR: Thiago Z Silva 
VERSION: 1.0
CREATION DATE: 25/02/2019
*/
using UnityEngine;

public class FillInformation : MonoBehaviour
{

    // public int id;
    public ItemInfo information = new ItemInfo();


    public void ChangeName(string value)
    {
        information.itemName = value;
    }


    public void ChangePrice(string value)
    {
        try { information.price = float.Parse(value); }
        catch { information.price = 0; }

    }


    public void ChageWeight(string value)
    {
        try { information.amount = float.Parse(value); }
        catch { information.price = 0; }
    }


    public void ChangeAmount(string value)
    {
        try { information.usedAmmount = float.Parse(value); }
        catch { information.price = 0; }
    }

}
