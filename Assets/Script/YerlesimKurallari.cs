using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Yerlesim Yerleri Kurallari",menuName = "Yerlesim Yeri Kurallari",order = 1)]
public class YerlesimKurallari : ScriptableObject 
{
    private static YerlesimKurallari instance;
    public static YerlesimKurallari Instance
    {
        get
        {
            if (instance == null)
            {
                instance =Resources.Load<YerlesimKurallari>("Yerlesim Yerleri Kurallari");
            }
            return instance;
        }
    }

    public Color EvilColor;
    public Color HeroColor;



}
