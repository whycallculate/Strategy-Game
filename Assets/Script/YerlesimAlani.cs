using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum YerlesimYeriTipi
{
    EVIL, HERO
}
public  abstract class YerlesimAlani
{
    #region[field]

    public string name;
    public Sprite photo;

    public int para;
    public int hamMaddeUrunleri;
    public int savasEkipmanlari;
    public int IsEkipmanlari;
    public int konut;
    public int yapiMalzemeleri;
    public int gidaUrunleri;


    public int maxHamMaddeUrunleri = 200;
    public int maxSavasEkipmanlari = 200;
    public int maxIsEkipmanlari = 200;
    public int maxkonut = 200;
    public int maxyapiMalzemeleri = 200;
    public int maxGidaUrunleri = 200;
    #endregion


    #region[Method]
    public  abstract object[] GetFieldData();
    public abstract void UrunleriArttir();

    public abstract void maxCount();
    public abstract void BinaLevelUp();

    #endregion

}
public class Sehir : YerlesimAlani
{
    public int currentDemirciLevel;
    public int currentPazarYeriLevel;
    public int currentKonutLevel;

    public int maxDemircilevel = 2;
    public int maxPazarLevel = 2;
    public int maxKonutLevel = 2;

    public override object[] GetFieldData()
    {
        object[] ret = 
        {hamMaddeUrunleri, savasEkipmanlari,IsEkipmanlari,konut,yapiMalzemeleri,gidaUrunleri,photo,name
        ,maxHamMaddeUrunleri,maxSavasEkipmanlari,maxIsEkipmanlari,maxkonut,maxyapiMalzemeleri,
        currentDemirciLevel,currentPazarYeriLevel,currentKonutLevel, maxDemircilevel,maxPazarLevel,maxKonutLevel};
        return ret;
    }
    public override void UrunleriArttir()
    {
        if (currentDemirciLevel == 0)
        {

            IsEkipmanlari += 5;
        }
        else if (currentDemirciLevel == 1)
        {

            IsEkipmanlari += 10;
        }
        else if (currentDemirciLevel == 2)
        {

            IsEkipmanlari += 20;
        }

        if (currentPazarYeriLevel == 0)
        {

            yapiMalzemeleri += 5;
        }
        else if (currentPazarYeriLevel == 1)
        {

            yapiMalzemeleri += 10;
        }
        else if (currentPazarYeriLevel == 2)
        {

            yapiMalzemeleri += 20;
        }
        hamMaddeUrunleri += 3;
        savasEkipmanlari += 1;
        gidaUrunleri += 1;

    }

    public override void maxCount()
    {
        if (hamMaddeUrunleri >= maxHamMaddeUrunleri)
        {
            hamMaddeUrunleri = maxHamMaddeUrunleri;
        }
        if(savasEkipmanlari >= maxSavasEkipmanlari)
        {
            savasEkipmanlari = maxSavasEkipmanlari;
        }
        if(IsEkipmanlari >= maxIsEkipmanlari)
        {
            IsEkipmanlari = maxIsEkipmanlari;
        }
        if(yapiMalzemeleri >= maxyapiMalzemeleri)
        {
            yapiMalzemeleri = maxyapiMalzemeleri;
        }
        if (gidaUrunleri >= maxGidaUrunleri)
        {
            gidaUrunleri = maxGidaUrunleri;
        }
    }

    public override void BinaLevelUp()
    {

        if (GameManager.Instance.isUpgradeDemirci)
        {
            currentDemirciLevel++;
        }
        if (GameManager.Instance.isUpgradePazarYeri)
        {
            currentPazarYeriLevel++;
        }
        if (GameManager.Instance.isUpgradeKonut)
        {
            currentKonutLevel++;
        }

        if(currentDemirciLevel >= maxDemircilevel)
        {
            currentDemirciLevel = maxDemircilevel;
        }
        if (currentPazarYeriLevel >= maxPazarLevel)
        {
            currentPazarYeriLevel = maxPazarLevel;
        }
        if (currentKonutLevel >= maxKonutLevel)
        {
            currentKonutLevel = maxKonutLevel;
        }



    }
}
public class Koy : YerlesimAlani
{
    public int currentKonutLevel;
    public int currentFirinLevel;

