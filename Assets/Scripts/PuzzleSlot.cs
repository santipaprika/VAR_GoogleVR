using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSlot : MonoBehaviour
{
    public PUZZLE_PIECES puzzleSlot;
    private int count;
    void Start()
    {
        count = 0;
    }
    private void Update()
    {
        count = count + 1;
        Debug.Log(count);
    }
    

}
