using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TeleportController : MonoBehaviour
{

    public GameObject player;

    void Update()
    {

        bool buttonDownB;
        buttonDownB = false;

#if UNITY_EDITOR 
        buttonDownB = Input.GetKeyDown("b");
#else
        buttonDownB = Input.GetButtonDown("B");
#endif


    }
  
    public void PointerClick()
    {
        player.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
    }

}
