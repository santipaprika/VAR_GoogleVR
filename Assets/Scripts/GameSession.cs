using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum tasks { PUZZLE, EAT };
public class GameSession : MonoBehaviour
{
    static public GameSession currentSession;


    [HideInInspector]
    public bool[] tasksDone = new bool[2];

    // To manage puzzle completition
    private int m_puzzleCount = 0;
    [HideInInspector]
    public int puzzleCount {
        get { return m_puzzleCount; }
        set
        {
            if (m_puzzleCount == value) return;
            m_puzzleCount = value;
            if (m_puzzleCount == 4) {
                tasksDone[(int)tasks.PUZZLE] = true;
                CheckProgress();
            }
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        currentSession = new GameSession();
        print(tasksDone);
    }


    public void CheckProgress() {
        foreach (bool task in tasksDone) {
            if (!task) return;
        }

        print("You win!");
    }
}
