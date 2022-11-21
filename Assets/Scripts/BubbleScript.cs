using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    private float _length;
    public AnimationCurve myCurve;
    // Material _mat;
    Renderer _rend;
    void Start()
    {
        // _length = GetComponent<SpriteRenderer>().bounds.size.;
        // _mat = GetComponent<Material>();
        _rend = GetComponent<Renderer>();

    }
    private void Update() {
        _rend.material.mainTextureOffset += new Vector2(0, -0.2f * Time.deltaTime);
        // transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);

    }
}
