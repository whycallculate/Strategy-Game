using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public static SaveManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SaveManager>();
            }
            return instance;
        }

    }
    #region SaveToJson
    public void SaveToJson()
    {
        YerlesimYeriSave();
        MoneySave();
        DaySave();
        //PlayerUnitSave();
        Debug.Log("Save Alindi");
    }


    private void YerlesimYeriSave()
    {
        string yerlesimYerleriData = JsonHelper.ToJson(GameManager.Instance.TumYerlesimAlanlari);
        PlayerPrefs.SetString("yerlesimYerleriData", yerlesimYerleriData);
    }

    private void MoneySave()
    {
        string playerMoneyData = JsonUtility.ToJson(GameManager.Instance.moneyCount);
        string filePath = Application.persistentDataPath + "/MoneyData.json";
        System.IO.File.WriteAllText(filePath, playerMoneyData);
        Debug.Log(filePath);
    }

    private void DaySave()
    {
        string TimeDay = JsonUtility.ToJson(TimeManager.Instance.dayCounter);
        string filePath = Application.persistentDataPath + "/DayData.json";
        System.IO.File.WriteAllText(filePath, TimeDay);
    }

    private void PlayerUnitSave()
    {
        string PlayerUnit = JsonUtility.ToJson(SavasManager.Instance.AllyUnitSave);
        string filePath = Application.persistentDataPath + "/PlayerUnit.json";
        System.IO.File.WriteAllText(filePath, PlayerUnit);

    }
    #endregion
    public void LoadFromJson()
    {
        YerlesimYeriLoad();
        MoneyLoad();
        DayLoad();
        //PlayerUnitLoad();
        Debug.Log("Load Atildi");
    }

    private void YerlesimYeriLoad()
    {
        string newJson = PlayerPrefs.GetString("yerlesimYerleriData");
        GameManager.Instance.TumYerlesimAlanlari = JsonHelper.FromJson<YerlesimYeriController>(newJson);

    }
    private void MoneyLoad()
    {
        string filePath = Application.persistentDataPath + "/MoneyData.json";
        string moneyData = System.IO.File.ReadAllText(filePath);

        GameManager.Instance.moneyCount = JsonUtility.FromJson<int>(moneyData);
    }
    private void DayLoad()
    {
        string filePath = Application.persistentDataPath + "/DayData.json";
        string dayData = System.IO.File.ReadAllText(filePath);

        TimeManager.Instance.dayCounter = JsonUtility.FromJson<int>(dayData);
    }
    private void PlayerUnitLoad()
    {
        string filePath = Application.persistentDataPath + "/PlayerUnit.json";
        string playerUnitData = System.IO.File.ReadAllText(filePath);

        SavasManager.Instance.AllyUnitSave = JsonUtility.FromJson<BirlikManager>(playerUnitData);
    }
}
