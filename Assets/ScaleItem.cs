using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleItem : InteractableItem
{
    [HideInInspector]
    public bool selected = false;

    private bool ZoomIn;
    private bool ZoomOut;

    public float scale = 0.1f;

    override public void Update()
    {
        base.Update();

        if (selected)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 200f, LayerMask.GetMask("Surface")))
            {
                if (ZoomIn)
                {
                    //make a bigger object
                    transform.localScale += new Vector3(scale, scale, scale);
                }

                if (ZoomOut)
                {
                    //make a small object
                    transform.localScale -= new Vector3(scale, scale, scale);
                }
            }
        }
    }

    override public void OnButtonDownD()
    {
        selected = !selected;
        if (!selected) RemoveInteraction();
        else actionsUI[0].gameObject.SetActive(false);
        Camera.main.transform.GetChild(0).gameObject.SetActive(!selected);
        ZoomOut = false;
        ZoomIn = true;
    }

    override public void RemoveInteraction()
    {
        if (!selected) base.RemoveInteraction();
    }
}
