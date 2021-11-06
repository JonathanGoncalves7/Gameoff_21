using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Walk")]
    private float Speed = 5f;

    private Rigidbody _rigidBody;
    private Animator _animator;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        _animator.SetFloat("horizontal", horizontal);
        _animator.SetFloat("vertical", vertical);

       // Vector3 pos = ()


        //_rigidBody.MovePosition();
    }
}
