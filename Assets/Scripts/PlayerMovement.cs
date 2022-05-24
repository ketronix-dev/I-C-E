using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float Speed = 0f;
    [SerializeField] private Rigidbody2D rb = null;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Debug.Log(x);
        if( x >= 0.1f)
        {
            rb.AddForce(new Vector2(x*Speed*Time.deltaTime,0), ForceMode2D.Impulse);
        }
        else if( x <= -0.1f)
        {
            rb.AddForce(new Vector2(x*Speed*Time.deltaTime,0), ForceMode2D.Impulse);
        }
    }
}
