using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Popup : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject PopupProp;

    private GameObject CurrentPopup;

    public static Popup Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowPopup(string text)
    {
        if (text == "")
            return;

        if (CurrentPopup != null)
        {
            Destroy(CurrentPopup);
        }

        CurrentPopup = Instantiate(PopupProp, Canvas.transform);
        CurrentPopup.GetComponent<TextMeshProUGUI>().text = text;
    }
}