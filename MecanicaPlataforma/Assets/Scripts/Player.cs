using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator _anim;
    private SpriteRenderer _sprite;
    private Rigidbody2D _rb;

    private float _h;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _jumpForce;

    [SerializeField]
    private GameObject _ground;
    [SerializeField]
    private LayerMask _layerMask;

    [SerializeField]
    private bool _isGrounded;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        if(_h < 0)
        {
            _sprite.flipX = true;
        }else if(_h > 0)
        {
            _sprite.flipX = false;
        }
        Jump();
        _anim.SetFloat("Run", Mathf.Abs(_h));
        _anim.SetFloat("Jump", _rb.velocity.y);
        _anim.SetBool("IsGround", _isGrounded);
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(_ground.transform.position, 0.3f, _layerMask);
        _rb.velocity = new Vector2(_h*_speed*Time.deltaTime, _rb.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            print("Pular");
            _rb.AddForce(new Vector2(0,_jumpForce), ForceMode2D.Impulse);
        }
    }
}
