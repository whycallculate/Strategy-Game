using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Urunler SO", menuName = "UrunlerSO", order = 2)]
public class UrunlerSO : ScriptableObject
{
    private static UrunlerSO instance;
    public static UrunlerSO Instance
    {
        get
        {
            if(instance == null)
            {
                instance = Resources.Load<UrunlerSO>("Urunler SO");
            }
            return instance;
        }
        
    }
    public Urun[] TumUrunlerSO;
}



[Serializable]
public class Urun
{
    public string name;
    public Sprite image;
    public float SatisDegeri;
}



