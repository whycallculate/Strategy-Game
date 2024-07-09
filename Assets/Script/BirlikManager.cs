using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;

public class BirlikManager : MonoBehaviour
{
    public double birlikGucu;
    

    public int savasciSayisi;
    public int buyucuSayisi;
    public int OkcuSayisi;

    private void Awake()
    {
       
    }
    private void Update()
    {
        BirlikGucuHesapla();
    }

    public void AskerArtir(int eklenecekSavasciSayisi= 0, int eklenecekBuyucuSayisi = 0, int eklenecekOkcuSayisi = 0)
    {
        savasciSayisi += eklenecekSavasciSayisi;
        buyucuSayisi+= eklenecekBuyucuSayisi;
        OkcuSayisi+= eklenecekOkcuSayisi;

    }
    public void AskerAzalt(int azaltilacakSavasciSayisi = 0, int azaltilacakBuyucuSayisi = 0, int azaltilacakOkcuSayisi = 0)
    {
        if(savasciSayisi - azaltilacakSavasciSayisi < 0)
        {
            savasciSayisi = 0;
        }
        else
        {
            savasciSayisi -= azaltilacakSavasciSayisi;

        }
        if(buyucuSayisi - azaltilacakBuyucuSayisi < 0)
        {
            buyucuSayisi = 0;
        }
        else
        {
            buyucuSayisi -= azaltilacakBuyucuSayisi;

        }
        if(OkcuSayisi - azaltilacakOkcuSayisi < 0)
        {
            OkcuSayisi = 0;
        }
        else
        {

            OkcuSayisi -= azaltilacakOkcuSayisi;

        }
        
        

    }

    private void BirlikGucuHesapla()
    {
        birlikGucu = 0;

        birlikGucu += savasciSayisi * 3;
        birlikGucu += OkcuSayisi * 5;
        birlikGucu += buyucuSayisi * 10;

        transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = birlikGucu.ToString();
        
        
    }
}
