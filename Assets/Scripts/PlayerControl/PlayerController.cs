using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Parallax.Base;

[DisallowMultipleComponent, RequireComponent(typeof(Rigidbody))]
public class PlayerController : BaseObject
{
    [SerializeField] private float _speed = 250f;
    [SerializeField] private float _jumpForce = 150f;

    [SerializeField] private bool _isGrounded = true;

    Rigidbody rb;

    public override void BaseObjectStart()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void BaseObjectFixedUpdate()
    {
        HandleMovement();
        HandleJump();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontal * _speed * Time.fixedDeltaTime, rb.velocity.y);
    }

    private void HandleJump()
    {
        if(_isGrounded)
        {
            float vertical = (Input.GetAxisRaw("Vertical") > 0) ? 1 : 0;

            rb.AddForce(Vector2.up * vertical * _jumpForce * Time.deltaTime, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Platform"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Platform"))
        {
            _isGrounded = false;
        }
    }
}
