using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pear : MonoBehaviour
{
    [SerializeField]
    bool interactable = false;
    bool selected = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
            else transform.GetChild(0).gameObject.SetActive(false);
            Camera.main.transform.GetChild(0).gameObject.SetActive(!selected);
        }

        if (selected) {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 200f, LayerMask.GetMask("Surface"))) {
                print(hit.distance);
                transform.position = hit.point + 0.1f * hit.normal;
                //transform.LookAt(Camera.main.transform);
            }
        }

    }

    public void AllowInteraction() {
        interactable = true;
        Transform move_button = transform.GetChild(0);
        move_button.gameObject.SetActive(true);
        move_button.LookAt(Camera.main.transform);
        move_button.Rotate(Vector3.up, 180f);
    }

    public void RemoveInteraction() {
        if (!selected) {
            interactable = false;
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

}
