/*
COMPANY: TgzsGames
PROJECT: Calcular Lucro
AUTHOR: Thiago Z Silva 
VERSION: 1.0
CREATION DATE: 3/6/2019 1
*/
using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public struct ItemInfo
{
    public string itemName;
    public float price;
    public float amount;
    public float usedAmmount;
}


[Serializable]
public class Product
{
    public string name;
    public float price;
    public float cost;
    public float profit;
    public int quantity;

    public List<ItemInfo> ingredients;
}
