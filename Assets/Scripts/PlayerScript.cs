using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerScript : MonoBehaviour
{
    Transform _transform;
    Rigidbody2D rb;
    float _speed = 8.2f;
    int collected = 0;
    int _health = 3;
    float Vertical;
    bool _Damaged = false;
    Animator _anim;
     public event System.Action<int> IsCollected;
     public event System.Action<int> IsHitted;
     public event System.Action IsDead;

    void Start()
    {
        _transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {        
        Move();
        DeadCheck();

        if (_Damaged)
        {
        _anim.SetBool("Damaged", true);
        _Damaged=false;
        _health--;
        IsHitted?.Invoke(_health);
            
        }
        else
        {
            _anim.SetBool("Damaged", false);
        }
  
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
            _Damaged = true;
        }
    }

        public void Move()
        {
            // Horizontal = Input.GetAxis("Horizontal");
            // if(Horizontal == 0f) return;
            // Vertical = Input.GetAxis("Vertical");
            float movement = (_speed * Input.GetAxis("Vertical")) * Time.deltaTime;
            _transform.Translate(Time.deltaTime * _speed,1 * movement, 0);
            _transform.localPosition = new Vector3(transform.localPosition.x,(Mathf.Clamp(transform.localPosition.y, -8.5f, 7.5f)), transform.localPosition.z);

        // _transform.position += new Vector3(Time.deltaTime * _speed, Vertical, 0);
        }

        public void DeadCheck()
        {
            if(_health == 0)
            {
                IsDead?.Invoke();
                
                Destroy(this.gameObject);
            }
        }

    
}
