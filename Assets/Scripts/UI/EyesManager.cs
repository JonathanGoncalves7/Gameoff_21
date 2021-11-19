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

    public bool LeftEyeIsOpen()
    {
        return LeftEye.GetInteger(PARAM_NAME) != (int)state.closed;
    }

    public bool RightEyeIsOpen()
    {
        return RightEye.GetInteger(PARAM_NAME) != (int)state.closed;
    }

    public bool LeftAndRightEyesIsOpen()
    {
        return LeftAndRightEyes.GetInteger(PARAM_NAME) != (int)state.closed;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Input.GetKeyDown(KeyCode.E))
        {

            if (!LeftAndRightEyesIsOpen())
            {
                ChangeStateLeftEye(state.opened);
                ChangeStateRightEye(state.opened);
            }

            InvertStateLeftAndRight();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!LeftAndRightEyesIsOpen())
            {
                ChangeStateRightEye(state.closed);
                ChangeStateLeftEye(state.opened);
                ChangeStateLeftAndRight(state.opened);
                return;
            }

            if (LeftEyeIsOpen() && !RightEyeIsOpen())
            {
                ChangeStateLeftEye(state.closed);
                ChangeStateRightEye(state.closed);
                ChangeStateLeftAndRight(state.closed);
                return;
            }

            InvertStateLeftEye();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            if (!LeftAndRightEyesIsOpen())
            {
                ChangeStateLeftEye(state.closed);
                ChangeStateRightEye(state.opened);
                ChangeStateLeftAndRight(state.opened);
                return;
            }

            if (!LeftEyeIsOpen() && RightEyeIsOpen())
            {
                ChangeStateLeftEye(state.closed);
                ChangeStateRightEye(state.closed);
                ChangeStateLeftAndRight(state.closed);
                return;
            }

            InvertStateRightEye();
        }

    }


    public void ChangeStateLeftEye(state newState)
    {
        LeftEye.SetInteger(PARAM_NAME, (int)newState);
    }

    public void ChangeStateRightEye(state newState)
    {
        RightEye.SetInteger(PARAM_NAME, (int)newState);
    }

    public void ChangeStateLeftAndRight(state newState)
    {
        LeftAndRightEyes.SetInteger(PARAM_NAME, (int)newState);

        if (newState == state.closed)
        {

            ChangeStateLeftEye(state.closed);
            ChangeStateRightEye(state.closed);
        }
    }

    public void InvertStateLeftEye()
    {
        state newState = LeftEyeIsOpen() ? state.closed : state.opened;

        ChangeStateLeftEye(newState);
    }

    public void InvertStateRightEye()
    {
        state newState = RightEyeIsOpen() ? state.closed : state.opened;

        ChangeStateRightEye(newState);
    }

    public void InvertStateLeftAndRight()
    {
        state newState = LeftAndRightEyesIsOpen() ? state.closed : state.opened;

        ChangeStateLeftAndRight(newState);
    }

}
