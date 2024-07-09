using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class AskerUretmeMenuControler : MonoBehaviour
{

    private Button[] AskerButtonlar;
    private int SonSecilenButtonIndex = 0;

    [SerializeField] private Button SavasciButtonu;
    [SerializeField] private Button OkcuButtonu;
    [SerializeField] private Button BuyucuButtonu;
    [SerializeField] private TextMeshProUGUI RezervText;
    [SerializeField] private Slider askerSlider;
    [SerializeField] private Transform AskerUretmeGereksinimleri;
    [SerializeField] private Button AskerUretButton;

    private int savasciRezerv;
    private int okcuRezerv;
    private int buyucuRezerv;


    private int recruitSavasciSayisi;
    private int recruitOkcuSayisi;
    private int recruitBuyucuSayisi;


    private int mevcutGoldMaliyeti;
    private int mevcutFoodMaliyeti;
    private int mevcutSavasMaliyeti;



    private void Awake()
    {
        AskerButtonlar = new[] { SavasciButtonu, OkcuButtonu, BuyucuButtonu };
        SavasciButtonu.onClick.AddListener(ButtonClickedMethod);
        OkcuButtonu.onClick.AddListener(ButtonClickedMethod);
        BuyucuButtonu.onClick.AddListener(ButtonClickedMethod);


        

        

    }
    private void OnEnable()
    {
        SonSecilenButtonIndex = 0;
        InitializeAskerGereksinimleri();
        SavasciButtonu.Select();
        OkcuButtonu.Select();
        BuyucuButtonu.Select();
        ButtonClickedMethod();
    }

    private void ButtonClickedMethod()
    {
        
        for (int i = 0; i < AskerButtonlar.Length; i++)
        {
            if (AskerButtonlar[i].name == EventSystem.current.currentSelectedGameObject.name)
            {
                SonSecilenButtonIndex = i;
            }
        }
        InitializeAskerGereksinimleri();
        SliderValueChangemethod();
        askerSlider.value = askerSlider.minValue;
    }

    private void InitializeAskerGereksinimleri()
    {

        savasciRezerv = (int)((Kale)GameManager.Instance.sonTiklananYerlesimAlani.YeniAlan).mevcutSavasciRezervleri;
        okcuRezerv = (int)((Kale)GameManager.Instance.sonTiklananYerlesimAlani.YeniAlan).mevcutOkcuRezervleri;
        buyucuRezerv = (int)((Kale)GameManager.Instance.sonTiklananYerlesimAlani.YeniAlan).mevcutBuyucuRezervleri;

        TextMeshProUGUI goldText, foodText, savasEkipmaniText;
        Image goldImage, foodImage, savasEkipmaniImage;
        
        goldText = AskerUretmeGereksinimleri.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        foodText = AskerUretmeGereksinimleri.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        savasEkipmaniText = AskerUretmeGereksinimleri.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();

        goldImage = AskerUretmeGereksinimleri.GetChild(0).GetComponent<Image>();
        foodImage = AskerUretmeGereksinimleri.GetChild(1).GetComponent<Image>();
        savasEkipmaniImage = AskerUretmeGereksinimleri.GetChild(2).GetComponent<Image>();

        goldText.text = AskerTipleriSO.Instance.TumAskerTipleri[SonSecilenButtonIndex].paraMaliyeti.ToString();
        foodText.text = AskerTipleriSO.Instance.TumAskerTipleri[SonSecilenButtonIndex].yemekMaliyeti.ToString();
        savasEkipmaniText.text = AskerTipleriSO.Instance.TumAskerTipleri[SonSecilenButtonIndex].SavasEkipmaniMaliyeti.ToString();

        goldImage.sprite = AskerTipleriSO.Instance.TumAskerTipleri[SonSecilenButtonIndex].GoldImage;
        foodImage.sprite = UrunlerSO.Instance.TumUrunlerSO[4].image;
        savasEkipmaniImage.sprite = UrunlerSO.Instance.TumUrunlerSO[1].image;



        if(SonSecilenButtonIndex == 0)
        {
            RezervText.text = "Mevcut Rezerv : " + savasciRezerv;
            askerSlider.maxValue = savasciRezerv;

            recruitSavasciSayisi = (int)askerSlider.value;
            recruitOkcuSayisi = 0;
            recruitBuyucuSayisi = 0;

        }
        else if (SonSecilenButtonIndex == 1)
        {
            RezervText.text = "Mevcut Rezerv : " + okcuRezerv;
            askerSlider.maxValue = okcuRezerv;

            recruitSavasciSayisi = 0;
            recruitOkcuSayisi = (int)askerSlider.value;
            recruitBuyucuSayisi = 0;
        }
        else if(SonSecilenButtonIndex == 2)
        {
            RezervText.text = "Mevcut Rezerv : " + buyucuRezerv;
            askerSlider.maxValue = buyucuRezerv;

            recruitSavasciSayisi = 0;
            recruitOkcuSayisi = 0;
            recruitBuyucuSayisi = (int)askerSlider.value;
        }
        

        

    }

    public void SliderValueChangemethod()
    {
        TextMeshProUGUI goldText, foodText, savasEkipmaniText;

        goldText = AskerUretmeGereksinimleri.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        foodText = AskerUretmeGereksinimleri.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        savasEkipmaniText = AskerUretmeGereksinimleri.GetChild(2).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();

        mevcutGoldMaliyeti = (int)(AskerTipleriSO.Instance.TumAskerTipleri[SonSecilenButtonIndex].paraMaliyeti * askerSlider.value);
        mevcutFoodMaliyeti = (int)(AskerTipleriSO.Instance.TumAskerTipleri[SonSecilenButtonIndex].yemekMaliyeti * askerSlider.value);
        mevcutSavasMaliyeti = (int)(AskerTipleriSO.Instance.TumAskerTipleri[SonSecilenButtonIndex].SavasEkipmaniMaliyeti * askerSlider.value);

        goldText.text = "( " + mevcutGoldMaliyeti + " )";
        foodText.text = "( " + mevcutFoodMaliyeti + " )";
        savasEkipmaniText.text = "( " + mevcutSavasMaliyeti + " )";

        Debug.Log(mevcutGoldMaliyeti);
        Debug.Log(mevcutSavasMaliyeti);
        Debug.Log(mevcutFoodMaliyeti);
        Debug.Log(GameManager.Instance.moneyCount);
        Debug.Log(GameManager.Instance.sonTiklananYerlesimAlani.YeniAlan.savasEkipmanlari);
        Debug.Log(GameManager.Instance.sonTiklananYerlesimAlani.YeniAlan.gidaUrunleri);
        if(mevcutGoldMaliyeti <= GameManager.Instance.moneyCount &&
            mevcutSavasMaliyeti <= GameManager.Instance.sonTiklananYerlesimAlani.YeniAlan.savasEkipmanlari &&
            mevcutFoodMaliyeti <= GameManager.Instance.sonTiklananYerlesimAlani.YeniAlan.gidaUrunleri)
        {
            AskerUretButton.interactable = true;
        }
        else
        {
            AskerUretButton.interactable = false;
        }

        if (SonSecilenButtonIndex == 0)
        {

            recruitSavasciSayisi = (int)askerSlider.value;
            recruitOkcuSayisi = 0;
            recruitBuyucuSayisi = 0;

        }
        else if (SonSecilenButtonIndex == 1)
        {
            
            recruitSavasciSayisi = 0;
            recruitOkcuSayisi = (int)askerSlider.value;
            recruitBuyucuSayisi = 0;
        }
        else if (SonSecilenButtonIndex == 2)
        {

            recruitSavasciSayisi = 0;
            recruitOkcuSayisi = 0;
            recruitBuyucuSayisi = (int)askerSlider.value;
        }
    }

    public void AskerUretButtonMethod()
    {
        GameManager.Instance.sonTiklananYerlesimAlani.YeniAlan.savasEkipmanlari -= mevcutSavasMaliyeti;
        GameManager.Instance.sonTiklananYerlesimAlani.YeniAlan.gidaUrunleri -= mevcutFoodMaliyeti;
        GameManager.Instance.moneyCount -= mevcutGoldMaliyeti;

        
        UIManager.Instance.InitializeYanMenu(GameManager.Instance.sonTiklananYerlesimAlani.GetBuildDataStatics());



        GameManager.Instance.kontrolEdilenBirlik.AskerArtir(recruitSavasciSayisi,recruitBuyucuSayisi,recruitOkcuSayisi);

    }

}
