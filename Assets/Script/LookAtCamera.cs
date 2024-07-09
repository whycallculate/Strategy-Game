using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LookAtCamera : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {



        transform.LookAt(Camera.main.transform);  
    }
}
