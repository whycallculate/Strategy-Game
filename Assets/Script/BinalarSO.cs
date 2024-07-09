using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BinalarSO", menuName = "Binalar SO Create", order = 2)]
public class BinalarSO : ScriptableObject
{

    
    private static BinalarSO instance;
    public static BinalarSO Instance
    {
        get
        { 
            instance = Resources.Load<BinalarSO>("BinalarSO");
            return instance;
        }
    }

    public BinaContainer[] TumBinaTipleri;

    


}

[Serializable]
public class BinaContainer
{
    public string BinaIsmi;
    //public Sprite BinaSprite;

    public int levelBirMaliyet;
    public int levelIkiMaliyet;
    public int levelUcMaliyet;
    public MaliyetContainer[] levelMaliyet;
}
[Serializable]
public class MaliyetContainer
{
    public string nextLevel;
    public int maliyetHamMaddeUrunleri;
    public int maliyetsavasEkipmanlari;
    public int maliyetIsEkipmanlari;
    public int maliyetyapiMalzemeleri;
    public int maliyetgidaUrunleri;
    public int maliyetMoney;
}
