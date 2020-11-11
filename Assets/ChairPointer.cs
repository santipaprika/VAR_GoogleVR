using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairPointer : MonoBehaviour
{

    //movement speed in units per second
    private float movementSpeed = 5f;

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
        Destroy(gameObject);
        //get the Input from Horizontal axis
        ///float horizontalInput = Input.GetAxis("Horizontal");
        //get the Input from Vertical axis
        ///float verticalInput = Input.GetAxis("Vertical");
        ///transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, verticalInput * movementSpeed * Time.deltaTime, 0);
    }
}
