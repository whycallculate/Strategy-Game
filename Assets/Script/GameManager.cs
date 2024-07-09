using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    



    public static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }

    }

    public int moneyCount;
    public bool isPlaying = false;

    public bool isUpgradeDemirci;
    public bool isUpgradeAskeriKisla;
    public bool isUpgradeKonut;
    public bool isUpgradePazarYeri;
    public bool isUpgradeFirin;
    public bool isUpgradeUretimYeri;
    

    public YerlesimYeriController[] TumYerlesimAlanlari;
    public BirlikManager kontrolEdilenBirlik;




    private void Update()
    {

       
    }


    [HideInInspector]public YerlesimYeriController sonTiklananYerlesimAlani;

    public void StartGame()
    {
        isPlaying = true;
        BirimMovement.Instance.animator.enabled = true;
        BirimMovement.Instance.Unit.speed = 10f;
        sonTiklananYerlesimAlani.SelectObject.SetActive(false);
    }
    public void StartGameWar()
    {
        isPlaying = true;
        BirimMovement.Instance.animator.enabled = false;
        BirimMovement.Instance.Unit.speed = 0f;
    }
    public void StopGame()
    {
        isPlaying=false;
        BirimMovement.Instance.animator.enabled = false;
        BirimMovement.Instance.Unit.speed = 0f;
    }

    public void IsUpgradeAvaible(int i, bool isPressed)
    {
        bool[]upgradeArray ={isUpgradeDemirci,isUpgradeAskeriKisla,isUpgradeKonut,isUpgradePazarYeri,isUpgradeFirin,isUpgradeUretimYeri};
        
        if(i == 0 && isPressed)
        {
            
            upgradeArray[0] = isPressed;
            isUpgradeDemirci = upgradeArray[0];
            sonTiklananYerlesimAlani.YeniAlan.BinaLevelUp();
            
        }
        else if( i== 0 && !isPressed) 
        {
            
            upgradeArray[0] = isPressed;
            isUpgradeDemirci = upgradeArray[0];
        }

        if(i == 1 && isPressed)
        {
            upgradeArray[1] = isPressed;
            isUpgradeAskeriKisla = upgradeArray[1];
            sonTiklananYerlesimAlani.YeniAlan.BinaLevelUp();
        }
        else
        {
            upgradeArray[1] = isPressed;
            isUpgradeAskeriKisla = upgradeArray[1];
        }

        if (i == 2 && isPressed)
        {
            upgradeArray[2] = isPressed;
            isUpgradeKonut = upgradeArray[2];
            sonTiklananYerlesimAlani.YeniAlan.BinaLevelUp();
        }
        else
        {
            upgradeArray[2] = isPressed;
            isUpgradeKonut = upgradeArray[2];
        }

        if (i == 3 && isPressed)
        {
            upgradeArray[3] = isPressed;
            isUpgradePazarYeri = upgradeArray[3];
            sonTiklananYerlesimAlani.YeniAlan.BinaLevelUp();
        }
        else
        {
            upgradeArray[3] = isPressed;
            isUpgradePazarYeri = upgradeArray[3];
        }

        if (i == 4 && isPressed) 
        {
            upgradeArray[4] = isPressed;
            isUpgradeFirin = upgradeArray[4];
            sonTiklananYerlesimAlani.YeniAlan.BinaLevelUp();
        }
        else
        {
            upgradeArray[4] = isPressed;
            isUpgradeFirin = upgradeArray[4];
        }

        if (i == 5 && isPressed)
        {
            upgradeArray[5] = isPressed;
            isUpgradeUretimYeri = upgradeArray[5];
            sonTiklananYerlesimAlani.YeniAlan.BinaLevelUp();
        }
        else
        {
            upgradeArray[5] = isPressed;
            isUpgradeUretimYeri = upgradeArray[5];
        }





    }

    public void UrunleriArttir()
    {
        sonTiklananYerlesimAlani.YeniAlan.UrunleriArttir();
    }
    
    public void GunSonuMaddeleriSimuleEt()
    {
        for(int i = 0;i < TumYerlesimAlanlari.Length; i++)
        {
            TumYerlesimAlanlari[i].YeniAlan.UrunleriArttir();
            
        }



    }

    public void GunSonuAskerRezeverlerinizUpdateEt()
    {
        for(int i = 0;i < TumYerlesimAlanlari.Length; i++)
        {
            if(TumYerlesimAlanlari[i].YeniAlan is Kale)
            {
                Kale mevcutKale = (Kale)TumYerlesimAlanlari[i].YeniAlan;
                mevcutKale.UpdateRezerv();
            }
        }
    }


}
