using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;
    public static TimeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<TimeManager>();
            }
            return instance;
        }

    }
    public Gradient AmbientColor;
    public Gradient DirectionalColor;
    public Gradient FogColor;

    public Light DirectionLight;
    [Range(0, 24)] public float DayTime;

    public int dayCounter = 0;
    public float daySpeed = 1f;
    

    private void Update()
    {
        
        if (GameManager.instance.isPlaying)
        {
            DayTime += Time.deltaTime * daySpeed;
            if (DayTime >= 24f)
            {
                dayCounter++;
                GameManager.Instance.GunSonuMaddeleriSimuleEt();
                GameManager.Instance.GunSonuAskerRezeverlerinizUpdateEt();
                UIManager.Instance.TimeDayCounter();
                SaveManager.Instance.SaveToJson();
            }



            DayTime %= 24;
            UpdateLights(DayTime / 24);
        }

        
        

    }

    public void SavasBaslat(int savasGunSayisi)
    {
        StartCoroutine(SavasSayaci(savasGunSayisi));
    }

    IEnumerator SavasSayaci(int savasGunSayisi)
    {
        
        float HedefSavasSuresi = savasGunSayisi * 24;
        float mevcutSavasSuresi = 0f;

        List<int> durdurulacakSaatler = new List<int>();
        for(int i = 1; i <= savasGunSayisi; i++)
        {
            durdurulacakSaatler.Add(i*24);
        }

        while (mevcutSavasSuresi < HedefSavasSuresi)
        {
            if(GameManager.instance.isPlaying)
            {
                mevcutSavasSuresi += Time.deltaTime * daySpeed;
                yield return null;
                
                foreach (var durdurulacakSaat in durdurulacakSaatler)
                {
                    if (mevcutSavasSuresi >= durdurulacakSaat)
                    {
                        Debug.Log(durdurulacakSaat);
                        Debug.Log(durdurulacakSaatler.Count);
                        if (durdurulacakSaatler.Count <= 1)
                        {
                            SavasManager.Instance.isFinishWar = 1;
                            
                            break;

                        }
                        else if(durdurulacakSaatler.Count >= 2)
                        {
                            
                            SavasManager.Instance.SavasTuruSimule();
                            durdurulacakSaatler.Remove(durdurulacakSaat);
                            break;
                        }

                        

                    }

                }



            }
            else
            {
                yield return new WaitForSeconds(Time.deltaTime);
            }
        }
        

        

    }

    


    void UpdateLights(float timePercent)
    {
        RenderSettings.ambientLight = AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = FogColor.Evaluate(timePercent);

        DirectionLight.color = DirectionalColor.Evaluate(timePercent);
        DirectionLight.transform.localRotation = Quaternion.Euler((timePercent * 360) - 90f, 170, 0);
    }

}
