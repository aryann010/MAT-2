using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemySpawner : MonoBehaviour
{
    public enemyController enemyController;



    private void OnEnable()
    {
      
        instantiateBird();
    }
    private void FixedUpdate()
    {


        if (enemyPool.Instance.isEnemyDead==true)
            {
                instantiateBird();
            }


    }

    private void instantiateBird()
    {
        enemyPool.Instance.isEnemyDead = false;
        var shot = enemyPool.Instance.get();
        shot.gameObject.transform.position = new Vector3(8f, 2.8f, 1.5210f);
        shot.gameObject.transform.rotation =  Quaternion.Euler(0,0,0);
        shot.gameObject.SetActive(true);
        
    }


}
