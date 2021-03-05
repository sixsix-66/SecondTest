using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderFollow : MonoBehaviour
{
    
    void Start()
    {

    }

    void Update()
    {
        
        transform.rotation = Camera.main.transform.rotation;
    }

}
