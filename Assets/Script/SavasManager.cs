using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;


public enum SavasDuzen 
{
    A,B,C
}



[Serializable]
 public class SavasDuzeni
{
    public SavasDuzen duzen;
    public float savasciHasarCarpani;
    public float okcuHasarCarpani;
    public float buyucuHasarCarpani;
    
}




public class SavasManager : MonoBehaviour
{
    #region skeleton
    public static SavasManager instance;
    public static SavasManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SavasManager>();
            }
            return instance;
        }

    }
    #endregion

    [SerializeField]private SavasDuzeni[] savasDuzeni;
    [SerializeField]public BirlikManager AllyUnitSave;

    public SavasDuzeni RivalFormasyonu;
    public SavasDuzeni AllyFormasyonu;

    public BirlikManager RivalUnit;
    public BirlikManager AllyUnit;
    
    public Transform DusmanObject;
    public int isFinishWar;

    public int RivalFormationIndex;
    int[] savasTuruOncesiAllyAskerleri;
    int[] savasTuruOncesiRivalAskerleri;


    private void Awake()
    {
        RivalFormationIndex = UnityEngine.Random.Range(0, 3);
        RivalFormasyonu = savasDuzeni[RivalFormationIndex];
        
    }
    public int SavasSuresiHesapla()
    {
        if (RivalUnit.birlikGucu > 400 && AllyUnit.birlikGucu > 400 && RivalUnit.birlikGucu < 600 && AllyUnit.birlikGucu < 600)
        {
            return 2;
        }
        else if (RivalUnit.birlikGucu < 400 && AllyUnit.birlikGucu > 500 || RivalUnit.birlikGucu > 500 && AllyUnit.birlikGucu < 400)
        {
            return 1;
        }
        else if (RivalUnit.birlikGucu > 600 && AllyUnit.birlikGucu > 600 && RivalUnit.birlikGucu < 1000 && AllyUnit.birlikGucu < 1000)
        {
            return 2;
        }
        else if (RivalUnit.birlikGucu < 600 && AllyUnit.birlikGucu > 700 || RivalUnit.birlikGucu > 700 && AllyUnit.birlikGucu < 600)
        {
            return 1;
        }
        else if(RivalUnit.birlikGucu > 1000 && AllyUnit.birlikGucu > 1000)
        {
            return 2;
        }
        else { return 2; }



    }

    public void SavasTuruSimule()
    {
        if(SavasManager.Instance.isFinishWar == 0)
        {
            int[] savasTuruOncesiAllyAskerleri = { AllyUnit.savasciSayisi, AllyUnit.OkcuSayisi, AllyUnit.buyucuSayisi };
            int[] savasTuruOncesiRivalAskerleri = { RivalUnit.savasciSayisi, RivalUnit.OkcuSayisi, RivalUnit.buyucuSayisi };

            float allySavasciHasari = AllyUnit.savasciSayisi * AllyFormasyonu.savasciHasarCarpani;
            float allyOkcuHasari = AllyUnit.OkcuSayisi * AllyFormasyonu.okcuHasarCarpani;
            float allyBuyucuHasari = AllyUnit.buyucuSayisi * AllyFormasyonu.buyucuHasarCarpani;

            float rivalSavasciHasari = RivalUnit.savasciSayisi * RivalFormasyonu.savasciHasarCarpani;
            float rivalOkcuHasari = RivalUnit.OkcuSayisi * RivalFormasyonu.okcuHasarCarpani;
            float rivalBuyucuHasari = RivalUnit.buyucuSayisi * RivalFormasyonu.buyucuHasarCarpani;

            int oldurulecekRivalAskerSayisi = 0;
            int oldurulecekAllyAskerSayisi = 0;
            if (AllyFormasyonu.duzen == SavasDuzen.A)
            {
                if (RivalFormasyonu.duzen == SavasDuzen.A)
                {
                    oldurulecekRivalAskerSayisi = (int)allySavasciHasari / 30;
                    oldurulecekRivalAskerSayisi += (int)allyOkcuHasari / 30;
                    oldurulecekRivalAskerSayisi += (int)allyBuyucuHasari / 30;

                    oldurulecekAllyAskerSayisi = (int)rivalSavasciHasari / 30;
                    oldurulecekAllyAskerSayisi += (int)rivalOkcuHasari / 30;
                    oldurulecekAllyAskerSayisi += (int)rivalBuyucuHasari / 30;
                }
                else if (RivalFormasyonu.duzen == SavasDuzen.B)
                {
                    oldurulecekRivalAskerSayisi = (int)allySavasciHasari / 30;
                    oldurulecekRivalAskerSayisi += (int)allyOkcuHasari / 30;
                    oldurulecekRivalAskerSayisi += (int)allyBuyucuHasari / 30;

                    oldurulecekAllyAskerSayisi = (int)rivalSavasciHasari / 56;
                    oldurulecekAllyAskerSayisi += (int)rivalOkcuHasari / 56;
                    oldurulecekAllyAskerSayisi += (int)rivalBuyucuHasari / 56;

                }
                else if (RivalFormasyonu.duzen == SavasDuzen.C)
                {
                    oldurulecekRivalAskerSayisi = (int)allySavasciHasari / 56;
                    oldurulecekRivalAskerSayisi += (int)allyOkcuHasari / 56;
                    oldurulecekRivalAskerSayisi += (int)allyBuyucuHasari / 56;

                    oldurulecekAllyAskerSayisi = (int)rivalSavasciHasari / 30;
                    oldurulecekAllyAskerSayisi += (int)rivalOkcuHasari / 30;
                    oldurulecekAllyAskerSayisi += (int)rivalBuyucuHasari / 30;

                }

            }
            if (AllyFormasyonu.duzen == SavasDuzen.B)
            {
                if (RivalFormasyonu.duzen == SavasDuzen.A)
                {
                    oldurulecekRivalAskerSayisi = (int)allySavasciHasari / 56;
                    oldurulecekRivalAskerSayisi += (int)allyOkcuHasari / 56;
                    oldurulecekRivalAskerSayisi += (int)allyBuyucuHasari / 56;

                    oldurulecekAllyAskerSayisi = (int)rivalSavasciHasari / 30;
                    oldurulecekAllyAskerSayisi += (int)rivalOkcuHasari / 30;
                    oldurulecekAllyAskerSayisi += (int)rivalBuyucuHasari / 30;

                }
                else if (RivalFormasyonu.duzen == SavasDuzen.B)
                {
                    oldurulecekRivalAskerSayisi = (int)allySavasciHasari / 30;
                    oldurulecekRivalAskerSayisi += (int)allyOkcuHasari / 30;
                    oldurulecekRivalAskerSayisi += (int)allyBuyucuHasari / 30;

                    oldurulecekAllyAskerSayisi = (int)rivalSavasciHasari / 30;
                    oldurulecekAllyAskerSayisi += (int)rivalOkcuHasari / 30;
                    oldurulecekAllyAskerSayisi += (int)rivalBuyucuHasari / 30;
                }
                else if (RivalFormasyonu.duzen == SavasDuzen.C)
                {
                    oldurulecekRivalAskerSayisi = (int)allySavasciHasari / 30;
                    oldurulecekRivalAskerSayisi += (int)allyOkcuHasari / 30;
                    oldurulecekRivalAskerSayisi += (int)allyBuyucuHasari / 30;

                    oldurulecekAllyAskerSayisi = (int)rivalSavasciHasari / 56;
                    oldurulecekAllyAskerSayisi += (int)rivalOkcuHasari / 56;
                    oldurulecekAllyAskerSayisi += (int)rivalBuyucuHasari / 56;
                }

            }
            if (AllyFormasyonu.duzen == SavasDuzen.C)
            {
                if (RivalFormasyonu.duzen == SavasDuzen.A)
                {
                    oldurulecekRivalAskerSayisi = (int)allySavasciHasari / 30;
                    oldurulecekRivalAskerSayisi += (int)allyOkcuHasari / 30;
                    oldurulecekRivalAskerSayisi += (int)allyBuyucuHasari / 30;

                    oldurulecekAllyAskerSayisi = (int)rivalSavasciHasari / 56;
                    oldurulecekAllyAskerSayisi += (int)rivalOkcuHasari / 56;
                    oldurulecekAllyAskerSayisi += (int)rivalBuyucuHasari / 56;

                }
                else if (RivalFormasyonu.duzen == SavasDuzen.B)
                {
                    oldurulecekRivalAskerSayisi = (int)allySavasciHasari / 56;
                    oldurulecekRivalAskerSayisi += (int)allyOkcuHasari / 56;
                    oldurulecekRivalAskerSayisi += (int)allyBuyucuHasari / 56;

                    oldurulecekAllyAskerSayisi = (int)rivalSavasciHasari / 30;
                    oldurulecekAllyAskerSayisi += (int)rivalOkcuHasari / 30;
                    oldurulecekAllyAskerSayisi += (int)rivalBuyucuHasari / 30;
                }
                else if (RivalFormasyonu.duzen == SavasDuzen.C)
                {
                    oldurulecekRivalAskerSayisi = (int)allySavasciHasari / 30;
                    oldurulecekRivalAskerSayisi += (int)allyOkcuHasari / 30;
                    oldurulecekRivalAskerSayisi += (int)allyBuyucuHasari / 30;

                    oldurulecekAllyAskerSayisi = (int)rivalSavasciHasari / 30;
                    oldurulecekAllyAskerSayisi += (int)rivalOkcuHasari / 30;
                    oldurulecekAllyAskerSayisi += (int)rivalBuyucuHasari / 30;
                }

            }

            if (RivalUnit.savasciSayisi < oldurulecekRivalAskerSayisi)
            {

                int savascifark = oldurulecekRivalAskerSayisi - RivalUnit.savasciSayisi;
                RivalUnit.AskerAzalt(RivalUnit.savasciSayisi);

                if (RivalUnit.OkcuSayisi < savascifark)
                {
                    int okcuFark = savascifark - RivalUnit.OkcuSayisi;
                    RivalUnit.AskerAzalt(azaltilacakOkcuSayisi: RivalUnit.OkcuSayisi);

                    RivalUnit.AskerAzalt(azaltilacakBuyucuSayisi: okcuFark);
                }
                else
                {
                    RivalUnit.AskerAzalt(azaltilacakOkcuSayisi: savascifark);
                }


            }
            else
            {
                RivalUnit.AskerAzalt(azaltilacakSavasciSayisi: oldurulecekRivalAskerSayisi);
            }


            if (AllyUnit.savasciSayisi < oldurulecekAllyAskerSayisi)
            {

                int savascifark = oldurulecekAllyAskerSayisi - AllyUnit.savasciSayisi;
                AllyUnit.AskerAzalt(AllyUnit.savasciSayisi);

                if (AllyUnit.OkcuSayisi < savascifark)
                {
                    int okcuFark = savascifark - AllyUnit.OkcuSayisi;
                    AllyUnit.AskerAzalt(azaltilacakOkcuSayisi: AllyUnit.OkcuSayisi);

                    AllyUnit.AskerAzalt(azaltilacakBuyucuSayisi: okcuFark);
                }
                else
                {
                    AllyUnit.AskerAzalt(azaltilacakOkcuSayisi: savascifark);
                }


            }
            else
            {
                AllyUnit.AskerAzalt(azaltilacakSavasciSayisi: oldurulecekAllyAskerSayisi);
            }


            string savasRaporu = SavasTuruRaporu(savasTuruOncesiAllyAskerleri, savasTuruOncesiRivalAskerleri);
            GameManager.Instance.StopGame();
            SavasRaporuAc(savasRaporu);
        }
        else if(SavasManager.Instance.isFinishWar == 1)
        {
            SavasMenuController.Instance.SavasRaporuSonPanel.GetComponent<Transform>().gameObject.SetActive(true);
            SavasMenuController.Instance.SavasTabMenu.GetComponent<Transform>().gameObject.SetActive(false);
           
            if (RivalUnit.birlikGucu > AllyUnit.birlikGucu)
            {
                AllyUnit.AskerAzalt(AllyUnit.savasciSayisi, AllyUnit.buyucuSayisi, AllyUnit.OkcuSayisi);
            }
            else if (AllyUnit.birlikGucu > RivalUnit.birlikGucu)
            {
                RivalUnit.AskerAzalt(RivalUnit.savasciSayisi, RivalUnit.buyucuSayisi, RivalUnit.OkcuSayisi);
            }
            SavasMenuController.Instance.SavasSonRapor();

            Destroy(DusmanObject.gameObject);
            RivalUnit = null;
            RivalFormasyonu = null;
            RivalFormasyonu = null;
            AllyFormasyonu = null;


            GameManager.Instance.StartGame();
            SavasManager.Instance.isFinishWar = 0;
        }



    }
    public void SavasiBitir()
    {

        SavasMenuController.Instance.SavasRaporuSonPanel.gameObject.SetActive(false);

    }
    private void SavasRaporuAc(string rapor)
    {
        GameManager.Instance.StopGame();

        
        UIManager.Instance.SavasFormasyonMenusu.SetActive(true);
        SavasMenuController.Instance.SavasRaporuGoruntule(rapor);
    }
    public string SavasTuruRaporu(int[] savasTuruOncesiAllyAskerleri, int[] savasTuruOncesiRivalAskerleri)
    {


        int oldurulmusAllySavasciSayisi = savasTuruOncesiAllyAskerleri[0];
        int oldurulmusAllyOkcuSayisi = savasTuruOncesiAllyAskerleri[1];
        int oldurulmusAllyBuyucuSayisi = savasTuruOncesiAllyAskerleri[2];
        




        int oldurulmusRivalSavasciSayisi = savasTuruOncesiRivalAskerleri[0];
        int oldurulmusRivalOkcuSayisi = savasTuruOncesiRivalAskerleri[1];
        int oldurulmusRivalBuyucuSayisi = savasTuruOncesiRivalAskerleri[2];

        int AllyToplam = oldurulmusAllySavasciSayisi + oldurulmusAllyOkcuSayisi + oldurulmusAllyBuyucuSayisi;
        int RivalToplam = oldurulmusRivalSavasciSayisi+ oldurulmusRivalOkcuSayisi+ oldurulmusRivalBuyucuSayisi;

        string sonuc = "";


        sonuc += "Bugunku Savasta dusman saflarindan " + oldurulmusRivalSavasciSayisi + " tane savasci Olurken, kendi saflarindan toplam da " + oldurulmusAllySavasciSayisi + " Oldu.\n\n";
        sonuc += "Bugunku Savasta dusman saflarindan " + oldurulmusRivalOkcuSayisi + " tane okcu Olurken, kendi saflarindan toplam da " + oldurulmusAllyOkcuSayisi + " Oldu.\n\n";
        sonuc += "Bugunku Savasta dusman saflarindan " + oldurulmusRivalBuyucuSayisi + " tane buyucu Olurken, kendi saflarindan toplam da " + oldurulmusAllyBuyucuSayisi + " Oldu.\n\n";

        sonuc += "Toplam da Dusman ordusu zaiyati " + RivalToplam + ". Senin ordunun zaiyati " + AllyToplam + ".";

        return sonuc;

    }


    public void SelectedAllyFormation(int formationIndex)
    {
        AllyFormasyonu = savasDuzeni[formationIndex];
    }

}
