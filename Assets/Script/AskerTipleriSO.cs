using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AskerlerSO", menuName = "Asker Tipleri SO", order = 3)]
public class AskerTipleriSO : ScriptableObject
{
    private static AskerTipleriSO instance;
    public static AskerTipleriSO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<AskerTipleriSO>("AskerlerSO");
            }
            
            return instance;
        }
    }

    public AskerTipi[] TumAskerTipleri;
}

[Serializable]
public class AskerTipi
{
    public string askerIsmi;
    [Space]
    [Space]

    public Sprite AskerResmi;
    public Sprite GoldImage;

    public int paraMaliyeti;
    public int yemekMaliyeti;
    public int SavasEkipmaniMaliyeti;

}