using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRotate : MonoBehaviour
{
    [SerializeField] float _rotateSpeed;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, _rotateSpeed * Time.deltaTime);
    }
}
