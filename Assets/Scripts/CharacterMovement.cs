using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private Rigidbody2D _rigidbody;
    private Vector2 _inputValue;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _inputValue = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Move();
    }

    private void Move()
    {
        _rigidbody.velocity = _inputValue * + _moveSpeed;
    }
}
