using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region SKELETON
    public static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }
            return instance;
        }
    }
    #endregion

    [SerializeField]public GameObject yerlesimYeriMenu;
    [SerializeField]public GameObject sehirMenuTab;
    [SerializeField]public GameObject koyMenuTab;
    [SerializeField]public GameObject kaleMenuTab;
    [SerializeField]public GameObject uretimAlaniTab;
    [SerializeField]public GameObject askerMenu;
    [SerializeField]public GameObject SavasFormasyonMenusu;
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] TextMeshProUGUI dayText;
    


    public bool isPressedDemirci;


    private void Update()
    {
        
        //HammaddeArttirma();
    }
    public void AskerMenuAc(bool askerMenuAcildiMi)
    {
        if(askerMenuAcildiMi && GameManager.Instance.sonTiklananYerlesimAlani.yerlesimEnum == YerlesimAlaniEnum.KALE)
        {
            askerMenu.SetActive(true);
        }
        else if(!askerMenuAcildiMi)
        {
            askerMenu.SetActive(false);
        }
        else
        {
            askerMenu.SetActive(false);
            Debug.Log("Asker Menusu sadece Kalede acilabilir.");
        }
    }

    public void YerlesimMenuAc(bool menuAcildimi)
    {
        if (menuAcildimi == true && GameManager.Instance.sonTiklananYerlesimAlani.yerlesimEnum == YerlesimAlaniEnum.SEHIR)
        {
            sehirMenuTab.gameObject.SetActive(true);
            koyMenuTab.gameObject.SetActive(false);
            kaleMenuTab.gameObject.SetActive(false);
            uretimAlaniTab.gameObject.SetActive(false);
        }
        if (menuAcildimi == true && GameManager.Instance.sonTiklananYerlesimAlani.yerlesimEnum == YerlesimAlaniEnum.KOY)
        {
            koyMenuTab.gameObject.SetActive(true);
            sehirMenuTab.gameObject.SetActive(false);
            kaleMenuTab.gameObject.SetActive(false);
            uretimAlaniTab.gameObject.SetActive(false);
        }
        if (menuAcildimi == true && GameManager.Instance.sonTiklananYerlesimAlani.yerlesimEnum == YerlesimAlaniEnum.KALE)
        {
            kaleMenuTab.gameObject.SetActive(true);
            koyMenuTab.gameObject.SetActive(false);
            sehirMenuTab.gameObject.SetActive(false);
            uretimAlaniTab.gameObject.SetActive(false);
        }
        if(menuAcildimi == true && GameManager.Instance.sonTiklananYerlesimAlani.yerlesimEnum == YerlesimAlaniEnum.URETIMALANI)
        {
            uretimAlaniTab.gameObject.SetActive(true);
            koyMenuTab.gameObject.SetActive(false);
            kaleMenuTab.gameObject.SetActive(false);
            sehirMenuTab.gameObject.SetActive(false);
        }
        if(!menuAcildimi)
        {
            sehirMenuTab.gameObject.SetActive(false);
            koyMenuTab.gameObject.SetActive(false);
            kaleMenuTab.gameObject.SetActive(false);
            uretimAlaniTab.gameObject.SetActive(false);
        }
    }
    public void InitializeTabMenuLevel(object[] data) 
    {
        if (GameManager.Instance.sonTiklananYerlesimAlani.yerlesimEnum == YerlesimAlaniEnum.SEHIR)
        {
            
            
            sehirMenuTab.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = data[13].ToString();
            sehirMenuTab.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = data[14].ToString();
            sehirMenuTab.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = data[15].ToString();
            InitializeBinaMenu();

            Button DemirciUpgradeButton = sehirMenuTab.transform.GetChild(1).GetChild(0).GetComponent<Button>();
            Button PazarUpgradeButton = sehirMenuTab.transform.GetChild(1).GetChild(1).GetComponent<Button>();
            Button KonutUpgradeButton = sehirMenuTab.transform.GetChild(1).GetChild(2).GetComponent<Button>();

            bool demirciBinaYapilabilirMi = BinaKontrolMaliyet(1);
            bool PazarBinaYapilabilirMi = BinaKontrolMaliyet(3);
            bool KonutBinaYapilabilirMi = BinaKontrolMaliyet(2);

            DemirciUpgradeButton.interactable = demirciBinaYapilabilirMi;
            PazarUpgradeButton.interactable = PazarBinaYapilabilirMi;
            KonutUpgradeButton.interactable = KonutBinaYapilabilirMi;

        }
        if (GameManager.Instance.sonTiklananYerlesimAlani.yerlesimEnum == YerlesimAlaniEnum.KOY)
        {   
            
            koyMenuTab.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = data[13].ToString();
            koyMenuTab.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = data[14].ToString();
            InitializeBinaMenu();

            Button KonutUpgradeButton = koyMenuTab.transform.GetChild(1).GetComponent<Button>();
            Button FirinUpgradeButton = koyMenuTab.transform.GetChild(2).GetComponent<Button>();

            bool konutBInaYapilabildiMi;
            bool firinBinaYapilabildiMi;

            konutBInaYapilabildiMi = BinaKontrolMaliyet(2);
            firinBinaYapilabildiMi = BinaKontrolMaliyet(4);

            KonutUpgradeButton.interactable = konutBInaYapilabildiMi;
            FirinUpgradeButton.interactable = firinBinaYapilabildiMi;

        }
        if (GameManager.Instance.sonTiklananYerlesimAlani.yerlesimEnum == YerlesimAlaniEnum.KALE)
        {
            
            kaleMenuTab.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = data[13].ToString();
            kaleMenuTab.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = data[15].ToString();
            InitializeBinaMenu();

            Button AskerKislaUpgradeButton = kaleMenuTab.transform.GetChild(1).GetComponent<Button>();
            Button KonutUpgradeButton = kaleMenuTab.transform.GetChild(2).GetComponent<Button>();

            bool askerKislaYapilabildiMi;
            bool konutYapilabildiMi;

            askerKislaYapilabildiMi = BinaKontrolMaliyet(0);
            konutYapilabildiMi = BinaKontrolMaliyet(2);

            AskerKislaUpgradeButton.interactable = askerKislaYapilabildiMi;
            KonutUpgradeButton.interactable = konutYapilabildiMi;


        }
        if (GameManager.Instance.sonTiklananYerlesimAlani.yerlesimEnum == YerlesimAlaniEnum.URETIMALANI)
        {

            uretimAlaniTab.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = data[13].ToString();
            InitializeBinaMenu();

            Button UretimSeviyesiButton = uretimAlaniTab.transform.GetChild(1).GetComponent<Button>();

            bool uretimYapilabildiMi;

            uretimYapilabildiMi = BinaKontrolMaliyet(5);

            UretimSeviyesiButton.interactable = uretimYapilabildiMi;

        }
        

    }
    public void InitializeBinaMenu()
    {
        if (GameManager.Instance.sonTiklananYerlesimAlani.yerlesimEnum == YerlesimAlaniEnum.SEHIR)
        {
            Transform BinaYapMenu = sehirMenuTab.transform.GetChild(1);
            Sehir mevcutSehir = (Sehir)GameManager.Instance.sonTiklananYerlesimAlani.YeniAlan;
            #region DemirciUpgrade
            //BinaYapMenu.GetChild(0).GetComponent<Image>().sprite = BinalarSO.Instance.TumBinaTipleri[0].BinaSprite;//Button Image


            BinaYapMenu.GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[0].image;//Image Demirci Hammadde
            BinaYapMenu.GetChild(0).GetChild(1).GetChild(1).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[1].image;//Image Demirci Savas
            BinaYapMenu.GetChild(0).GetChild(1).GetChild(2).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[2].image;//Image Demirci IsEKipman
            BinaYapMenu.GetChild(0).GetChild(1).GetChild(3).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[3].image;//Image Demirci YapiMalze
            BinaYapMenu.GetChild(0).GetChild(1).GetChild(4).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[4].image;//Image Demirci GidaUrunleri
            if(mevcutSehir.currentDemirciLevel == 0)
            {
                BinaYapMenu.GetChild(0).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[1].levelMaliyet[0].maliyetHamMaddeUrunleri.ToString(); // Level 1 maliyetHamMaddeUrunleri;
                BinaYapMenu.GetChild(0).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[1].levelMaliyet[0].maliyetsavasEkipmanlari.ToString(); // Level 1 maliyetsavasEkipmanlari;
                BinaYapMenu.GetChild(0).GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[1].levelMaliyet[0].maliyetIsEkipmanlari.ToString(); // Level 1 maliyetIsEkipmanlari;
                BinaYapMenu.GetChild(0).GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[1].levelMaliyet[0].maliyetyapiMalzemeleri.ToString(); // Level 1 maliyetyapiMalzemeleri;
                BinaYapMenu.GetChild(0).GetChild(2).GetChild(4).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[1].levelMaliyet[0].maliyetgidaUrunleri.ToString(); // Level 1 maliyetgidaUrunleri;

            }
            else if(mevcutSehir.currentDemirciLevel == 1)
            {
                BinaYapMenu.GetChild(0).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[1].levelMaliyet[1].maliyetHamMaddeUrunleri.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(0).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[1].levelMaliyet[1].maliyetsavasEkipmanlari.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(0).GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[1].levelMaliyet[1].maliyetIsEkipmanlari.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(0).GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[1].levelMaliyet[1].maliyetyapiMalzemeleri.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(0).GetChild(2).GetChild(4).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[1].levelMaliyet[1].maliyetgidaUrunleri.ToString(); // Level 2 Maliyet;

            }
            else if (mevcutSehir.currentDemirciLevel == 2)
            {
                BinaYapMenu.GetChild(0).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[1].levelMaliyet[2].maliyetHamMaddeUrunleri.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(0).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[1].levelMaliyet[2].maliyetsavasEkipmanlari.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(0).GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[1].levelMaliyet[2].maliyetIsEkipmanlari.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(0).GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[1].levelMaliyet[2].maliyetyapiMalzemeleri.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(0).GetChild(2).GetChild(4).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[1].levelMaliyet[2].maliyetgidaUrunleri.ToString(); // Level 2 Maliyet;

            }
            #endregion
            #region PazarUpgrade
            //BinaYapMenu.GetChild(1).GetComponent<Image>().sprite = BinalarSO.Instance.TumBinaTipleri[3].BinaSprite;//Button Image


            BinaYapMenu.GetChild(1).GetChild(1).GetChild(0).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[0].image;//Image Demirci Hammadde
            BinaYapMenu.GetChild(1).GetChild(1).GetChild(1).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[1].image;//Image Demirci Savas
            BinaYapMenu.GetChild(1).GetChild(1).GetChild(2).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[2].image;//Image Demirci IsEKipman
            BinaYapMenu.GetChild(1).GetChild(1).GetChild(3).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[3].image;//Image Demirci YapiMalze
            BinaYapMenu.GetChild(1).GetChild(1).GetChild(4).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[4].image;//Image Demirci GidaUrunleri
            if (mevcutSehir.currentPazarYeriLevel == 0)
            {
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[0].maliyetHamMaddeUrunleri.ToString(); // Level 1 maliyetHamMaddeUrunleri;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[0].maliyetsavasEkipmanlari.ToString(); // Level 1 maliyetsavasEkipmanlari;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[0].maliyetIsEkipmanlari.ToString(); // Level 1 maliyetIsEkipmanlari;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[0].maliyetyapiMalzemeleri.ToString(); // Level 1 maliyetyapiMalzemeleri;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(4).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[0].maliyetgidaUrunleri.ToString(); // Level 1 maliyetgidaUrunleri;

            }
            else if (mevcutSehir.currentPazarYeriLevel == 1)
            {
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[1].maliyetHamMaddeUrunleri.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[1].maliyetsavasEkipmanlari.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[1].maliyetIsEkipmanlari.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[1].maliyetyapiMalzemeleri.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(4).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[1].maliyetgidaUrunleri.ToString(); // Level 2 Maliyet;

            }
            else if (mevcutSehir.currentPazarYeriLevel == 2)
            {
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[2].maliyetHamMaddeUrunleri.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[2].maliyetsavasEkipmanlari.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[2].maliyetIsEkipmanlari.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[2].maliyetyapiMalzemeleri.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(4).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[2].maliyetgidaUrunleri.ToString(); // Level 2 Maliyet;

            }
            #endregion
            #region KonutUpgrade
            //BinaYapMenu.GetChild(2).GetComponent<Image>().sprite = BinalarSO.Instance.TumBinaTipleri[2].BinaSprite;//Button Image


            BinaYapMenu.GetChild(2).GetChild(1).GetChild(0).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[0].image;//Image Demirci Hammadde
            BinaYapMenu.GetChild(2).GetChild(1).GetChild(1).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[1].image;//Image Demirci Savas
            BinaYapMenu.GetChild(2).GetChild(1).GetChild(2).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[2].image;//Image Demirci IsEKipman
            BinaYapMenu.GetChild(2).GetChild(1).GetChild(3).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[3].image;//Image Demirci YapiMalze
            BinaYapMenu.GetChild(2).GetChild(1).GetChild(4).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[4].image;//Image Demirci GidaUrunleri
            if (mevcutSehir.currentKonutLevel == 0)
            {
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[3].levelMaliyet[0].maliyetHamMaddeUrunleri.ToString(); // Level 1 maliyetHamMaddeUrunleri;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[3].levelMaliyet[0].maliyetsavasEkipmanlari.ToString(); // Level 1 maliyetsavasEkipmanlari;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[3].levelMaliyet[0].maliyetIsEkipmanlari.ToString(); // Level 1 maliyetIsEkipmanlari;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[3].levelMaliyet[0].maliyetyapiMalzemeleri.ToString(); // Level 1 maliyetyapiMalzemeleri;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(4).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[3].levelMaliyet[0].maliyetgidaUrunleri.ToString(); // Level 1 maliyetgidaUrunleri;

            }
            else if (mevcutSehir.currentKonutLevel == 1)
            {
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[3].levelMaliyet[1].maliyetHamMaddeUrunleri.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[3].levelMaliyet[1].maliyetsavasEkipmanlari.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[3].levelMaliyet[1].maliyetIsEkipmanlari.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[3].levelMaliyet[1].maliyetyapiMalzemeleri.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(4).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[3].levelMaliyet[1].maliyetgidaUrunleri.ToString(); // Level 2 Maliyet;

            }
            else if (mevcutSehir.currentKonutLevel == 2)
            {
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[3].levelMaliyet[2].maliyetHamMaddeUrunleri.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[3].levelMaliyet[2].maliyetsavasEkipmanlari.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[3].levelMaliyet[2].maliyetIsEkipmanlari.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[3].levelMaliyet[2].maliyetyapiMalzemeleri.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(4).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[3].levelMaliyet[2].maliyetgidaUrunleri.ToString(); // Level 2 Maliyet;

            }
            #endregion
        }
        if (GameManager.Instance.sonTiklananYerlesimAlani.yerlesimEnum == YerlesimAlaniEnum.KOY)
        {
            Transform BinaYapMenu = koyMenuTab.transform;
            Koy mevcutKoy = (Koy)GameManager.Instance.sonTiklananYerlesimAlani.YeniAlan;
            #region KonutLevel
            //BinaYapMenu.GetChild(1).GetComponent<Image>().sprite = BinalarSO.Instance.TumBinaTipleri[0].BinaSprite;//Button Image


            BinaYapMenu.GetChild(1).GetChild(1).GetChild(0).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[0].image;//Image Demirci Hammadde
            BinaYapMenu.GetChild(1).GetChild(1).GetChild(1).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[1].image;//Image Demirci Savas
            BinaYapMenu.GetChild(1).GetChild(1).GetChild(2).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[2].image;//Image Demirci IsEKipman
            BinaYapMenu.GetChild(1).GetChild(1).GetChild(3).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[3].image;//Image Demirci YapiMalze
            BinaYapMenu.GetChild(1).GetChild(1).GetChild(4).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[4].image;//Image Demirci GidaUrunleri
            if (mevcutKoy.currentKonutLevel == 0)
            {
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[0].maliyetHamMaddeUrunleri.ToString(); // Level 1 maliyetHamMaddeUrunleri;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[0].maliyetsavasEkipmanlari.ToString(); // Level 1 maliyetsavasEkipmanlari;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[0].maliyetIsEkipmanlari.ToString(); // Level 1 maliyetIsEkipmanlari;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[0].maliyetyapiMalzemeleri.ToString(); // Level 1 maliyetyapiMalzemeleri;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(4).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[0].maliyetgidaUrunleri.ToString(); // Level 1 maliyetgidaUrunleri;

            }
            else if (mevcutKoy.currentKonutLevel == 1)
            {
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[1].maliyetHamMaddeUrunleri.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[1].maliyetsavasEkipmanlari.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[1].maliyetIsEkipmanlari.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[1].maliyetyapiMalzemeleri.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(4).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[1].maliyetgidaUrunleri.ToString(); // Level 2 Maliyet;

            }
            else if (mevcutKoy.currentKonutLevel == 2)
            {
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[2].maliyetHamMaddeUrunleri.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[2].maliyetsavasEkipmanlari.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[2].maliyetIsEkipmanlari.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[2].maliyetyapiMalzemeleri.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(4).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[2].maliyetgidaUrunleri.ToString(); // Level 2 Maliyet;

            }
            #endregion
            #region FirinUpgrade
            //BinaYapMenu.GetChild(2).GetComponent<Image>().sprite = BinalarSO.Instance.TumBinaTipleri[0].BinaSprite;//Button Image


            BinaYapMenu.GetChild(2).GetChild(1).GetChild(0).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[0].image;//Image Demirci Hammadde
            BinaYapMenu.GetChild(2).GetChild(1).GetChild(1).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[1].image;//Image Demirci Savas
            BinaYapMenu.GetChild(2).GetChild(1).GetChild(2).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[2].image;//Image Demirci IsEKipman
            BinaYapMenu.GetChild(2).GetChild(1).GetChild(3).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[3].image;//Image Demirci YapiMalze
            BinaYapMenu.GetChild(2).GetChild(1).GetChild(4).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[4].image;//Image Demirci GidaUrunleri
            if (mevcutKoy.currentFirinLevel == 0)
            {
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[4].levelMaliyet[0].maliyetHamMaddeUrunleri.ToString(); // Level 1 maliyetHamMaddeUrunleri;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[4].levelMaliyet[0].maliyetsavasEkipmanlari.ToString(); // Level 1 maliyetsavasEkipmanlari;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[4].levelMaliyet[0].maliyetIsEkipmanlari.ToString(); // Level 1 maliyetIsEkipmanlari;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[4].levelMaliyet[0].maliyetyapiMalzemeleri.ToString(); // Level 1 maliyetyapiMalzemeleri;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(4).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[4].levelMaliyet[0].maliyetgidaUrunleri.ToString(); // Level 1 maliyetgidaUrunleri;

            }
            else if (mevcutKoy.currentFirinLevel == 1)
            {
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[4].levelMaliyet[1].maliyetHamMaddeUrunleri.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[4].levelMaliyet[1].maliyetsavasEkipmanlari.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[4].levelMaliyet[1].maliyetIsEkipmanlari.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[4].levelMaliyet[1].maliyetyapiMalzemeleri.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(4).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[4].levelMaliyet[1].maliyetgidaUrunleri.ToString(); // Level 2 Maliyet;

            }
            else if (mevcutKoy.currentFirinLevel == 2)
            {
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[4].levelMaliyet[2].maliyetHamMaddeUrunleri.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[4].levelMaliyet[2].maliyetsavasEkipmanlari.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[4].levelMaliyet[2].maliyetIsEkipmanlari.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[4].levelMaliyet[2].maliyetyapiMalzemeleri.ToString(); // Level 2 Maliyet;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(4).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[4].levelMaliyet[2].maliyetgidaUrunleri.ToString(); // Level 2 Maliyet;

            }
            #endregion
        }
        if (GameManager.Instance.sonTiklananYerlesimAlani.yerlesimEnum == YerlesimAlaniEnum.KALE)
        {
            Transform BinaYapMenu = kaleMenuTab.transform;
            Kale mevcutKale = (Kale)GameManager.Instance.sonTiklananYerlesimAlani.YeniAlan;
            #region AskeriKisla
            //BinaYapMenu.GetChild(1).GetComponent<Image>().sprite = BinalarSO.Instance.TumBinaTipleri[0].BinaSprite;//Button Image


            BinaYapMenu.GetChild(1).GetChild(1).GetChild(0).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[0].image;//Image  Hammadde
            BinaYapMenu.GetChild(1).GetChild(1).GetChild(1).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[1].image;//Image  Savas
            BinaYapMenu.GetChild(1).GetChild(1).GetChild(2).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[2].image;//Image  IsEKipman
            BinaYapMenu.GetChild(1).GetChild(1).GetChild(3).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[3].image;//Image  YapiMalze
            BinaYapMenu.GetChild(1).GetChild(1).GetChild(4).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[4].image;//Image  GidaUrunleri\
            if(mevcutKale.currentAskeriKislaLevel == 0)
            {
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[0].levelMaliyet[0].maliyetHamMaddeUrunleri.ToString(); // Level 1 maliyetHamMaddeUrunleri;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[0].levelMaliyet[0].maliyetsavasEkipmanlari.ToString(); // Level 1 maliyetsavasEkipmanlari;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[0].levelMaliyet[0].maliyetIsEkipmanlari.ToString(); // Level 1 maliyetIsEkipmanlari;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[0].levelMaliyet[0].maliyetyapiMalzemeleri.ToString(); // Level 1 maliyetyapiMalzemeleri;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(4).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[0].levelMaliyet[0].maliyetgidaUrunleri.ToString(); // Level 1 maliyetgidaUrunleri;
            }
            else if(mevcutKale.currentAskeriKislaLevel == 1)
            {
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[0].levelMaliyet[1].maliyetHamMaddeUrunleri.ToString(); // Level 1 maliyetHamMaddeUrunleri;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[0].levelMaliyet[1].maliyetsavasEkipmanlari.ToString(); // Level 1 maliyetsavasEkipmanlari;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[0].levelMaliyet[1].maliyetIsEkipmanlari.ToString(); // Level 1 maliyetIsEkipmanlari;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[0].levelMaliyet[1].maliyetyapiMalzemeleri.ToString(); // Level 1 maliyetyapiMalzemeleri;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(4).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[0].levelMaliyet[1].maliyetgidaUrunleri.ToString(); // Level 1 maliyetgidaUrunleri;
            }
            else if (mevcutKale.currentAskeriKislaLevel == 2)
            {
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[0].levelMaliyet[2].maliyetHamMaddeUrunleri.ToString(); // Level 1 maliyetHamMaddeUrunleri;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[0].levelMaliyet[2].maliyetsavasEkipmanlari.ToString(); // Level 1 maliyetsavasEkipmanlari;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[0].levelMaliyet[2].maliyetIsEkipmanlari.ToString(); // Level 1 maliyetIsEkipmanlari;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[0].levelMaliyet[2].maliyetyapiMalzemeleri.ToString(); // Level 1 maliyetyapiMalzemeleri;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(4).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[0].levelMaliyet[2].maliyetgidaUrunleri.ToString(); // Level 1 maliyetgidaUrunleri;
            }
            #endregion
            #region KonutUpgrade
            //BinaYapMenu.GetChild(2).GetComponent<Image>().sprite = BinalarSO.Instance.TumBinaTipleri[0].BinaSprite;//Button Image


            BinaYapMenu.GetChild(2).GetChild(1).GetChild(0).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[0].image;//Image  Hammadde
            BinaYapMenu.GetChild(2).GetChild(1).GetChild(1).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[1].image;//Image  Savas
            BinaYapMenu.GetChild(2).GetChild(1).GetChild(2).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[2].image;//Image  IsEKipman
            BinaYapMenu.GetChild(2).GetChild(1).GetChild(3).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[3].image;//Image  YapiMalze
            BinaYapMenu.GetChild(2).GetChild(1).GetChild(4).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[4].image;//Image  GidaUrunleri\
            if (mevcutKale.currentKonutLevel == 0)
            {
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[0].maliyetHamMaddeUrunleri.ToString(); // Level 1 maliyetHamMaddeUrunleri;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[0].maliyetsavasEkipmanlari.ToString(); // Level 1 maliyetsavasEkipmanlari;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[0].maliyetIsEkipmanlari.ToString(); // Level 1 maliyetIsEkipmanlari;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[0].maliyetyapiMalzemeleri.ToString(); // Level 1 maliyetyapiMalzemeleri;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(4).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[0].maliyetgidaUrunleri.ToString(); // Level 1 maliyetgidaUrunleri;
            }
            else if (mevcutKale.currentKonutLevel == 1)
            {
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[1].maliyetHamMaddeUrunleri.ToString(); // Level 1 maliyetHamMaddeUrunleri;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[1].maliyetsavasEkipmanlari.ToString(); // Level 1 maliyetsavasEkipmanlari;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[1].maliyetIsEkipmanlari.ToString(); // Level 1 maliyetIsEkipmanlari;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[1].maliyetyapiMalzemeleri.ToString(); // Level 1 maliyetyapiMalzemeleri;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(4).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[1].maliyetgidaUrunleri.ToString(); // Level 1 maliyetgidaUrunleri;
            }
            else if (mevcutKale.currentKonutLevel == 2)
            {
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[2].maliyetHamMaddeUrunleri.ToString(); // Level 1 maliyetHamMaddeUrunleri;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[2].maliyetsavasEkipmanlari.ToString(); // Level 1 maliyetsavasEkipmanlari;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[2].maliyetIsEkipmanlari.ToString(); // Level 1 maliyetIsEkipmanlari;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[2].maliyetyapiMalzemeleri.ToString(); // Level 1 maliyetyapiMalzemeleri;
                BinaYapMenu.GetChild(2).GetChild(2).GetChild(4).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[2].levelMaliyet[2].maliyetgidaUrunleri.ToString(); // Level 1 maliyetgidaUrunleri;
            }
            #endregion
        }
        if (GameManager.Instance.sonTiklananYerlesimAlani.yerlesimEnum == YerlesimAlaniEnum.URETIMALANI)
        {
            Transform BinaYapMenu = uretimAlaniTab.transform;
            UretimAlani mevcutUretim = (UretimAlani)GameManager.Instance.sonTiklananYerlesimAlani.YeniAlan;
            #region UretimUpgrade
            //BinaYapMenu.GetChild(1).GetComponent<Image>().sprite = BinalarSO.Instance.TumBinaTipleri[0].BinaSprite;//Button Image


            BinaYapMenu.GetChild(1).GetChild(1).GetChild(0).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[0].image;//Image  Hammadde
            BinaYapMenu.GetChild(1).GetChild(1).GetChild(1).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[1].image;//Image  Savas
            BinaYapMenu.GetChild(1).GetChild(1).GetChild(2).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[2].image;//Image  IsEKipman
            BinaYapMenu.GetChild(1).GetChild(1).GetChild(3).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[3].image;//Image  YapiMalze
            BinaYapMenu.GetChild(1).GetChild(1).GetChild(4).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[4].image;//Image  GidaUrunleri\
            if (mevcutUretim.currentUretimSeviyesi == 0)
            {
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[5].levelMaliyet[0].maliyetHamMaddeUrunleri.ToString(); // Level 1 maliyetHamMaddeUrunleri;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[5].levelMaliyet[0].maliyetsavasEkipmanlari.ToString(); // Level 1 maliyetsavasEkipmanlari;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[5].levelMaliyet[0].maliyetIsEkipmanlari.ToString(); // Level 1 maliyetIsEkipmanlari;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[5].levelMaliyet[0].maliyetyapiMalzemeleri.ToString(); // Level 1 maliyetyapiMalzemeleri;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(4).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[5].levelMaliyet[0].maliyetgidaUrunleri.ToString(); // Level 1 maliyetgidaUrunleri;
            }
            else if (mevcutUretim.currentUretimSeviyesi == 1)
            {
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[5].levelMaliyet[1].maliyetHamMaddeUrunleri.ToString(); // Level 1 maliyetHamMaddeUrunleri;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[5].levelMaliyet[1].maliyetsavasEkipmanlari.ToString(); // Level 1 maliyetsavasEkipmanlari;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[5].levelMaliyet[1].maliyetIsEkipmanlari.ToString(); // Level 1 maliyetIsEkipmanlari;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[5].levelMaliyet[1].maliyetyapiMalzemeleri.ToString(); // Level 1 maliyetyapiMalzemeleri;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(4).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[5].levelMaliyet[1].maliyetgidaUrunleri.ToString(); // Level 1 maliyetgidaUrunleri;
            }
            else if (mevcutUretim.currentUretimSeviyesi == 2)
            {
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[5].levelMaliyet[2].maliyetHamMaddeUrunleri.ToString(); // Level 1 maliyetHamMaddeUrunleri;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[5].levelMaliyet[2].maliyetsavasEkipmanlari.ToString(); // Level 1 maliyetsavasEkipmanlari;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[5].levelMaliyet[2].maliyetIsEkipmanlari.ToString(); // Level 1 maliyetIsEkipmanlari;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[5].levelMaliyet[2].maliyetyapiMalzemeleri.ToString(); // Level 1 maliyetyapiMalzemeleri;
                BinaYapMenu.GetChild(1).GetChild(2).GetChild(4).GetComponent<TextMeshProUGUI>().text = BinalarSO.Instance.TumBinaTipleri[5].levelMaliyet[2].maliyetgidaUrunleri.ToString(); // Level 1 maliyetgidaUrunleri;
            }
            #endregion
        }
    }
    public bool BinaKontrolMaliyet(int bakilacakIndexNo)
    {
        



        int[][] tumBinaMaliyetleri =
        {
            new int[6], new int[6], new int[6],new int[6],new int[6],new int[6]
        };


        object[] alinanDegerler;
        if (GameManager.Instance.sonTiklananYerlesimAlani.yerlesimEnum == YerlesimAlaniEnum.SEHIR)
        {
            Sehir mevcutSehir = (Sehir)GameManager.Instance.sonTiklananYerlesimAlani.YeniAlan;
            #region Demirci
            if (mevcutSehir.currentDemirciLevel == 0)
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetHamMaddeUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetsavasEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][2] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetIsEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][3] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetyapiMalzemeleri;
                tumBinaMaliyetleri[bakilacakIndexNo][4] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetgidaUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][5] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetMoney;
            }
            else if (mevcutSehir.currentDemirciLevel == 1)
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0]= BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetHamMaddeUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetsavasEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][2]= BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetIsEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][3] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetyapiMalzemeleri;
                tumBinaMaliyetleri[bakilacakIndexNo][4] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetgidaUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][5]=BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetMoney;
            }
            else if (mevcutSehir.currentDemirciLevel == 2)
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetHamMaddeUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetsavasEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][2] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetIsEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][3] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetyapiMalzemeleri;
                tumBinaMaliyetleri[bakilacakIndexNo][4] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetgidaUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][5] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetMoney;

            }
            else
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][2] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][3] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][4] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][5] = 9999;
            }
            #endregion
            #region PazarYeri
            if (mevcutSehir.currentPazarYeriLevel == 0)
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0]= BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetHamMaddeUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetsavasEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][2]= BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetIsEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][3]= BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetyapiMalzemeleri;
                tumBinaMaliyetleri[bakilacakIndexNo][4]= BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetgidaUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][5] =BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetMoney;
            }
            else if (mevcutSehir.currentPazarYeriLevel == 1)
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetHamMaddeUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetsavasEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][2] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetIsEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][3] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetyapiMalzemeleri;
                tumBinaMaliyetleri[bakilacakIndexNo][4] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetgidaUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][5] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetMoney;
            }
            else if (mevcutSehir.currentPazarYeriLevel == 2)
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetHamMaddeUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetsavasEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][2] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetIsEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][3] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetyapiMalzemeleri;
                tumBinaMaliyetleri[bakilacakIndexNo][4] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetgidaUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][5] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetMoney;
            }
            else
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][2] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][3] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][4] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][5] = 9999;
            }
            #endregion
            #region KonutYeri
            if (mevcutSehir.currentKonutLevel == 0)
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetHamMaddeUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetsavasEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][2] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetIsEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][3] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetyapiMalzemeleri;
                tumBinaMaliyetleri[bakilacakIndexNo][4] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetgidaUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][5] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetMoney;
            }
            else if (mevcutSehir.currentKonutLevel == 1)
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetHamMaddeUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetsavasEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][2] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetIsEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][3] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetyapiMalzemeleri;
                tumBinaMaliyetleri[bakilacakIndexNo][4] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetgidaUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][5] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetMoney;
            }
            else if (mevcutSehir.currentKonutLevel == 2)
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetHamMaddeUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetsavasEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][2] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetIsEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][3] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetyapiMalzemeleri;
                tumBinaMaliyetleri[bakilacakIndexNo][4] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetgidaUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][5] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetMoney;
            }
            else
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][2] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][3] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][4] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][5] = 9999;
            }
            #endregion


        }
        else if (GameManager.Instance.sonTiklananYerlesimAlani.yerlesimEnum == YerlesimAlaniEnum.KOY)
        {
            Koy mevcutKoy = (Koy)GameManager.Instance.sonTiklananYerlesimAlani.YeniAlan;
            #region KonutYeri
            if (mevcutKoy.currentKonutLevel == 0)
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetHamMaddeUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetsavasEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][2] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetIsEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][3] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetyapiMalzemeleri;
                tumBinaMaliyetleri[bakilacakIndexNo][4] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetgidaUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][5] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetMoney;
            }
            else if (mevcutKoy.currentKonutLevel == 1)
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetHamMaddeUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetsavasEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][2] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetIsEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][3] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetyapiMalzemeleri;
                tumBinaMaliyetleri[bakilacakIndexNo][4] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetgidaUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][5] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetMoney;
            }
            else if (mevcutKoy.currentKonutLevel == 2)
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetHamMaddeUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetsavasEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][2] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetIsEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][3] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetyapiMalzemeleri;
                tumBinaMaliyetleri[bakilacakIndexNo][4] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetgidaUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][5] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetMoney;
            }
            else
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][2] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][3] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][4] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][5] = 9999;
            }
            #endregion
            #region Firin
            if (mevcutKoy.currentFirinLevel == 0)
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetHamMaddeUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetsavasEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][2] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetIsEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][3] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetyapiMalzemeleri;
                tumBinaMaliyetleri[bakilacakIndexNo][4] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetgidaUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][5] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetMoney;
            }
            else if (mevcutKoy.currentFirinLevel == 1)
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetHamMaddeUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetsavasEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][2] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetIsEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][3] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetyapiMalzemeleri;
                tumBinaMaliyetleri[bakilacakIndexNo][4] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetgidaUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][5] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetMoney;
            }
            else if (mevcutKoy.currentFirinLevel == 2)
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetHamMaddeUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetsavasEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][2] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetIsEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][3] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetyapiMalzemeleri;
                tumBinaMaliyetleri[bakilacakIndexNo][4] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetgidaUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][5] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetMoney;
            }
            else
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][2] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][3] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][4] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][5] = 9999;
            }
            #endregion

        }
        else if (GameManager.Instance.sonTiklananYerlesimAlani.yerlesimEnum == YerlesimAlaniEnum.KALE)
        {
            Kale mevcutKale = (Kale)GameManager.Instance.sonTiklananYerlesimAlani.YeniAlan;
            #region AskeriKisla
            if (mevcutKale.currentAskeriKislaLevel == 0)
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetHamMaddeUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetsavasEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][2] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetIsEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][3] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetyapiMalzemeleri;
                tumBinaMaliyetleri[bakilacakIndexNo][4] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetgidaUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][5] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetMoney;
            }
            else if (mevcutKale.currentAskeriKislaLevel == 1)
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetHamMaddeUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetsavasEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][2] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetIsEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][3] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetyapiMalzemeleri;
                tumBinaMaliyetleri[bakilacakIndexNo][4] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetgidaUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][5] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetMoney;
            }
            else if (mevcutKale.currentAskeriKislaLevel == 2)
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetHamMaddeUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetsavasEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][2] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetIsEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][3] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetyapiMalzemeleri;
                tumBinaMaliyetleri[bakilacakIndexNo][4] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetgidaUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][5] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetMoney;
            }
            else
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][2] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][3] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][4] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][5] = 9999;
            }
            #endregion
            #region KonutYeri
            if (mevcutKale.currentKonutLevel == 0)
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetHamMaddeUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetsavasEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][2] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetIsEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][3] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetyapiMalzemeleri;
                tumBinaMaliyetleri[bakilacakIndexNo][4] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetgidaUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][5] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetMoney;
            }
            else if (mevcutKale.currentKonutLevel == 1)
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetHamMaddeUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetsavasEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][2] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetIsEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][3] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetyapiMalzemeleri;
                tumBinaMaliyetleri[bakilacakIndexNo][4] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetgidaUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][5] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetMoney;
            }
            else if (mevcutKale.currentKonutLevel == 2)
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetHamMaddeUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetsavasEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][2] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetIsEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][3] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetyapiMalzemeleri;
                tumBinaMaliyetleri[bakilacakIndexNo][4] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetgidaUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][5] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetMoney;
            }
            else
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][2] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][3] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][4] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][5] = 9999;
            }
            #endregion
        }
        else
        {
            UretimAlani mevcutUretim = (UretimAlani)GameManager.Instance.sonTiklananYerlesimAlani.YeniAlan;
            #region Uretim
            if (mevcutUretim.currentUretimSeviyesi == 0)
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetHamMaddeUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetsavasEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][2] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetIsEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][3] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetyapiMalzemeleri;
                tumBinaMaliyetleri[bakilacakIndexNo][4] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetgidaUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][5] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[0].maliyetMoney;
            }
            else if (mevcutUretim.currentUretimSeviyesi == 1)
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetHamMaddeUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetsavasEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][2] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetIsEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][3] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetyapiMalzemeleri;
                tumBinaMaliyetleri[bakilacakIndexNo][4] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetgidaUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][5] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[1].maliyetMoney;
            }
            else if (mevcutUretim.currentUretimSeviyesi == 2)
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetHamMaddeUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetsavasEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][2] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetIsEkipmanlari;
                tumBinaMaliyetleri[bakilacakIndexNo][3] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetyapiMalzemeleri;
                tumBinaMaliyetleri[bakilacakIndexNo][4] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetgidaUrunleri;
                tumBinaMaliyetleri[bakilacakIndexNo][5] = BinalarSO.Instance.TumBinaTipleri[bakilacakIndexNo].levelMaliyet[2].maliyetMoney;
            }
            else
            {
                tumBinaMaliyetleri[bakilacakIndexNo][0] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][1] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][2] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][3] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][4] = 9999;
                tumBinaMaliyetleri[bakilacakIndexNo][5] = 9999;
            }
            #endregion

        }






        alinanDegerler = GameManager.Instance.sonTiklananYerlesimAlani.YeniAlan.GetFieldData();




        int mevcutHammade = (int)alinanDegerler[0];
        int mevcutSavasEkipmanlari = (int)alinanDegerler[1];
        int mevcutIsEkipmanlari = (int)alinanDegerler[2];
        int mevcutYapiMalzemeleri = (int)alinanDegerler[4];
        int mevcutGidaUrunleri = (int)alinanDegerler[5];

        if(GameManager.Instance.moneyCount >= tumBinaMaliyetleri[bakilacakIndexNo][5] &&
            mevcutHammade >= tumBinaMaliyetleri[bakilacakIndexNo][0] &&
            mevcutSavasEkipmanlari >= tumBinaMaliyetleri[bakilacakIndexNo][1] &&
            mevcutIsEkipmanlari >= tumBinaMaliyetleri[bakilacakIndexNo][2] &&
            mevcutYapiMalzemeleri >= tumBinaMaliyetleri[bakilacakIndexNo][3] &&
            mevcutGidaUrunleri >= tumBinaMaliyetleri[bakilacakIndexNo][4])
        {
            return true;
        }
        else
        {
            return false;
        }


        
    }

    public void InitializeYanMenu(object[] data)
    {
        yerlesimYeriMenu.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = (string)data[7]; //YerlesimYeriAdi
        yerlesimYeriMenu.transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<Image>().sprite = (Sprite)data[6]; // Image
        yerlesimYeriMenu.transform.GetChild(0).GetChild(0).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = data[0].ToString();
        yerlesimYeriMenu.transform.GetChild(0).GetChild(0).GetChild(3).GetChild(2).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[0].image;

        yerlesimYeriMenu.transform.GetChild(0).GetChild(0).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text = data[1].ToString();
        yerlesimYeriMenu.transform.GetChild(0).GetChild(0).GetChild(4).GetChild(2).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[1].image;

        yerlesimYeriMenu.transform.GetChild(0).GetChild(0).GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>().text = data[2].ToString();
        yerlesimYeriMenu.transform.GetChild(0).GetChild(0).GetChild(5).GetChild(2).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[2].image;

        yerlesimYeriMenu.transform.GetChild(0).GetChild(0).GetChild(6).GetChild(0).GetComponent<TextMeshProUGUI>().text = data[4].ToString();
        yerlesimYeriMenu.transform.GetChild(0).GetChild(0).GetChild(6).GetChild(2).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[3].image;

        yerlesimYeriMenu.transform.GetChild(0).GetChild(0).GetChild(7).GetChild(0).GetComponent<TextMeshProUGUI>().text = data[5].ToString();
        yerlesimYeriMenu.transform.GetChild(0).GetChild(0).GetChild(7).GetChild(2).GetComponent<Image>().sprite = UrunlerSO.Instance.TumUrunlerSO[4].image;

        yerlesimYeriMenu.transform.GetChild(0).GetChild(0).GetChild(8).GetChild(0).GetComponent<TextMeshProUGUI>().text = data[3].ToString();
        



    }

    public void YanMenuAC(bool aciliyorMu)
    {
        if (aciliyorMu && !yerlesimYeriMenu.transform.GetChild(0).gameObject.activeSelf)
        {
            
            yerlesimYeriMenu.transform.GetChild(0).gameObject.SetActive(true);
            
        }
        else if (!aciliyorMu && yerlesimYeriMenu.transform.GetChild(0).gameObject.activeSelf)
        {
            yerlesimYeriMenu.transform.GetChild(0).gameObject.SetActive(false);
            GameManager.Instance.StartGame();
        }
    }

    public void MoneyRefreshText()
    {
        GameManager.Instance.moneyCount += 300;
        moneyText.text = GameManager.Instance.moneyCount.ToString();
    }
    public void HammaddeArttirma()
    {

        
        
        //InitializeYanMenu(GameManager.Instance.sonTiklananYerlesimAlani.GetBuildDataStatics());
        MoneyRefreshText();
    }

    public void TimeDayCounter()
    {
        dayText.text = TimeManager.Instance.dayCounter.ToString();
    }




}
