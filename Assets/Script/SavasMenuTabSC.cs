using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavasMenuTabSC : MonoBehaviour
{


    private void Update()
    {
        if (gameObject.activeSelf)
        {
            GameManager.Instance.StopGame();
        }
        else if(!gameObject.activeSelf)
        {
            GameManager.Instance.StartGameWar();
        }
    }
    private void OnEnable()
    {
        
    }
}
