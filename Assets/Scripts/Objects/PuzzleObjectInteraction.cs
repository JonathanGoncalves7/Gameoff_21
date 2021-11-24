using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleObjectInteraction : MonoBehaviour, IInteraction
{
    public bool EnableInteraction = false;
    public bool isInteraction = false;

    [Header("Messages")]
    //    public string MessageNoInteraction = "No Interaction";
    public string MessageInteraction = "Interaction";
    public string MessageAfterInteraction = "After Interaction";

    public void Interact()
    {
        if (EnableInteraction)
        {
            if (PuzzleManager.Instance.NextStepPuzzle(gameObject))
            {
                TextPanel.Instance.ShowTextPanel(MessageInteraction);
                isInteraction = true;
            }
        }
        else
        {
            if (isInteraction)
            {
                TextPanel.Instance.ShowTextPanel(MessageAfterInteraction);
            }
        }
    }
}
