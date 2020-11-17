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
        if (!interactable) return;

        bool buttonDownA, buttonDownB, buttonDownC, buttonDownD, buttonDownAt;
        buttonDownA = buttonDownB = buttonDownC = buttonDownD = buttonDownAt = false;

        bool buttonA, buttonB, buttonC, buttonD;
        buttonA = buttonB = buttonC = buttonD = false;

#if UNITY_EDITOR 
        buttonDownA = Input.GetKeyDown("a");
        buttonDownB = Input.GetKeyDown("b");
        buttonDownC = Input.GetKeyDown("c");
        buttonDownD = Input.GetKeyDown("d");
        buttonDownAt = Input.GetKeyDown("q");

        buttonA = Input.GetKey("a");
        buttonB = Input.GetKey("b");
        buttonC = Input.GetKey("c");
        buttonD = Input.GetKey("d");
#else
        buttonDownA = Input.GetButtonDown("A");
        buttonDownB = Input.GetButtonDown("B");
        buttonDownC = Input.GetButtonDown("C");
        buttonDownD = Input.GetButtonDown("D");
        buttonDownAt = Input.GetButtonDown(11);

        buttonDownA = Input.GetButton("A");
        buttonDownB = Input.GetButton("B");
        buttonDownC = Input.GetButton("C");
        buttonDownD = Input.GetButton("D");
#endif

        if (buttonDownA) { OnButtonDownA(); }
        if (buttonDownB) { OnButtonDownB(); }
        if (buttonDownC) { OnButtonDownC(); }
        if (buttonDownD) { OnButtonDownD(); }
        if (buttonDownAt) { OnButtonDownAt(); }

        if (buttonA) { OnButtonA(); }
        if (buttonB) { OnButtonB(); }
        if (buttonC) { OnButtonC(); }
        if (buttonD) { OnButtonD(); }

    }

    virtual public void OnButtonDownA() { }
    virtual public void OnButtonDownB() { }
    virtual public void OnButtonDownC() { }
    virtual public void OnButtonDownD() { }
    virtual public void OnButtonDownAt() { }

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
        UITransform.SetPositionAndRotation(transform.position + new Vector3(0, 3 * collider.bounds.extents.y, 0), Quaternion.LookRotation((Camera.main.transform.position - transform.position).normalized));
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
