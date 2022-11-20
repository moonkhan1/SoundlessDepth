using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiableController : MonoBehaviour
{
   Transform _transform;
   float _speed = 6f;
  
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _transform.position -= new Vector3(Time.fixedDeltaTime * _speed, 0, 0);
    }

    
}
