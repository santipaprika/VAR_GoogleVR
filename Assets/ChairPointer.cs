﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairPointer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PointerEnter()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }

    public void PointerExit()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

    public void PointerClick()
    {
        
    }
}
