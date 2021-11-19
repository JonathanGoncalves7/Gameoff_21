using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField]
    public List<PuzzleInfo> puzzleInfos;

    public static PuzzleManager Instance;

    [SerializeField]
    int currentPuzzle = -1;
    [SerializeField]
    int currentObject = 0;

    private void Awake()
    {
        Instance = this;

        currentPuzzle = -1;
        currentObject = 0;
    }

    private void Start()
    {
        NextPuzzle();
    }

    public void ChangeCurrentObjectInteraciton(bool value)
    {
        puzzleInfos[currentPuzzle].PuzzleObjects[currentObject].GetComponent<PuzzleObjectInteraction>().EnableInteraction = value;
    }


    public void NextStepPuzzle()
    {
        ChangeCurrentObjectInteraciton(false);

        if (currentObject >= puzzleInfos[currentPuzzle].PuzzleObjects.Count - 1)
        {
            if (currentPuzzle < puzzleInfos.Count - 1)
            {
                NextPuzzle();
            }

            return;
        }

        currentObject++;

        ChangeCurrentObjectInteraciton(true);
    }

    private void NextPuzzle()
    {
        currentPuzzle++;
        currentObject = 0;

        for (int i = 0; i < puzzleInfos[currentPuzzle].PuzzleObjects.Count; i++)
        {
            puzzleInfos[currentPuzzle].PuzzleObjects[i].GetComponent<PuzzleObjectInteraction>().isInteraction = false;

            if (i == 0)
            {
                puzzleInfos[currentPuzzle].PuzzleObjects[i].GetComponent<PuzzleObjectInteraction>().EnableInteraction = true;
            }
            else
            {
                puzzleInfos[currentPuzzle].PuzzleObjects[i].GetComponent<PuzzleObjectInteraction>().EnableInteraction = false;
            }
        }
    }
}
