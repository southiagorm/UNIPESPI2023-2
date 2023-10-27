using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlataformaTempo : MonoBehaviour
{
    private bool fall = false;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (fall == true)
        {
            _rb.bodyType = RigidbodyType2D.Dynamic;
            _rb.gravityScale = 4.0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(TimeFall());
            Destroy(this.gameObject, 1f);
        }
    }

    IEnumerator TimeFall()
    {
        fall = false;
        yield return new WaitForSeconds(5);
        fall = true;
    }
}
