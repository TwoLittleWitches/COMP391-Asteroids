
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Left to right movement only
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0.0f);
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
