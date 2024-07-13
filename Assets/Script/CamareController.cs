using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CamareController : MonoBehaviour
{
    public float camSpeed = 28f;
    public GameObject cubeController;
    private EventSystem _eventSystem;
    public Transform UIDragAreas;
    //YerlesimYeriController yerlesimYeriController;

    //Mouse position yerine mouse click degisilicek.
    // Bir objeye ray atarken arkasina veya onune Ray isinlarinin gecmemesi gerekiyor.
    // Update is called once per frame
    private void Awake()
    {
        _eventSystem = FindObjectOfType<EventSystem>();


    }
    void Update()
    {


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        if (Input.GetKey(KeyCode.Mouse0))
        {

            if (Physics.Raycast(ray.origin, ray.direction, out hit, 10000))
            {

                if (!EventSystem.current.IsPointerOverGameObject() && BirimMovement.Instance.nearYerlesimYeri
                    && BirimMovement.Instance.yerlesimYeriIsmi == hit.collider.gameObject.name)
                {

                    if (hit.collider.gameObject.CompareTag("Kale"))
                    {

                        YerlesimYeriController carpanNokta = hit.collider.GetComponent<YerlesimYeriController>();
                        carpanNokta.YeniAlan.maxCount();
                        object[] alinanVeriler = carpanNokta.GetBuildDataStatics();
                        carpanNokta.SelectObject.SetActive(true);
                        GameManager.Instance.sonTiklananYerlesimAlani = carpanNokta;
                        UIManager.Instance.InitializeYanMenu(alinanVeriler);
                        UIManager.Instance.InitializeTabMenuLevel(alinanVeriler);
                        UIManager.Instance.YanMenuAC(true);


                    }
                    else if (hit.collider.gameObject.CompareTag("Koy") && !hit.collider.gameObject.CompareTag("UI"))
                    {
                        
                        YerlesimYeriController carpanNokta = hit.collider.GetComponent<YerlesimYeriController>();
                        carpanNokta.YeniAlan.maxCount();
                        carpanNokta.SelectObject.SetActive(true);

                        object[] alinanVeriler = carpanNokta.GetBuildDataStatics();
                        GameManager.Instance.sonTiklananYerlesimAlani = carpanNokta;
                        UIManager.Instance.InitializeYanMenu(alinanVeriler);
                        UIManager.Instance.InitializeTabMenuLevel(alinanVeriler);
                        UIManager.Instance.YanMenuAC(true);


                    }
                    else if (hit.collider.gameObject.CompareTag("Sehir") && !hit.collider.gameObject.CompareTag("UI"))
                    {
                        YerlesimYeriController carpanNokta = hit.collider.GetComponent<YerlesimYeriController>();
                        carpanNokta.YeniAlan.maxCount();
                        carpanNokta.SelectObject.SetActive(true);
                        object[] alinanVeriler = carpanNokta.GetBuildDataStatics();
                        GameManager.Instance.sonTiklananYerlesimAlani = carpanNokta;
                        UIManager.Instance.InitializeYanMenu(alinanVeriler);
                        UIManager.Instance.InitializeTabMenuLevel(alinanVeriler);
                        UIManager.Instance.YanMenuAC(true);
                    }
                    else if (hit.collider.gameObject.CompareTag("UretimAlani") && !hit.collider.gameObject.CompareTag("UI"))
                    {
                        YerlesimYeriController carpanNokta = hit.collider.GetComponent<YerlesimYeriController>();
                        carpanNokta.YeniAlan.maxCount();
                        carpanNokta.SelectObject.SetActive(true);
                        object[] alinanVeriler = carpanNokta.GetBuildDataStatics();
                        GameManager.Instance.sonTiklananYerlesimAlani = carpanNokta;
                        UIManager.Instance.InitializeYanMenu(alinanVeriler);
                        UIManager.Instance.InitializeTabMenuLevel(alinanVeriler);
                        UIManager.Instance.YanMenuAC(true);

                    }
                    else
                    {
                        
                    }
                }



            }



        }
        else if (Physics.Raycast(ray.origin, ray.direction, out hit, 10000))
        {
            DragCamera();

        }
        //SelectObjectRing();
    }

    private void FixedUpdate()
    {

    }

    void DragCamera()
    {

        if (IsPointerOverUIElement())
        {
            GameObject hitted_element = HittedUIElement(GetEventSystemRaycastResults());
            if (hitted_element.transform.parent == UIDragAreas)
            {
                if (hitted_element.transform.GetSiblingIndex() == 0) // Top
                {
                    cubeController.transform.Translate(Vector3.forward * camSpeed * Time.fixedDeltaTime);
                }
                if (hitted_element.transform.GetSiblingIndex() == 1) // Bot
                {
                    cubeController.transform.Translate(Vector3.back * camSpeed * Time.fixedDeltaTime);
                }
                if (hitted_element.transform.GetSiblingIndex() == 2) // Left
                {
                    cubeController.transform.Translate(Vector3.left * camSpeed * Time.fixedDeltaTime);
                }
                if (hitted_element.transform.GetSiblingIndex() == 3) // Right
                {
                    cubeController.transform.Translate(Vector3.right * camSpeed * Time.fixedDeltaTime);
                }
                if (hitted_element.transform.GetSiblingIndex() == 4) // Top_Right
                {
                    cubeController.transform.Translate(Vector3.forward * (camSpeed - 3) * Time.fixedDeltaTime);
                    cubeController.transform.Translate(Vector3.right * (camSpeed - 3) * Time.fixedDeltaTime);
                }
                if (hitted_element.transform.GetSiblingIndex() == 5) // Top_Left
                {
                    cubeController.transform.Translate(Vector3.forward * (camSpeed - 3) * Time.fixedDeltaTime);
                    cubeController.transform.Translate(Vector3.left * (camSpeed - 3) * Time.fixedDeltaTime);
                }
                if (hitted_element.transform.GetSiblingIndex() == 6) // Bot_Left
                {
                    cubeController.transform.Translate(Vector3.back * (camSpeed - 3) * Time.fixedDeltaTime);
                    cubeController.transform.Translate(Vector3.left * (camSpeed - 3) * Time.fixedDeltaTime);
                }
                if (hitted_element.transform.GetSiblingIndex() == 7) // Bot_Right
                {
                    cubeController.transform.Translate(Vector3.back * (camSpeed - 3) * Time.fixedDeltaTime);
                    cubeController.transform.Translate(Vector3.right * (camSpeed - 3) * Time.fixedDeltaTime);
                }
            }


        }

    }


    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        return raysastResults;
    }
    private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[index];
            if (curRaysastResult.gameObject.layer == 5)
                return true;
        }
        return false;
    }

    GameObject HittedUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[index];
            if (curRaysastResult.gameObject.layer == 5)
                return curRaysastResult.gameObject;
        }

        return null;
    }
    public bool IsPointerOverUIElement()
    {
        return IsPointerOverUIElement(GetEventSystemRaycastResults());
    }


    public void SelectObjectRing()
    {
        //hit.transform.GetChild(0).gameObject.SetActive(true);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 10000))
            {
                if (hit.collider.CompareTag("Sehir") || hit.collider.CompareTag("Koy") || hit.collider.CompareTag("Kale") || hit.collider.CompareTag("UretimAlani"))
                {
                    YerlesimYeriController hitObject = hit.collider.GetComponent<YerlesimYeriController>();
                    if(hitObject.SelectObject == null )
                    {
                        Debug.Log("null == ");
                        hit.transform.GetChild(0).gameObject.SetActive(false);
                    }
                    
                    else if(hitObject.SelectObject != null ) 
                    {
                        if(hit.collider.CompareTag("Sehir") || hit.collider.CompareTag("Koy") || hit.collider.CompareTag("Kale") || hit.collider.CompareTag("UretimAlani"))
                        {

                            if(hitObject.yerlesimEnum == YerlesimAlaniEnum.SEHIR && hitObject.yerlesimEnum != YerlesimAlaniEnum.KOY && hitObject.yerlesimEnum != YerlesimAlaniEnum.KALE && hitObject.yerlesimEnum != YerlesimAlaniEnum.URETIMALANI)
                            {
                                hitObject.SelectObject.SetActive(false);
                                hit.transform.GetChild(0).gameObject.SetActive(true);
                            }
                            else if(hitObject.yerlesimEnum != YerlesimAlaniEnum.SEHIR && hitObject.yerlesimEnum == YerlesimAlaniEnum.KOY && hitObject.yerlesimEnum != YerlesimAlaniEnum.KALE && hitObject.yerlesimEnum != YerlesimAlaniEnum.URETIMALANI)
                            {
                                hitObject.SelectObject.SetActive(false);
                                hit.transform.GetChild(0).gameObject.SetActive(true);
                            }
                            else if(hitObject.yerlesimEnum != YerlesimAlaniEnum.SEHIR && hitObject.yerlesimEnum != YerlesimAlaniEnum.KOY && hitObject.yerlesimEnum == YerlesimAlaniEnum.KALE && hitObject.yerlesimEnum != YerlesimAlaniEnum.URETIMALANI)
                            {
                                hitObject.SelectObject.SetActive(false);
                                hit.transform.GetChild(0).gameObject.SetActive(true);
                            }
                            else if(hitObject.yerlesimEnum != YerlesimAlaniEnum.SEHIR && hitObject.yerlesimEnum != YerlesimAlaniEnum.KOY && hitObject.yerlesimEnum != YerlesimAlaniEnum.KALE && hitObject.yerlesimEnum == YerlesimAlaniEnum.URETIMALANI)
                            {
                                hitObject.SelectObject.SetActive(false);
                                hit.transform.GetChild(0).gameObject.SetActive(true);

                            }
                            else
                            {
                                hit.transform.GetChild(0).gameObject.SetActive(false) ;
                            }
                        }
                        
                        

                        
                    }

                }
            }

        }
        

    }


}