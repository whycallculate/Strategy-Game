using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SavasMenuController : MonoBehaviour
{
    #region SKELETON
    public static SavasMenuController instance;
    public static SavasMenuController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SavasMenuController>();
            }
            return instance;
        }
    }
    #endregion
    [SerializeField] private Transform FormationSelectionPanel;
    [SerializeField] private Transform enemyInfoPanel;
    [SerializeField] private Transform oyuncuInfoPanel;
    [SerializeField] public Transform SavasRaporuPanel;
    [SerializeField] public Transform SavasRaporuSonPanel;
    [SerializeField] public Transform SavasTabMenu;
    

    private void Awake()
    {
        for (int i = 0; i < FormationSelectionPanel.childCount; i++)
        {
            FormationSelectionPanel.GetChild(i).GetComponent<Button>().onClick.AddListener(SelectFormationButtonMethod);
            Debug.Log(EventSystem.current.currentSelectedGameObject);

        }
        
    }
    private void Update()
    {
        Debug.Log(SavasManager.Instance.isFinishWar);
    }

    private void SelectFormationButtonMethod()
    {
        int index = EventSystem.current.currentSelectedGameObject.transform.GetSiblingIndex();

        SavasManager.Instance.SelectedAllyFormation(index);
        InitializeOyuncuInfoPanel();
    }
    

    private void InitializeOyuncuInfoPanel()
    {
        
        oyuncuInfoPanel.GetChild(0).GetComponent<TextMeshProUGUI>().text = SavasManager.Instance.AllyFormasyonu.duzen.ToString() + " Formasyonunu Sectin.";

        oyuncuInfoPanel.GetChild(1).GetComponent<TextMeshProUGUI>().text = SavasManager.Instance.AllyUnit.savasciSayisi.ToString();
        oyuncuInfoPanel.GetChild(2).GetComponent<TextMeshProUGUI>().text = SavasManager.Instance.AllyUnit.OkcuSayisi.ToString();
        oyuncuInfoPanel.GetChild(3).GetComponent<TextMeshProUGUI>().text = SavasManager.Instance.AllyUnit.buyucuSayisi.ToString();


    }
    public void InitializeEnemyInfoPanel()
    {

        enemyInfoPanel.GetChild(0).GetComponent<TextMeshProUGUI>().text = SavasManager.Instance.RivalFormasyonu.duzen.ToString() + " Formasyonunu Secti.";

        enemyInfoPanel.GetChild(1).GetComponent<TextMeshProUGUI>().text = SavasManager.Instance.RivalUnit.savasciSayisi.ToString();
        enemyInfoPanel.GetChild(2).GetComponent<TextMeshProUGUI>().text = SavasManager.Instance.RivalUnit.OkcuSayisi.ToString();
        enemyInfoPanel.GetChild(3).GetComponent<TextMeshProUGUI>().text = SavasManager.Instance.RivalUnit.buyucuSayisi.ToString();

    }

    public void SavasBaslatButtonMethod()
    {
        Debug.Log("SavasBaslatButtonMethod");
        if (SavasManager.Instance.isFinishWar == 1)
        {
            //Debug.Log("SavasBaslatButtonMethod 1");
            
            //GameManager.Instance.StopGame();
            //SavasManager.Instance.SavasiBitir();
            
        }
        else if (SavasManager.Instance.isFinishWar == 0)

        {
            Debug.Log("SavasBaslatButtonMethod 0");
            SavasTabMenu.gameObject.SetActive(false);
            TimeManager.Instance.SavasBaslat(SavasManager.Instance.SavasSuresiHesapla());
            GameManager.Instance.StartGameWar();
            //TimeManager.Instance.SavasSayaciTwo(SavasManager.Instance.SavasSuresiHesapla());
        }
        

    }

    public void NextTurButtonu()
    {
            
            SavasRaporuPanel.gameObject.SetActive(false);
            GameManager.Instance.StartGameWar();
            SavasTabMenu.gameObject.SetActive(true);
        


    }


    public void SavasRaporuGoruntule(string rapor)
    {
        
        SavasRaporuPanel.gameObject.SetActive(true);
        
        SavasRaporuPanel.GetChild(0).GetComponent<TextMeshProUGUI>().text = rapor;


    }

    public void SavasSonRapor()
    {
        Debug.Log("SavasSonRapor ");

        if (SavasManager.Instance.AllyUnit.savasciSayisi == 0)
        {
            SavasRaporuSonPanel.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Sen Tum askerlerini Kaybettin.";
        }
        else if(SavasManager.Instance.RivalUnit.savasciSayisi == 0)
        {
            SavasRaporuSonPanel.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Karsi Taraf tum askerlerini Kaybetti. Sen Kazandin";
        }

    }
}
