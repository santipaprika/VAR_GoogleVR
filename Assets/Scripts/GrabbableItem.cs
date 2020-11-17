using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableItem : InteractableItem
{
    private enum editModes { TRANSLATE, ROTATE, SCALE }
    private editModes currentMode = editModes.TRANSLATE;

    [HideInInspector]
    public bool selected = false;
    const int NUM_MODES = 3;
    public Transform[] onEditModeUI = new Transform[NUM_MODES];

    public float rotateSpeed = 70.0f;
    
    void OnValidate() {
        if (onEditModeUI.Length != NUM_MODES) {
            Debug.LogWarning("Don't change the 'ints' field's array size!");
            System.Array.Resize(ref onEditModeUI, NUM_MODES);
        }
    }

    override public void Update() {
        base.Update();

        if (selected) {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 200f, LayerMask.GetMask("Surface"))) {
                transform.position = hit.point + GetComponent<Collider>().bounds.extents.y * hit.normal;
                PlaceUIOnObject(onEditModeUI[(int)currentMode]);
            }
        }
    }

    // Grab | Drop object
    override public void OnButtonDownA() {
        selected = !selected;
        if (!selected) {
            onEditModeUI[(int)currentMode].gameObject.SetActive(false);
            currentMode = editModes.TRANSLATE;
            RemoveInteraction();
        } else {
            onHoverUI.gameObject.SetActive(false);
            onEditModeUI[(int)currentMode].gameObject.SetActive(true);
        }
        Camera.main.transform.GetChild(0).gameObject.SetActive(!selected);
    }

    // Change mode
    override public void OnButtonDownAt() {
        if (selected) {
            onEditModeUI[(int)currentMode].gameObject.SetActive(false);
            currentMode = (editModes)(((int)currentMode + 1) % 3);
            onEditModeUI[(int)currentMode].gameObject.SetActive(true);
        }
    }

    override public void OnButtonC() {
        if (selected)
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }

    override public void OnButtonB() {
        if (selected)
            transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
    }

    override public void OnButtonD() {
        if (selected)
            transform.Rotate(Vector3.left, rotateSpeed * Time.deltaTime);
    }


    override public void RemoveInteraction() {
        if (!selected) base.RemoveInteraction();
    }

    //override public void ShowInteractionUI() {
    //    Transform hoverUIParent = GameObject.Find("UI").transform.FindChild("OnHoverGrabbable");
    //    //Renderer[] hoverUIRenderers = GameObject.Find("OnHoverGrabbable").GetComponentsInChildren<Renderer>(true);
    //    ShowUI(hoverUIParent);
    //}
}
