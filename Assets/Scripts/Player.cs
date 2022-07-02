using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float Speed;
    public float JumpForce;
    public Transform Sensor;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update() {
        float move = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        bool isJumping = !Physics2D.Linecast(transform.position, Sensor.position, 1 << LayerMask.NameToLayer("Foreground"));
        _animator.SetBool("isRunning", Mathf.Abs(Input.GetAxis("Horizontal")) > 0);
        _animator.SetBool("isJumping", isJumping);
        _spriteRenderer.flipX = (Mathf.Abs(Input.GetAxis("Horizontal")) > 0) ? Input.GetAxis("Horizontal") < 0 : _spriteRenderer.flipX;

        transform.Translate(move, 0.0f, 0.0f);

        if (Input.GetButton("Jump") && !isJumping) {
            _rigidbody2D.velocity = new Vector2(0.0f, JumpForce);
        }
    }
}
