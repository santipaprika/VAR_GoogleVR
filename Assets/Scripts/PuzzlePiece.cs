using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PUZZLE_PIECES { Cube, Sphere, Cylinder, Torus };
public class PuzzlePiece : MonoBehaviour
{
    public PUZZLE_PIECES puzzlePiece;
    private Dictionary<PUZZLE_PIECES, Vector3> pieceLocalPositions = new Dictionary<PUZZLE_PIECES, Vector3>() 
    {
        { PUZZLE_PIECES.Cube, new Vector3(-0.2535852f, 0.4662966f, 0.464f) },
        { PUZZLE_PIECES.Sphere, new Vector3(-0.2502505f, 0.4696297f, -0.4776183f) },
        { PUZZLE_PIECES.Torus, new Vector3(-0.2535852f, -0.4637034f, 0.4490483f) },
        { PUZZLE_PIECES.Cylinder, new Vector3(-0.2702506f, -0.449f, -0.49f) }
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (puzzlePiece == other.gameObject.GetComponent<PuzzleSlot>().puzzleSlot) {
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<InteractableItem>().selected = false;
            GetComponent<InteractableItem>().RemoveInteraction();
            GetComponent<InteractableItem>().enabled = false;

            transform.parent = FindObjectOfType<PuzzleSlot>().transform.parent;
            transform.localPosition = pieceLocalPositions[puzzlePiece];
        }
    }
}