    public int maxKonutLevel = 2;
    public int maxFirinLevel = 2;
    public override object[] GetFieldData()
    {
        object[] ret = 
        {hamMaddeUrunleri, savasEkipmanlari,IsEkipmanlari,konut,yapiMalzemeleri,gidaUrunleri,photo,name,
        maxHamMaddeUrunleri,maxSavasEkipmanlari,maxIsEkipmanlari,maxkonut,maxyapiMalzemeleri,
        currentKonutLevel,currentFirinLevel,maxKonutLevel,maxFirinLevel};

        return ret;
    }
    public override void UrunleriArttir()
    {
        if (currentFirinLevel == 0)
        {

            hamMaddeUrunleri += 5;
        }
        else if (currentFirinLevel == 1)
        {

            hamMaddeUrunleri += 10;
        }
        else if (currentFirinLevel == 2)
        {

            hamMaddeUrunleri += 20;
        }

        
        savasEkipmanlari += 4;
        IsEkipmanlari += 2;
        yapiMalzemeleri += 1;
        gidaUrunleri += 1;
    }
    public override void maxCount()
    {
        if (hamMaddeUrunleri >= maxHamMaddeUrunleri)
        {
            hamMaddeUrunleri = maxHamMaddeUrunleri;
        }
        if (savasEkipmanlari >= maxSavasEkipmanlari)
        {
            savasEkipmanlari = maxSavasEkipmanlari;
        }
        if (IsEkipmanlari >= maxIsEkipmanlari)
        {
            IsEkipmanlari = maxIsEkipmanlari;
        }
        if (yapiMalzemeleri >= maxyapiMalzemeleri)
        {
            yapiMalzemeleri = maxyapiMalzemeleri;
        }
        if (gidaUrunleri >= maxGidaUrunleri)
        {
            gidaUrunleri = maxGidaUrunleri;
        }
    }
    public override void BinaLevelUp()
    {

        if (GameManager.Instance.isUpgradeFirin)
        {
            currentFirinLevel++;
        }
        if (GameManager.Instance.isUpgradePazarYeri)
        {
            currentKonutLevel++;
        }

        if (currentFirinLevel >= maxFirinLevel)
        {
            currentFirinLevel = maxFirinLevel;
        }
        if (currentKonutLevel >= maxKonutLevel)
        {
            currentKonutLevel = maxKonutLevel;
        }

    }
}



public class Kale : YerlesimAlani
{
    public int currentKonutLevel;
    public int currentYagmaLevel;
    public int currentAskeriKislaLevel;

    public int maxKonutLevel = 2;
    public int maxAskeriKislaLevel = 2;
    public int maxYagmaLevel;

    public double mevcutSavasciRezervleri;
    public double mevcutOkcuRezervleri;
    public double mevcutBuyucuRezervleri;

