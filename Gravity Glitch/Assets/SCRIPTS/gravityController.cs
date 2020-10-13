using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityController : MonoBehaviour
{
    private Rigidbody _playerRigidBody = null;
    private Transform _playerTransform = null;
    void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody>();
        _playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Vector3 alwaysDown = _playerTransform.up;
        // _playerRigidBody.AddForce(alwaysDown);
        _playerRigidBody.AddRelativeForce(Vector3.up * -9.81f);
    }
}
