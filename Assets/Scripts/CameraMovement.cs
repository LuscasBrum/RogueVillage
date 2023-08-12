using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform _character; 
    [SerializeField] private float _smoothSpeed = 0.125f;
    [SerializeField] private Vector3 _offset;

    private void Awake()
    {
        _character = FindObjectOfType<CharacterMovement>().transform;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = _character.position + _offset;

        desiredPosition.z = transform.position.z;
        transform.rotation = Quaternion.identity;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed); 
        transform.position = smoothedPosition;
    }
}
