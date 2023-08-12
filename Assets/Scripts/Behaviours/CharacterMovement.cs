using UnityEngine;

namespace RogueStore
{

    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _intectableArea;

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
            Move();

            if (Input.GetButtonDown("Fire1"))
            {
                Attack();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact();
            }
        }

        private void Move()
        {
            _inputValue = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            bool isWalking = _inputValue.magnitude > 0;
            _animator.SetBool("IsWalking", isWalking);

            _rigidbody.velocity = _inputValue * +_moveSpeed;
        }

        private void Attack()
        {
            _animator.SetTrigger("Attack");
        }

        private void Interact()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _intectableArea);

            foreach (Collider2D collider in colliders)
            {
                var interactable = collider.GetComponent<Interactable>();

                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        }
    }
}