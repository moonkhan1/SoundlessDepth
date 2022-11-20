using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float _length;
    private float _startpos;
    public float _parallaxEff;
    public GameObject _camera;
    void Start()
    {
        _startpos = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    void FixedUpdate()
    {
        float followCam = (_camera.transform.position.x * (1-_parallaxEff));
        float move = _camera.transform.position.x * _parallaxEff;

        transform.position = new Vector3(_startpos + move, transform.position.y, transform.position.z);

        if (followCam > _startpos + _length)
        {
            _startpos += _length;
        }
        
        else if (followCam < _startpos - _length)
        {
            _startpos -= _length;
        }
    }
}
