using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 inicitalPosition;
    private Quaternion inicitalRotation;
    public bool isDead = false;

    private SanityController m_SanityController;

    public static PlayerController Instance;


    private void Start()
    {
        inicitalPosition = transform.position;
        inicitalRotation = transform.rotation;
        m_SanityController = GetComponent<SanityController>();
    }

    private void Awake()
    {
        Instance = this;
    }

    public void Death()
    {
        if (!isDead)
        {
            isDead = true;
            EyesManager.Instance.ChangeStateLeftAndRight(EyesManager.state.closed);
            TextPanel.Instance.ShowTextPanel("You died. It will be sent to safe rom!");

            m_SanityController.Reset();

            Respawn();

            EyesManager.Instance.ChangeStateLeftEye(EyesManager.state.opened);
            EyesManager.Instance.ChangeStateRightEye(EyesManager.state.opened);
            EyesManager.Instance.ChangeStateLeftAndRight(EyesManager.state.opened);
        }
    }

    public void Respawn()
    {
        transform.position = inicitalPosition;
        transform.rotation = inicitalRotation;


        isDead = false;
    }
}
