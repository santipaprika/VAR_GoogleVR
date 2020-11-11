using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{

    public GameObject thing;
    public GameObject myHand;

    bool inHands = false;
    Vector3 thingPos;

    // Start is called before the first frame update
    void Start()
    {
        thingPos = thing.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if (!inHands)
            {
                thing.transform.SetParent(myHand.transform);
                thing.transform.localPosition = new Vector3(0f,-.62f,0f);
                inHands = true;
            }
            else if (inHands)
            {
                this.GetComponent<PlayerGrab>().enabled = false; //if we have the thing in hand, desable the script
                thing.transform.SetParent(null);
                thing.transform.localPosition = thingPos;
                inHands = false;
            }
        }
    }
}
