using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractableItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool interactable = false;
    public bool selected = false;
    public List<Transform> actionsUI;

    void Update()
    {
        if (!interactable) return;

        bool buttonDownA, buttonDownB;
        buttonDownA = buttonDownB = false;

#if UNITY_EDITOR 
        buttonDownA = Input.GetKeyDown("a");
#else
        buttonDownA = Input.GetButtonDown("A");
#endif

        if (buttonDownA) {
            selected = !selected;
            if (!selected) RemoveInteraction();
            else actionsUI[0].gameObject.SetActive(false);
            Camera.main.transform.GetChild(0).gameObject.SetActive(!selected);
        }

        if (selected) {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 200f, LayerMask.GetMask("Surface"))) {
                transform.position = hit.point + GetComponent<Collider>().bounds.extents.y * hit.normal;
            }
        }

    }
    public void OnPointerEnter(PointerEventData pointerEventData) {
        AllowInteraction();
    }
    public void OnPointerExit(PointerEventData pointerEventData) {
        RemoveInteraction();
    }

    public void AllowInteraction() {
        interactable = true;
        Transform move_button = actionsUI[0];
        move_button.gameObject.SetActive(true);
        Collider collider = GetComponent<Collider>();
        move_button.SetPositionAndRotation(transform.position + new Vector3(0, 3 * collider.bounds.extents.y, 0), Quaternion.LookRotation((Camera.main.transform.position - transform.position).normalized));
        move_button.Rotate(Vector3.up, 180f);
    }

    public void RemoveInteraction() {
        if (!selected) {
            Camera.main.transform.GetChild(0).gameObject.SetActive(true);
            interactable = false;
            actionsUI[0].gameObject.SetActive(false);
        }
    }

}
