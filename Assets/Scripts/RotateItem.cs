using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : InteractableItem
{
    [HideInInspector]
    public bool selected = false;
    public float rotateSpeed = 40f;

    override public void Update()
    {
        base.Update();

        if (selected)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 200f, LayerMask.GetMask("Surface")))
            {
                    //rotate object with speed
                    transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
            }
        }
    }


    override public void OnButtonDownC()
    {
        selected = !selected;
        if (!selected) RemoveInteraction();
        //else actionsUI[0].gameObject.SetActive(false);
        Camera.main.transform.GetChild(0).gameObject.SetActive(!selected);
    }

    override public void RemoveInteraction()
    {
        if (!selected) base.RemoveInteraction();
    }
}
