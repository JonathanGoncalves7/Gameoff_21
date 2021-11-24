using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPanel : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject TextPanelProp;

    private GameObject CurrentPopup;

    public static TextPanel Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowTextPanel(string text)
    {
        if (text == "")
            return;

        CurrentPopup = Instantiate(TextPanelProp, Canvas.transform);
        CurrentPopup.GetComponent<TextPanelControl>().textMeshPro.text = text;

        GameManager.Instance.StopGame(true);
    }
}