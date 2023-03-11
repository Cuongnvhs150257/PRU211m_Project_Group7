using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickMove : MonoBehaviour
{
    public Joystick joyStick;
    public int velociad;
    public Rigidbody2D rb;
    public bool ConFisicas;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void FixedUpdate()
    {
        Vector2 direction = Vector2.up * joyStick.Vertical + Vector2.right * joyStick.Horizontal;
        if (ConFisicas)
        {
            rb.AddForce(direction * velociad * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
        else
        {
            gameObject.transform.Translate(direction * velociad * Time.deltaTime);
        }
    }

   
}
