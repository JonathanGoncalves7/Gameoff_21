using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 inicitalPosition;
    private Quaternion inicitalRotation;
    public bool isDead = false;

    private SanityController m_SanityController;
    private PlayerMovement m_PlayerMovement;

    public static PlayerController Instance;


    private void Start()
    {
        inicitalPosition = transform.position;
        inicitalRotation = transform.rotation;

        m_SanityController = GetComponent<SanityController>();
        m_PlayerMovement = GetComponent<PlayerMovement>();
    }

    private void Awake()
    {
        Instance = this;
    }

    public void Death()
    {
        if (!isDead)
        {
            StartCoroutine(LoadLevel.Instance.StartCrossFade());

            isDead = true;

            EyesManager.Instance.ChangeStateLeftAndRight(EyesManager.state.closed);

            TextPanel.Instance.ShowTextPanel("You died. It will be sent to safe rom!");

            EyesManager.Instance.ChangeStateLeftEye(EyesManager.state.opened);
            EyesManager.Instance.ChangeStateRightEye(EyesManager.state.opened);
            EyesManager.Instance.ChangeStateLeftAndRight(EyesManager.state.opened);

            m_SanityController.Reset();
            m_PlayerMovement.xRotation = 0;

            Respawn();

            m_PlayerMovement.playerStartGame = false;
            isDead = false;

            StartCoroutine(LoadLevel.Instance.EndCrossFade());
        }
    }

    public void Respawn()
    {
        transform.position = inicitalPosition;
        transform.rotation = inicitalRotation;
    }
}