    public double maxSavasciRezervleri;
    public double maxOkcuRezervleri;
    public double maxBuyucuRezervleri;
    public override object[] GetFieldData()
    {
        object[] ret =
        {hamMaddeUrunleri, savasEkipmanlari,IsEkipmanlari,konut,yapiMalzemeleri,gidaUrunleri,photo,name,
        maxHamMaddeUrunleri,maxSavasEkipmanlari,maxIsEkipmanlari,maxkonut,maxyapiMalzemeleri,
        currentKonutLevel,currentYagmaLevel,currentAskeriKislaLevel,maxYagmaLevel,maxKonutLevel,maxAskeriKislaLevel};

        return ret;
    }
    public override void UrunleriArttir()
    {
        if (currentAskeriKislaLevel == 0)
        {

            savasEkipmanlari += 5;
        }
        else if (currentAskeriKislaLevel == 1)
        {

            savasEkipmanlari += 10;
        }
        else if (currentAskeriKislaLevel == 2)
        {

            savasEkipmanlari += 20;
        }
        hamMaddeUrunleri += 1;
        IsEkipmanlari += 1;
        yapiMalzemeleri += 1;
        gidaUrunleri += 1;
    }
    public override void maxCount()
    {
        if (hamMaddeUrunleri >= maxHamMaddeUrunleri)
        {
            hamMaddeUrunleri = maxHamMaddeUrunleri;
        }
        if (savasEkipmanlari >= maxSavasEkipmanlari)
        {
            savasEkipmanlari = maxSavasEkipmanlari;
        }
        if (IsEkipmanlari >= maxIsEkipmanlari)
        {
            IsEkipmanlari = maxIsEkipmanlari;
        }
        if (yapiMalzemeleri >= maxyapiMalzemeleri)
        {
            yapiMalzemeleri = maxyapiMalzemeleri;
        }
        if (gidaUrunleri >= maxGidaUrunleri)
        {
            gidaUrunleri = maxGidaUrunleri;
        }
    }
    public override void BinaLevelUp()
    {
        if (GameManager.Instance.isUpgradeKonut)
        {
            currentKonutLevel++;
        }
        if (GameManager.Instance.isUpgradeAskeriKisla)
        {
            currentAskeriKislaLevel++;
        }

        if (currentKonutLevel >= maxKonutLevel)
        {
            currentKonutLevel = maxKonutLevel;
        }
        if (currentAskeriKislaLevel >= maxAskeriKislaLevel)
        {
            currentAskeriKislaLevel = maxAskeriKislaLevel;
        }
    }
    private void CheckRezerve()
    {
        if(currentKonutLevel == 0)
        {
            maxSavasciRezervleri = 10;
            maxOkcuRezervleri = 5;
            maxBuyucuRezervleri = 2;
        }
        else if(currentKonutLevel == 1)
        {
            maxSavasciRezervleri = 20;
            maxOkcuRezervleri = 10;
            maxBuyucuRezervleri = 4;
        }
        else if(currentKonutLevel == 2)
        {
            maxSavasciRezervleri = 40;
            maxOkcuRezervleri = 20;
            maxBuyucuRezervleri = 8;
        }
    }
    public void UpdateRezerv()
    {
        CheckRezerve();

        if(mevcutSavasciRezervleri < maxSavasciRezervleri)
        {
            mevcutSavasciRezervleri += 1;
        }
        if(mevcutOkcuRezervleri < maxOkcuRezervleri)
        {
            mevcutOkcuRezervleri += 0.5;
        }
        if(mevcutBuyucuRezervleri< maxBuyucuRezervleri)
        {
            mevcutBuyucuRezervleri += 0.2;
        }
    }

}

public class UretimAlani : YerlesimAlani
{
    public int currentUretimSeviyesi;
    public int maxUretimSeviyesi = 2;
    public override object[] GetFieldData()
    {
        object[] ret =
        {hamMaddeUrunleri, savasEkipmanlari,IsEkipmanlari,konut,yapiMalzemeleri,gidaUrunleri,photo,name,
        maxHamMaddeUrunleri,maxSavasEkipmanlari,maxIsEkipmanlari,maxkonut,maxyapiMalzemeleri,
        currentUretimSeviyesi,maxUretimSeviyesi};

        return ret;
    }

    public override void UrunleriArttir()
    {
        if(currentUretimSeviyesi == 0)
        {
            
            gidaUrunleri += 5;
        }
        else if(currentUretimSeviyesi == 1)
        {

            gidaUrunleri += 10;
        }
        else if (currentUretimSeviyesi == 2)
        {

            gidaUrunleri += 20;
        }
        hamMaddeUrunleri += 1;
        savasEkipmanlari += 1;
        IsEkipmanlari += 1;
        yapiMalzemeleri += 1;
    }
    public override void maxCount()
    {
        if (hamMaddeUrunleri >= maxHamMaddeUrunleri)
        {
            hamMaddeUrunleri = maxHamMaddeUrunleri;
        }
        if (savasEkipmanlari >= maxSavasEkipmanlari)
        {
            savasEkipmanlari = maxSavasEkipmanlari;
        }
        if (IsEkipmanlari >= maxIsEkipmanlari)
        {
            IsEkipmanlari = maxIsEkipmanlari;
        }
        if (yapiMalzemeleri >= maxyapiMalzemeleri)
        {
            yapiMalzemeleri = maxyapiMalzemeleri;
        }
        if (gidaUrunleri >= maxGidaUrunleri)
        {
            gidaUrunleri = maxGidaUrunleri;
        }
    }
    public override void BinaLevelUp()
    {
        if (GameManager.Instance.isUpgradeUretimYeri)
        {
            currentUretimSeviyesi++;
        }
        if (currentUretimSeviyesi >= maxUretimSeviyesi)
        {
            currentUretimSeviyesi = maxUretimSeviyesi;
        }

    }
}

