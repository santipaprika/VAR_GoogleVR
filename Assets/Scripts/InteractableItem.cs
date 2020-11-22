using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractableItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool interactable = false;
    public Transform onHoverUI;

    public virtual void Update()
    {
        //if (Input.GetButtonDown("A")) GameObject.Find("Chair").SetActive(false); // D -- modo C -> A
        //if (Input.GetButtonDown("B")) GameObject.Find("Desk").SetActive(false); // A -- en modo C -> D
        //if (Input.GetButtonDown("C")) GameObject.Find("Plant").SetActive(false); // B -- en modo C -> C
        //if (Input.GetButtonDown("D")) GameObject.Find("Lamp").SetActive(false); // b1
        //if (Input.GetButtonDown("E")) GameObject.Find("PuzzleTorus").SetActive(false); // b2
        //if (Input.GetButtonDown("F")) GameObject.Find("PuzzleBase").SetActive(false);
        //if (Input.GetButtonDown("M")) GameObject.Find("PuzzleCube").SetActive(false); //  b -- modo C -> c
        //if (Input.GetButtonDown("N")) GameObject.Find("PuzzleSphere").SetActive(false); // D -- modo C -> b
        //if (Input.GetButtonDown("O")) GameObject.Find("PuzzleCylinder").SetActive(false); // c -- modo C -> b


        if (!interactable) return;

        bool buttonDownA, buttonDownB, buttonDownC, buttonDownD, buttonDownBack1, buttonDownBack2;
        buttonDownA = buttonDownB = buttonDownC = buttonDownD = buttonDownBack1 = buttonDownBack2 = false;

        bool buttonA, buttonB, buttonC, buttonD;
        buttonA = buttonB = buttonC = buttonD = false;

        buttonDownA = Input.GetButtonDown("A");
        buttonDownB = Input.GetButtonDown("B");
        buttonDownC = Input.GetButtonDown("C");
        buttonDownD = Input.GetButtonDown("D");
        buttonDownBack1 = Input.GetButtonDown("Back1");
        buttonDownBack2 = Input.GetButtonDown("Back2");

        buttonA = Input.GetButton("A");
        buttonB = Input.GetButton("B");
        buttonC = Input.GetButton("C");
        buttonD = Input.GetButton("D");

        if (buttonDownA) { OnButtonDownA(); }
        if (buttonDownB) { OnButtonDownB(); }
        if (buttonDownC) { OnButtonDownC(); }
        if (buttonDownD) { OnButtonDownD(); }
        if (buttonDownBack1) { OnButtonDownBack1(); }
        if (buttonDownBack2) { OnButtonDownBack2(); }

        if (buttonA) { OnButtonA(); }
        if (buttonB) { OnButtonB(); }
        if (buttonC) { OnButtonC(); }
        if (buttonD) { OnButtonD(); }

    }

    virtual public void OnButtonDownA() { }
    virtual public void OnButtonDownB() { }
    virtual public void OnButtonDownC() { }
    virtual public void OnButtonDownD() { }
    virtual public void OnButtonDownBack1() { }
    virtual public void OnButtonDownBack2() { }

    virtual public void OnButtonA() { }
    virtual public void OnButtonB() { }
    virtual public void OnButtonC() { }
    virtual public void OnButtonD() { }

    public void OnPointerEnter(PointerEventData pointerEventData) {
        interactable = true;
        ShowUI();
    }
    public void OnPointerExit(PointerEventData pointerEventData) {
        RemoveInteraction();
    }
    
    virtual public void ShowInteractionUI() { }

    public void ShowUI() {
        //Collider collider = GetComponent<Collider>();
        onHoverUI.gameObject.SetActive(true);
        PlaceUIOnObject(onHoverUI);
        //foreach (Transform UIElem in onHoverUI.GetComponentInChildren<Transform>()) {
        //    UIElem.gameObject.SetActive(true);
        //    UIElem.SetPositionAndRotation(transform.position + new Vector3(0, 3 * collider.bounds.extents.y, 0), Quaternion.LookRotation((Camera.main.transform.position - transform.position).normalized));
        //    UIElem.Rotate(Vector3.up, 180f);
        //}
    }

    public void PlaceUIOnObject(Transform UITransform) {
        Collider collider = GetComponent<Collider>();
        UITransform.SetPositionAndRotation(transform.position + new Vector3(0, collider.bounds.extents.y + 0.2f, 0), Quaternion.LookRotation((Camera.main.transform.position - transform.position).normalized));
        UITransform.Rotate(Vector3.up, 180f);
    }

    public virtual void RemoveInteraction() {
        Camera.main.transform.GetChild(0).gameObject.SetActive(true);
        interactable = false;
        onHoverUI.gameObject.SetActive(false);
        //foreach (Transform UIElem in onHoverUI.GetComponentInChildren<Transform>()) {
        //    UIElem.gameObject.SetActive(false);
        //}
    }

}
