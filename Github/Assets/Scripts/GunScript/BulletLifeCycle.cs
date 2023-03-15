using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLifeCycle : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            Destroy(gameObject);
            timer = 0;
        }
    }
}
