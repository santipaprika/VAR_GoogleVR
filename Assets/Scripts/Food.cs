using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : InteractableItem
{
    public Transform eatCompletitionUI;
    override public void OnButtonDownA()
    {
        GameObject.FindObjectOfType<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("Audios/eat"));
        onHoverUI.gameObject.SetActive(false);
        PlaceUIOnObject(eatCompletitionUI);
        GetComponent<Renderer>().enabled = false; 
        eatCompletitionUI.gameObject.SetActive(true);
        GameSession.currentSession.tasksDone[(int)tasks.EAT] = true;
        
        GameSession.currentSession.CheckProgress();

        gameObject.SetActive(false);
    }
}
