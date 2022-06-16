using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombscript : MonoBehaviour
{

    
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            Destroy(gameObject, 0.01f);
            
        }
        if (other.collider.tag == "Ground")
        {
            Destroy(gameObject, 0.01f);
        }
    }
}
