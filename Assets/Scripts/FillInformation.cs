/*
COMPANY: TgzsGames
PROJECT: Calcular Lucro
AUTHOR: Thiago Z Silva 
VERSION: 1.0
CREATION DATE: 25/02/2019
*/
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class FillInformation : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI nameTxt;
    [SerializeField] private TextMeshProUGUI priceTxt;
    [SerializeField] private TextMeshProUGUI amountTxt;
    [SerializeField] private TextMeshProUGUI usedAmountTxt;

    [SerializeField] private Image background;

    public ItemInfo information = new ItemInfo();

    private Color32 defaultColor = new Color32(231, 231, 231, 125);

    public void ChangeName(string value)
    {
        information.itemName = value;
        CheckIfItsAllCorrect();
    }


    public void ChangePrice(string value)
    {
        try { information.price = float.Parse(value); }
        catch { information.price = 0; }
        CheckIfItsAllCorrect();
    }


    public void ChageWeight(string value)
    {
        try { information.amount = float.Parse(value); }
        catch { information.price = 0; }
        CheckIfItsAllCorrect();
    }


    public void ChangeAmount(string value)
    {
        try { information.usedAmmount = float.Parse(value); }
        catch { information.price = 0; }
        CheckIfItsAllCorrect();
    }


    private void CheckIfItsAllCorrect()
    {
        if (information.itemName != "" && information.price > 0 && information.amount > 0 && information.usedAmmount > 0)
        {
            background.color = new Color32(0, 255, 0, 125);
        }
        else
        {
            background.color = defaultColor;
        }
    }

}
