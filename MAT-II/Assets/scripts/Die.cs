using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Die : MonoBehaviour
{
    public GameObject enemy;
    public GameObject particle;
    
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag=="ground")
        {
          
            Destroy();
        }
    }
 
    
        
        public void Destroy()
    {

       
        Destroy(enemy);
        Instantiate(particle, transform.position, Quaternion.identity);
       



    }
   

}
