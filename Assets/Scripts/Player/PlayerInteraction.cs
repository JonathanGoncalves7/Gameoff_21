using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public KeyCode keyInteraction = KeyCode.Mouse0;
    public float rayDistance = 2f;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        CheckInteractables();
    }

    void CheckInteractables()
    {
        if (GameManager.Instance.isStopGame)
            return;

        RaycastHit hit;

        Vector3 rayOrigin = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));

        if (Physics.Raycast(rayOrigin, mainCamera.transform.forward, out hit, rayDistance))
        {
            IInteraction interactable = hit.collider.GetComponent<IInteraction>();

            if (interactable != null)
            {
                if (Input.GetKeyDown(keyInteraction))
                {
                    interactable.Interact();
                }
            }
        }
    }
}
