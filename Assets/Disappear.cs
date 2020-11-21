using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : InteractableItem
{
    public Transform taskPearUI;
    override public void OnButtonDownA()
    {
        Destroy(gameObject);
        taskPearUI.gameObject.SetActive(true);
    }
}
