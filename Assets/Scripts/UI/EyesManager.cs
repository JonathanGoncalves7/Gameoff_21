using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesManager : MonoBehaviour
{
    public Animator LeftEye;
    public Animator RightEye;
    public Animator LeftAndRightEyes;

    public enum state
    {
        opened = 1,
        closed = 2
    }

    const string PARAM_NAME = "Opened";


    public static EyesManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public bool LeftEyesIsOpen()
    {
        return LeftEye.GetInteger(PARAM_NAME) != (int)state.closed;
    }

    public bool RightEyesIsOpen()
    {
        return RightEye.GetInteger(PARAM_NAME) != (int)state.closed;
    }

    public bool LeftAndRightEyesIsOpen()
    {
        return LeftAndRightEyes.GetInteger(PARAM_NAME) != (int)state.closed;
    }



    public void ChangeStateLeftEye()
    {
        /*
        state currentState = LeftEyesIsOpen() ? EyesManager.state.opened : EyesManager.state.closed;


        switch (currentState)
        {
            case state.opened:

                if (!LeftAndRightEyesIsOpen())
                {
                    ChangeStateLeftAndRight();
                    RightEye.SetInteger(PARAM_NAME, (int)state.closed);
                    return;
                }

                break;

            case state.closed:

                if (!RightEyesIsOpen())
                {
                    ChangeStateLeftAndRight();
                    return;
                }

                break;
        }

*/

        state newState = LeftEyesIsOpen() ? state.closed : state.opened;

        LeftEye.SetInteger(PARAM_NAME, (int)newState);
    }

    public void ChangeStateRightEye()
    {
        state newState = RightEyesIsOpen() ? state.closed : state.opened;

        RightEye.SetInteger(PARAM_NAME, (int)newState);
    }

    public void ChangeStateLeftAndRight()
    {
        state newState = LeftAndRightEyesIsOpen() ? EyesManager.state.closed : EyesManager.state.opened;

        LeftAndRightEyes.SetInteger(PARAM_NAME, (int)newState);
    }
}
