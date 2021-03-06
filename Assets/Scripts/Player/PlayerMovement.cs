using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Walk")]
    public float speed = 5f;
    public float mouseSensitivy = 130f;
    public Transform rootCamera;

    [Header("Run")]
    public KeyCode runKeyCode = KeyCode.LeftShift;
    public float runSpeed = 8f;
    public float timeRuning = 2f;
    public float timeToRestoreRuning = 5f;

    private float restoreRuning = 0f;
    private float timeStopRuning = 0f;
    private bool canRuning = false;
    private bool inRuning = false;

    public bool playerStartGame = false;


    Rigidbody m_Rigidbody;
    PlayerController m_PlayerController;

    public float xRotation = 0f;


    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_PlayerController = GetComponent<PlayerController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_PlayerController.isDead)
        {
            return;
        }

        StartRuning();
        MovePlayer();
        MoveCamera();
    }

    private void StartRuning()
    {
        restoreRuning += Time.deltaTime;

        if (restoreRuning > timeToRestoreRuning)
        {
            canRuning = true;
        }
        else
        {
            canRuning = false;
        }

        if (inRuning)
        {
            timeStopRuning += Time.deltaTime;

            if (timeStopRuning > timeRuning)
            {
                inRuning = false;
                timeStopRuning = 0f;
            }
        }

        if (Input.GetKey(runKeyCode) && canRuning && !inRuning)
        {
            inRuning = true;
            restoreRuning = 0f;
        }
    }

    private void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (x > 0 || z > 0)
        {
            playerStartGame = true;
        }

        Vector3 move = transform.right * x + transform.forward * z;

        float currentSpeed = speed;

        if (inRuning)
        {
            currentSpeed = runSpeed;
        }

        m_Rigidbody.MovePosition(transform.position + move * Time.deltaTime * currentSpeed);

    }

    private void MoveCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivy * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivy * Time.deltaTime;

        if (mouseX > 0 || mouseY > 0)
        {
            playerStartGame = true;
        }

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        rootCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
