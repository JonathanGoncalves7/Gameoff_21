using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButtons : MonoBehaviour
{
    public LoadLevel loadLevel;

    public void Return()
    {
        loadLevel.LoadLevelWithIndex(0);
    }
}
