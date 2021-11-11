using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour, IInteraction
{
    Animator _animator;

    public bool isOpen = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Open()
    {
        _animator.SetBool("Open", true);
        isOpen = true;
    }

    void Close()
    {
        _animator.SetBool("Open", false);
        isOpen = false;
    }

    public void Interact()
    {
        if (isOpen)
        {
            Close();
        }
        else
        {
            Open();
        }
    }
}
