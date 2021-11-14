using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEyes : MonoBehaviour
{

    [Header("Left")]
    bool leftOpen = true;

    [Header("Right")]
    bool rightOpen = true;

    // [Header("Left and Right")]


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Input.GetKeyDown(KeyCode.E))
        {
            EyesManager.Instance.ChangeStateLeftAndRight();
        }
        else
        if (Input.GetKeyDown(KeyCode.Q))
        {
            EyesManager.Instance.ChangeStateLeftEye();
        }
        else
        if (Input.GetKeyDown(KeyCode.E))
        {
            EyesManager.Instance.ChangeStateRightEye();
        }
    }
}
