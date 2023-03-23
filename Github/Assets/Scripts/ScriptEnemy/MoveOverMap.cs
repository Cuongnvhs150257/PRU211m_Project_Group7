using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOverMap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EdgeCollider2D mapBoundaryCollider = GameObject.Find("ground2_white").GetComponent<EdgeCollider2D>();
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), mapBoundaryCollider);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
