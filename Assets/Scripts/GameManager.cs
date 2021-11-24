using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isStopGame = false;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void StopGame(bool unlockCursor)
    {
        Time.timeScale = 0f;
        isStopGame = true;

        if (unlockCursor)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void ResumeGame(bool lockCursor)
    {
        Time.timeScale = 1f;
        isStopGame = false;

        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
