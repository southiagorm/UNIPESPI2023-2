using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private Transform[] _points;
    [SerializeField]
    private Transform _pointAux;

    private void Start()
    {
        //points[0] = pointA
        transform.position = _points[0].position;
        _pointAux.position = _points[1].position;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _pointAux.position, _speed*Time.deltaTime);

        if(transform.position.x >= _points[1].position.x)
        {
            _pointAux.position = _points[0].position;
        }
        if(transform.position.x <= _points[0].position.x)
        {
            _pointAux.position = _points[1].position;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}
