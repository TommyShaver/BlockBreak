using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovment : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _maxX;
    private float _movementHorizontal;

    [SerializeField] GameObject _bounceBall;
    // Update is called once per frame
    void Update()
    {
        _movementHorizontal = Input.GetAxis("Horizontal");
        if((_movementHorizontal > 0 && transform.position.x <_maxX) || (_movementHorizontal < 0 && transform.position.x > -_maxX))
        { 
            transform.position += Vector3.right * _movementHorizontal * _speed * Time.deltaTime; 
        }
        if (_bounceBall.transform.position.y < -5.5f)
        {
            transform.position = new Vector3(0, -4, 0);
        }

    }
}
