/*
COMPANY: TgzsGames
PROJECT: Calcular Lucro
AUTHOR: Thiago Z Silva 
VERSION: 1.0
CREATION DATE: 25/02/2019
*/
using UnityEngine;
using TMPro;


public class FillInformation : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI nameTxt;
    [SerializeField] private TextMeshProUGUI priceTxt;
    [SerializeField] private TextMeshProUGUI amountTxt;
    [SerializeField] private TextMeshProUGUI usedAmountTxt;

    public ItemInfo information = new ItemInfo();


    public void ChangeName(string value)
    {
        information.itemName = value;
    }


    public void ChangePrice(string value)
    {
        try { information.price = float.Parse(value); priceTxt.text = "R$ : " + information.price.ToString("F2"); }
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
