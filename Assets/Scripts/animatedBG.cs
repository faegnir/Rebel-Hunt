using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatedBG : MonoBehaviour
{
    // Start is called before the first frame update
    public float hýz = 4f;
    private Vector3 start;

    void Start()
    {
        start = transform.position;
    }

    void Update()
    {
        transform.Translate(translation: Vector3.down * hýz * Time.deltaTime);
        if (transform.position.y < -13.92)
            transform.position = start;
    }
}
