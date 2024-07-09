using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;


public enum YerlesimAlaniEnum
{
    SEHIR, KOY, KALE, URETIMALANI
}

public class YerlesimYeriController : MonoBehaviour
{





    public GameObject SelectObject;
    public int index;
    public YerlesimAlaniEnum yerlesimEnum;
    public YerlesimAlani YeniAlan;
    public YerlesimYeriTipi YerlesimTipi;
    [SerializeField] private MeshRenderer BannerColor;
    public YerlesimAlani[] YeniAlanForData;



    public void Awake()
    {

        TipAtama();
        MoneySetValue();
        BuildingValueSet(index);
        SelectObject = transform.GetChild(0).gameObject;
    }

    private void Update()
    {

    }

    public void TipAtama()
    {
        if (CompareTag("Koy"))
        {
            YeniAlan = new Koy();
            yerlesimEnum = YerlesimAlaniEnum.KOY;
            
        }
        else if (CompareTag("Sehir"))
        {
            YeniAlan = new Sehir();
            yerlesimEnum = YerlesimAlaniEnum.SEHIR;
        }
        else if (CompareTag("Kale"))
        {
            YeniAlan = new Kale();
            yerlesimEnum = YerlesimAlaniEnum.KALE;
        }
        else if (CompareTag("UretimAlani"))
        {
            YeniAlan = new UretimAlani();
            yerlesimEnum = YerlesimAlaniEnum.URETIMALANI;
        }
    }
    public void MoneySetValue()
    {
        YeniAlan.para = GameManager.Instance.moneyCount;
    }
    public void BuildingValueSet(int param)
    {

        
        if (YeniAlan is Sehir)
        {
            Sehir sehir = (Sehir)YeniAlan;
            for (int i = 0; i < YerlesimYerleriSO.Instance.SehirContainerArray.Length; i++)
            {
                if (param == i )
                {




                    
                    sehir.name = YerlesimYerleriSO.Instance.SehirContainerArray[i].name;
                    sehir.photo = YerlesimYerleriSO.Instance.SehirContainerArray[i].sehirPhoto;
                    sehir.hamMaddeUrunleri = YerlesimYerleriSO.Instance.SehirContainerArray[i].hamMaddeUrunleri;
                    sehir.savasEkipmanlari = YerlesimYerleriSO.Instance.SehirContainerArray[i].savasEkipmanlari;
                    sehir.IsEkipmanlari = YerlesimYerleriSO.Instance.SehirContainerArray[i].IsEkipmanlari;
                    sehir.konut = YerlesimYerleriSO.Instance.SehirContainerArray[i].konut;
                    sehir.yapiMalzemeleri = YerlesimYerleriSO.Instance.SehirContainerArray[i].yapiMalzemeleri;
                    sehir.gidaUrunleri = YerlesimYerleriSO.Instance.SehirContainerArray[i].gidaUrunleri;
                    transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = sehir.name;

                    Debug.Log(sehir.name);







                }
            }
        }
        if(YeniAlan is Koy)
        {
            Koy koy = (Koy)YeniAlan;
            for(int i = 0; i < YerlesimYerleriSO.Instance.KoyContainerArray.Length; i++)
            {
                if(param == i)
                {
                    
                    koy.name = YerlesimYerleriSO.Instance.KoyContainerArray[i].name;
                    koy.photo = YerlesimYerleriSO.Instance.KoyContainerArray[i].koyPhoto;
                    koy.hamMaddeUrunleri = YerlesimYerleriSO.Instance.KoyContainerArray[i].hamMaddeUrunleri;
                    koy.savasEkipmanlari = YerlesimYerleriSO.Instance.KoyContainerArray[i].savasEkipmanlari;
                    koy.IsEkipmanlari = YerlesimYerleriSO.Instance.KoyContainerArray[i].IsEkipmanlari;
                    koy.konut = YerlesimYerleriSO.Instance.KoyContainerArray[i].konut;
                    koy.yapiMalzemeleri = YerlesimYerleriSO.Instance.KoyContainerArray[i].yapiMalzemeleri;
                    koy.gidaUrunleri = YerlesimYerleriSO.Instance.KoyContainerArray[i].gidaUrunleri;
                    transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = koy.name;
                }
            }
        }  
        if (YeniAlan is Kale)
        {
            Kale kale= (Kale)YeniAlan;
            for( int i = 0;i<YerlesimYerleriSO.Instance.KaleContainerArray.Length; i++)
            {
                if(param == i)
                {
                    
                    kale.name = YerlesimYerleriSO.Instance.KaleContainerArray[i].name;
                    kale.photo = YerlesimYerleriSO.Instance.KaleContainerArray[i].kalePhoto;
                    kale.hamMaddeUrunleri = YerlesimYerleriSO.Instance.KaleContainerArray[i].hamMaddeUrunleri;
                    kale.savasEkipmanlari = YerlesimYerleriSO.Instance.KaleContainerArray[i].savasEkipmanlari;
                    kale.IsEkipmanlari = YerlesimYerleriSO.Instance.KaleContainerArray[i].IsEkipmanlari;
                    kale.konut = YerlesimYerleriSO.Instance.KaleContainerArray[i].konut;
                    kale.yapiMalzemeleri = YerlesimYerleriSO.Instance.KaleContainerArray[i].yapiMalzemeleri;
                    kale.gidaUrunleri = YerlesimYerleriSO.Instance.KaleContainerArray[i].gidaUrunleri;
                    transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = kale.name;
                }
            }
        }
        if(YeniAlan is UretimAlani)
        {
            UretimAlani uretim = (UretimAlani)YeniAlan;
            for(int i = 0;i<YerlesimYerleriSO.Instance.UretimAlaniContainerArray.Length;i++)
            {
                if(param == i)
                {
                   
                    uretim.name = YerlesimYerleriSO.Instance.UretimAlaniContainerArray[i].name;
                    uretim.photo = YerlesimYerleriSO.Instance.UretimAlaniContainerArray[i].uretimPhoto;
                    uretim.hamMaddeUrunleri = YerlesimYerleriSO.Instance.UretimAlaniContainerArray[i].hamMaddeUrunleri;
                    uretim.savasEkipmanlari = YerlesimYerleriSO.Instance.UretimAlaniContainerArray[i].savasEkipmanlari;
                    uretim.IsEkipmanlari = YerlesimYerleriSO.Instance.UretimAlaniContainerArray[i].IsEkipmanlari;
                    uretim.konut = YerlesimYerleriSO.Instance.UretimAlaniContainerArray[i].konut;
                    uretim.yapiMalzemeleri = YerlesimYerleriSO.Instance.UretimAlaniContainerArray[i].yapiMalzemeleri;
                    uretim.gidaUrunleri = YerlesimYerleriSO.Instance.UretimAlaniContainerArray[i].gidaUrunleri;
                    transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = uretim.name;
                }
            }
        }

    }

    public object[] GetBuildDataStatics()
    {
        return YeniAlan.GetFieldData();
        

    }


    
        
    



}
