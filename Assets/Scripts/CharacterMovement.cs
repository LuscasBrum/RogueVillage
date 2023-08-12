using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private Vector2 _inputValue;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _inputValue = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        bool isWalking = _inputValue.magnitude > 0;
        _animator.SetBool("IsWalking", isWalking);

        if (Input.GetButtonDown("Fire1"))
        {
            _animator.SetTrigger("Attack");
        }

        Move();
    }

    private void Move()
    {
        _rigidbody.velocity = _inputValue * + _moveSpeed;
    }
}
