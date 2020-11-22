using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : InteractableItem
{
    public Transform eatCompletitionUI;
    override public void OnButtonDownA()
    {
        onHoverUI.gameObject.SetActive(false);
        PlaceUIOnObject(eatCompletitionUI);
        GetComponent<Renderer>().enabled = false; 
        eatCompletitionUI.gameObject.SetActive(true);
        GameSession.currentSession.tasksDone[(int)tasks.EAT] = true;

        GameSession.currentSession.CheckProgress();
        interactable = false;
    }
}
