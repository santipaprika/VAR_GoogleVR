using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pear : MonoBehaviour
{
    [SerializeField]
    bool interactable = false;

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
            transform.Translate(new Vector3(-0.4f, 0, 0));
        }
    }

    public void AllowInteraction() {
        interactable = true;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void RemoveInteraction() {
        interactable = false;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

}
