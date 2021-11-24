using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextPanelControl : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    public void Close()
    {
        GameManager.Instance.ResumeGame(true);
        
        Destroy(this.gameObject);
    }
}
