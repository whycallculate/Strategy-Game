using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Compound",menuName  = "Compound SO Create", order = 2)]
public class YerlesimYerleriSO : ScriptableObject
{

    

    private static YerlesimYerleriSO instance;
    public static YerlesimYerleriSO Instance
    {
        get
        {
            instance = Resources.Load<YerlesimYerleriSO>("Compound");
            return instance;
        }
        
    }


    public SehirContainer[] SehirContainerArray;
    public KoyContainer[] KoyContainerArray;
    public UretimAlaniContainer[] UretimAlaniContainerArray;
    public KaleContainer[] KaleContainerArray;
    
}




[Serializable]
public class SehirContainer
{

    
    public Sprite sehirPhoto;
    public string name;
    public int hamMaddeUrunleri;
    public int savasEkipmanlari;
    public int IsEkipmanlari;
    public int konut;
    public int yapiMalzemeleri;
    public int gidaUrunleri;



}
[Serializable]
public class KoyContainer
{
    public string name;
    public Sprite koyPhoto;
    public int hamMaddeUrunleri;
    public int savasEkipmanlari;
    public int IsEkipmanlari;
    public int konut;
    public int yapiMalzemeleri;
    public int gidaUrunleri;


}
[Serializable]
public class KaleContainer
{
    public string name;
    public Sprite kalePhoto;
    public int hamMaddeUrunleri;
    public int savasEkipmanlari;
    public int IsEkipmanlari;
    public int konut;
    public int yapiMalzemeleri;
    public int gidaUrunleri;
}

[Serializable]
public class UretimAlaniContainer
{
    public string name;
    public Sprite uretimPhoto;
    public int hamMaddeUrunleri;
    public int savasEkipmanlari;
    public int IsEkipmanlari;
    public int konut;
    public int yapiMalzemeleri;
    public int gidaUrunleri;

}