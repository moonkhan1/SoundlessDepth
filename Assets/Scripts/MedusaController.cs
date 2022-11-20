using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MedusaController : MonoBehaviour
{
     Transform _transform;
     Rigidbody2D rb;
     float _speed = 5f;
    void Start()
    {
        _transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
         _transform.position -= new Vector3(Time.fixedDeltaTime * _speed, 0, 0);
            
        

        

    }
}
