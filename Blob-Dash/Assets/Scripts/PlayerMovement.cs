using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private KeybindManager kb;
    public Rigidbody2D rb;

    Vector2 movement;

    private void Awake()
    {
        kb = FindObjectOfType<KeybindManager>();
    }
    // Update is called once per frame
    void Update()
    {
        //Input
        if (Input.GetKey(kb.GetKeyFor("UP")))
        {
            Debug.Log(kb.GetKeyFor("UP"));
            movement.y = 1;
        }
        if (Input.GetKey(kb.GetKeyFor("LEFT")))
        {
            Debug.Log(kb.GetKeyFor("LEFT"));
            movement.x = -1;
        }
        if (Input.GetKey(kb.GetKeyFor("DOWN")))
        {
            Debug.Log(kb.GetKeyFor("DOWN"));
            movement.y = -1;
        }
        if (Input.GetKey(kb.GetKeyFor("RIGHT")))
        {
            Debug.Log(kb.GetKeyFor("RIGHT"));
            movement.x = 1;
        }
        
        //movement.x = Input.GetAxisRaw("Horizontal"); //-1 to 1
        //movement.y = Input.GetAxisRaw("Vertical"); //-1 to 1

    }

    //Same as update, but called on a fixed timer (50 times/sec) 
    //it is considered more reliable for physics (update could be affected by fluctuation of frame rate)
    void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement.normalized*moveSpeed*Time.fixedDeltaTime);
        movement = Vector2.zero;
    }
}
