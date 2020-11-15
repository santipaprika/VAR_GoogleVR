using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractableItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool interactable = false;
    public List<Transform> actionsUI;

    public virtual void Update()
    {
        if (!interactable) return;

        bool buttonDownA, buttonDownB;
        buttonDownA = buttonDownB = false;

#if UNITY_EDITOR 
        buttonDownA = Input.GetKeyDown("a");
        buttonDownB = Input.GetKeyDown("b");
#else
        buttonDownA = Input.GetButtonDown("A");
        buttonDownB = Input.GetButtonDown("B");
#endif

        if (buttonDownA) { OnButtonDownA(); }
        if (buttonDownB) { OnButtonDownB(); }
        
    }

    virtual public void OnButtonDownA() { }
    virtual public void OnButtonDownB() { }

    public void OnPointerEnter(PointerEventData pointerEventData) {
        AllowInteraction();
    }
    public void OnPointerExit(PointerEventData pointerEventData) {
        RemoveInteraction();
    }
    
    public void AllowInteraction() {
        interactable = true;
        Collider collider = GetComponent<Collider>();
        foreach (Transform UI_elem in actionsUI) {
            UI_elem.gameObject.SetActive(true);
            UI_elem.SetPositionAndRotation(transform.position + new Vector3(0, 3 * collider.bounds.extents.y, 0), Quaternion.LookRotation((Camera.main.transform.position - transform.position).normalized));
            UI_elem.Rotate(Vector3.up, 180f);
        }
    }

    public virtual void RemoveInteraction() {
        Camera.main.transform.GetChild(0).gameObject.SetActive(true);
        interactable = false;
        foreach (Transform UI_elem in actionsUI) {
            UI_elem.gameObject.SetActive(false);
        }
    }

}
