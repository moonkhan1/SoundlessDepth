using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    private float _length;
    public AnimationCurve myCurve;

    void Start()
    {
        // _length = GetComponent<SpriteRenderer>().bounds.size.;

    }
    private void Update() {
        transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);

    }
}
