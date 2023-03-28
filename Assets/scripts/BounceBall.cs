using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBall : MonoBehaviour
{
    [SerializeField] float _minY = -5.5f;
    [SerializeField] float _maxVelocity = 15f;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < _minY)
        {
            transform.position = Vector3.zero;
            rb.velocity = Vector3.zero;
        }
        if (rb.velocity.magnitude > _maxVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, _maxVelocity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Brick"))
        { 
            Destroy(collision.gameObject);
        }
    }
}
