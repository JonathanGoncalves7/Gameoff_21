using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public LoadLevel loadLevel;

    public void Play()
    {
        loadLevel.LoadLevelWithIndex(1);
    }

    public void Options()
    {
        loadLevel.LoadLevelWithIndex(2);
    }

}
