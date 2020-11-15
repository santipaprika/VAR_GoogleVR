using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableItem : InteractableItem
{
    [HideInInspector]
    public bool selected = false;

    override public void Update() {
        base.Update();

        if (selected) {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 200f, LayerMask.GetMask("Surface"))) {
                transform.position = hit.point + GetComponent<Collider>().bounds.extents.y * hit.normal;
            }
        }
    }

    override public void OnButtonDownA() {
        selected = !selected;
        if (!selected) RemoveInteraction();
        else actionsUI[0].gameObject.SetActive(false);
        Camera.main.transform.GetChild(0).gameObject.SetActive(!selected);
    }

    override public void RemoveInteraction() {
        if (!selected) base.RemoveInteraction();
    }
}
