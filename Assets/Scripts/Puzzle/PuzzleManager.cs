using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField]
    public List<PuzzleInfo> puzzleInfos;

    public static PuzzleManager Instance;

    bool inPuzzle = false;
    int currentPuzzle = -1;
    int currentObject = 0;

    private void Awake()
    {
        Instance = this;

        currentPuzzle = -1;
        currentObject = 0;
    }

    private void Start()
    {
        StartPuzzles();
    }

    public void ChangeCurrentObjectInteraciton(bool value)
    {
        puzzleInfos[currentPuzzle].PuzzleObjects[currentObject].GetComponent<PuzzleObjectInteraction>().EnableInteraction = value;

        if (currentObject == 0)
        {
            puzzleInfos[currentPuzzle].Enemy.GetComponent<EnemyMovement>().patrol = false;
            inPuzzle = true;
        }
    }


    public bool NextStepPuzzle(GameObject _gameObject)
    {
        int puzzleIndex = -1;
        int objectIndex = -1;

        for (int i = 0; i < puzzleInfos.Count; i++)
        {
            for (var j = 0; j < puzzleInfos[i].PuzzleObjects.Count; j++)
            {
                if (_gameObject.Equals(puzzleInfos[i].PuzzleObjects[j]))
                {
                    puzzleIndex = i;
                    objectIndex = j;

                    break;
                }
            }
        }

        if (inPuzzle)
        {
            if (currentPuzzle != puzzleIndex)
            {
                return false;
            }
        }
        else
        {
            currentPuzzle = puzzleIndex;
            currentObject = objectIndex;
        }

        ChangeCurrentObjectInteraciton(false);

        if (currentObject >= puzzleInfos[currentPuzzle].PuzzleObjects.Count - 1)
        {
            FinishPuzzle();

            return true;
        }

        currentObject++;

        ChangeCurrentObjectInteraciton(true);

        return true;
    }

    private void FinishPuzzle()
    {
        inPuzzle = false;
    }

    private void StartPuzzles()
    {
        for (int i = 0; i < puzzleInfos.Count; i++)
        {
            for (int j = 0; j < puzzleInfos[i].PuzzleObjects.Count; j++)
            {
                PuzzleObjectInteraction objectInteraction = puzzleInfos[i].PuzzleObjects[j].GetComponent<PuzzleObjectInteraction>();

                objectInteraction.isInteraction = false;
                objectInteraction.EnableInteraction = j == 0;
            }
        }
    }
}
