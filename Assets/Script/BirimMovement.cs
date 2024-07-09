using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class BirimMovement : MonoBehaviour
{

    public static BirimMovement instance;
    public static BirimMovement Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<BirimMovement>();
            }
            return instance;
        }
    }

    private EventSystem _eventSystem;
    Camera Cam;
    public NavMeshAgent Unit;
    public LayerMask ground;
    public Animator animator;
    bool isWalkingU;
    public bool nearYerlesimYeri;
    public string yerlesimYeriIsmi;


    private void Awake()
    {
        Cam = Camera.main;
        Unit = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        _eventSystem = GetComponent<EventSystem>();
    }



    private void Update()
    {
        UnitMovementRaycast();
        isUnitWalking();
    }


    public void UnitMovementRaycast()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            RaycastHit hit;
            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
                {
                    
                    Unit.SetDestination(hit.point);
                    

                }
            }
            

        }
        else
        {
            
        }
    }

    public void isUnitWalking()
    {
        
        if(Unit.remainingDistance >= -1 && Unit.remainingDistance <= 5)
        {
            isWalkingU = false;
        }
        else 
        {
            isWalkingU = true;
        }

        animator.SetBool("isWalking", isWalkingU);
        
        
    }

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Sehir") || other.CompareTag("Kale") || other.CompareTag("Koy") || other.CompareTag("UretimAlani"))
        {
            yerlesimYeriIsmi = other.name;
            nearYerlesimYeri = true;
            GameManager.Instance.StopGame();
        }

        if (other.CompareTag("Enemy"))
        {
            SavasManager.Instance.isFinishWar = 0;
            Debug.Log(other.name);
            GameManager.Instance.StopGame();
            SavasManager.Instance.RivalUnit = other.transform.GetComponent<BirlikManager>();
            SavasManager.Instance.AllyUnit = GetComponent<BirlikManager>();
            SavasManager.Instance.DusmanObject = other.GetComponent<Transform>();
            SavasMenuController.Instance.InitializeEnemyInfoPanel();
            UIManager.Instance.SavasFormasyonMenusu.SetActive(true);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Sehir") || other.CompareTag("Kale") || other.CompareTag("Koy") || other.CompareTag("UretimAlani"))
        {

            nearYerlesimYeri = false;
        }


    }


}
