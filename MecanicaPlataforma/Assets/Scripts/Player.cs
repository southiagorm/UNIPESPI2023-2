using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator _anim;
    private SpriteRenderer _sprite;
    private float _h;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
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
        _anim.SetFloat("Run", Mathf.Abs(_h));
    }
}
