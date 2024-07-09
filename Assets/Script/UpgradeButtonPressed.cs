using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    bool isPressedDemirci;
    bool isPressedAskeriKisla;
    bool isPressedKonut;
    bool isPressedPazarYeri;
    bool isPressedUretimYeri;
    bool isPressedFirin;

    void FixedUpdate()
    {
        
    }
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (transform.CompareTag("Demirci"))
        {
            isPressedDemirci = true;
            GameManager.Instance.IsUpgradeAvaible(0, isPressedDemirci);
        }
        if (transform.CompareTag("AskeriKisla"))
        {
            isPressedAskeriKisla = true;
            GameManager.Instance.IsUpgradeAvaible(1, isPressedAskeriKisla);
        }
        if (transform.CompareTag("Konut"))
        {
            isPressedKonut = true;
            GameManager.Instance.IsUpgradeAvaible(2, isPressedKonut);
        }
        if (transform.CompareTag("PazarYeri"))
        {
            isPressedPazarYeri = true;
            GameManager.Instance.IsUpgradeAvaible(3, isPressedPazarYeri);
        }
        if (transform.CompareTag("Firin"))
        {
            isPressedFirin = true;
            GameManager.Instance.IsUpgradeAvaible(4, isPressedFirin);
        }
        if (transform.CompareTag("UretimYeri"))
        {
            isPressedUretimYeri = true;
            GameManager.Instance.IsUpgradeAvaible(5, isPressedUretimYeri);
        }
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        if (transform.CompareTag("Demirci"))
        {
            isPressedDemirci = false;
            GameManager.Instance.IsUpgradeAvaible(0, isPressedDemirci);
        }
        if (transform.CompareTag("AskeriKisla"))
        {
            isPressedAskeriKisla = false;
            GameManager.Instance.IsUpgradeAvaible(1, isPressedAskeriKisla);
        }
        if (transform.CompareTag("Konut"))
        {
            isPressedKonut = false;
            GameManager.Instance.IsUpgradeAvaible(2, isPressedKonut);
        }
        if (transform.CompareTag("PazarYeri"))
        {
            isPressedPazarYeri = false;
            GameManager.Instance.IsUpgradeAvaible(3, isPressedPazarYeri);
        }
        if (transform.CompareTag("Firin"))
        {
            isPressedFirin = false;
            GameManager.Instance.IsUpgradeAvaible(4, isPressedFirin);
        }
        if (transform.CompareTag("UretimYeri"))
        {
            isPressedUretimYeri = false;
            GameManager.Instance.IsUpgradeAvaible(5, isPressedUretimYeri);
        }
    }
}
