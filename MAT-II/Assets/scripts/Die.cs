using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public GameObject enemy;
    public GameObject particle;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag=="ground")
        {
            
            Destroy();
        }
    }
    private void Destroy()
    {
        Destroy(enemy);
        Instantiate(particle, transform.position, Quaternion.identity);
    }

}
