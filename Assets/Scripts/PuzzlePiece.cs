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
            bool x_rotation_constraint, y_rotation_constraint, z_rotation_constraint;
            switch (puzzlePiece) {
                case PUZZLE_PIECES.Cube:
                    x_rotation_constraint = transform.rotation.eulerAngles.x % 90 < 10 || transform.rotation.eulerAngles.x % 90 > 80;
                    y_rotation_constraint = transform.rotation.eulerAngles.y % 90 < 10 || transform.rotation.eulerAngles.y % 90 > 80;
                    z_rotation_constraint = transform.rotation.eulerAngles.z % 90 < 10 || transform.rotation.eulerAngles.z % 90 > 80;
                    break;
                case PUZZLE_PIECES.Cylinder:
                    x_rotation_constraint = transform.rotation.eulerAngles.x % 180 < 10 || transform.rotation.eulerAngles.x % 180 > 170;
                    y_rotation_constraint = true;
                    z_rotation_constraint = transform.rotation.eulerAngles.z % 180 < 10 || transform.rotation.eulerAngles.z % 180 > 170;
                    break;
                case PUZZLE_PIECES.Torus:
                    x_rotation_constraint = true;
                    y_rotation_constraint = transform.rotation.eulerAngles.y % 180 < 10 || transform.rotation.eulerAngles.y % 180 > 170;
                    z_rotation_constraint = transform.rotation.eulerAngles.z % 180 < 10 || transform.rotation.eulerAngles.z % 180 > 170;
                    break;
                default:
                    x_rotation_constraint = y_rotation_constraint = z_rotation_constraint = true;
                    break;
            }

            bool scale_constraint = transform.localScale.x > 0.25 && transform.localScale.x < 0.35; // will be the same for every axis

            if (x_rotation_constraint && y_rotation_constraint && z_rotation_constraint && scale_constraint) {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<GrabbableItem>().OnButtonDownA();  //this will unselect and hide UI
                GetComponent<GrabbableItem>().enabled = false;

                transform.parent = FindObjectOfType<PuzzleSlot>().transform.parent;
                transform.localPosition = pieceLocalPositions[puzzlePiece];
            }
        }
    }
}
