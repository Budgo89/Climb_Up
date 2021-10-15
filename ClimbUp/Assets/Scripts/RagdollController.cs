using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    [SerializeField] private List<Rigidbody> _ragdollElements;
    [SerializeField] private GameObject _sphereLeft;
    [SerializeField] private GameObject _sphereRight;
    private Rigidbody[] _rigidbodies;
    private Collider[] _colliders;
    private float speed = 100;

    private void Awake()
    {
        _rigidbodies = gameObject.GetComponentsInChildren<Rigidbody>();
        _colliders = gameObject.GetComponentsInChildren<Collider>();
        Mass();
    }

    private void Mass()
    {
        foreach (var bodies in _rigidbodies)
        {
            bodies.mass = 0.001f;
        }
    }

    public void Update()
    {
        _ragdollElements[0].transform.position = Vector3.Lerp(_ragdollElements[0].transform.position, _sphereLeft.transform.position, speed * Time.deltaTime);
        _ragdollElements[1].transform.position = Vector3.Lerp(_ragdollElements[1].transform.position, _sphereRight.transform.position, speed * Time.deltaTime);
    }
}
