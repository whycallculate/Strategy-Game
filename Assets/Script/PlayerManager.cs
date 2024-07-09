using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region skeleton
    private static PlayerManager instance;
    public static PlayerManager Instance
    {
        get
        {
            if (instance == null)
                FindObjectOfType<PlayerManager>();
            return instance;
        }
        
        
    }
    #endregion

    int[] savasci;
    int[] okcu;
    int[] buyucu;
    




    



}
