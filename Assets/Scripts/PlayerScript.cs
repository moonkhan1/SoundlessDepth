using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerScript : MonoBehaviour
{
    Transform _transform;
    Rigidbody2D rb;
    float _speed = 5f;
    int collected = 0;
     public event System.Action<int> IsCollected;

    void Start()
    {
        _transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        var seq = DOTween.Sequence();

        _transform.position += new Vector3(1.5f * _speed, 0, 0) * Time.deltaTime;
    }
    

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Collectiable"))
        {
            collected++;
            IsCollected?.Invoke(collected);
            Destroy(other.gameObject);
        }
        if(other.CompareTag("Medusa"))
        {
            Destroy(other.gameObject);
            _transform.DOPunchScale(new Vector2(0.5f,0.5f),0.5f,4,0.5f);
        }

    }
}
