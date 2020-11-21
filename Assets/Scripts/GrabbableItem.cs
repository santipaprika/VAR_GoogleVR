using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableItem : InteractableItem
{
    private enum editModes { TRANSLATE, ROTATE, SCALE, OBSERVE }
    private editModes currentMode = editModes.TRANSLATE;

    [HideInInspector]
    public bool selected = false;
    const int NUM_MODES = 4;
    public Transform[] onEditModeUI = new Transform[NUM_MODES];

    public float rotateSpeed = 90f;
    public float scaleSpeed = 0.5f;
    public float bringSpeed = 1f;

    void OnValidate() {
        if (onEditModeUI.Length != NUM_MODES) {
            Debug.LogWarning("Don't change the 'ints' field's array size!");
            System.Array.Resize(ref onEditModeUI, NUM_MODES);
        }
    }

    override public void Update() {
        base.Update();

        if (selected) {
            PlaceUIOnObject(onEditModeUI[(int)currentMode]);
            if (currentMode == editModes.TRANSLATE) { 
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 200f, LayerMask.GetMask("Surface")))
                    transform.position = hit.point + GetComponent<Collider>().bounds.extents.y * hit.normal;
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
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        } else {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            onHoverUI.gameObject.SetActive(false);
            onEditModeUI[(int)currentMode].gameObject.SetActive(true);
        }
        Camera.main.transform.GetChild(0).gameObject.SetActive(!selected);
    }

    // used in obervation mode
    private Vector3 initialPosition;
    // Change mode
    override public void OnButtonDownBack1() {
        if (selected) {
            initialPosition = transform.position;
            onEditModeUI[(int)currentMode].gameObject.SetActive(false);
            currentMode = (editModes)(((int)currentMode + 1) % NUM_MODES);
            onEditModeUI[(int)currentMode].gameObject.SetActive(true);
        }
    }

    override public void OnButtonC() {
        switch (currentMode) {
            case editModes.ROTATE:
                transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
                break;
            case editModes.SCALE:
                transform.localScale = Vector3.Min(transform.localScale + new Vector3(scaleSpeed, scaleSpeed, scaleSpeed) * Time.deltaTime,
                                                    new Vector3(10f, 10f, 10f)); 
                break;
            case editModes.OBSERVE:
                float maxDistance = (Camera.main.transform.position - initialPosition).magnitude;
                Vector3 shiftToAdd = bringSpeed * Time.deltaTime * (Camera.main.transform.position - initialPosition).normalized;
                transform.position += shiftToAdd;
                float curDistance = (Camera.main.transform.position - transform.position).magnitude;
                transform.position = (curDistance > 0.3) ? transform.position : transform.position - shiftToAdd;
                break;
            default:
                break;
        }
        
    }

    override public void OnButtonB() {
        if (currentMode == editModes.ROTATE)
            transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
    }

    override public void OnButtonD() {
        switch (currentMode) {
            case editModes.ROTATE:
                transform.Rotate(Vector3.left, rotateSpeed * Time.deltaTime);
                break;
            case editModes.SCALE:
                transform.localScale = Vector3.Max(transform.localScale - new Vector3(scaleSpeed, scaleSpeed, scaleSpeed) * Time.deltaTime, 
                                                    new Vector3(0.01f, 0.01f, 0.01f));
                break;
            case editModes.OBSERVE:
                float maxDistance = (Camera.main.transform.position - initialPosition).magnitude;
                transform.position -= bringSpeed * Time.deltaTime * (Camera.main.transform.position - initialPosition).normalized;
                float curDistance = (Camera.main.transform.position - transform.position).magnitude;
                transform.position = (maxDistance > curDistance) ? transform.position : initialPosition;
                break;
            default:
                break;
        }
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
