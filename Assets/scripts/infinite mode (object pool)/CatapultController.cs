using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CatapultController : MonoBehaviour
{
   
    public projectile rockData;
    public Button button;
    public Rigidbody2D rgbdy;
    public GameObject enemy;
    public RockPool rockpoolScript;
   

    private void OnEnable()
    {
        instantiateRock();
    }
    private void FixedUpdate()
    {
       
        
           if(rockpoolScript.isInstantiated!=true)
            if (rockpoolScript.isReleased == true)
            {
                instantiateRock();
           }
        

    }
    
    private void instantiateRock()
    {
        rockpoolScript.isInstantiated = true;
        var shot = rockpoolScript.get();
        SpringJoint2D sprng = shot.gameObject.GetComponent<SpringJoint2D>();
        sprng.connectedBody = rgbdy;
        rockData.enemies = enemy;
        
        shot.gameObject.transform.position = rgbdy.gameObject.transform.position;
        shot.gameObject.SetActive(true);
    }

}
