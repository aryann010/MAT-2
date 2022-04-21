using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStateBase : StateMachineBehaviour
{
    private enemyController enemyController;
    public enemyController getEnemyController(Animator animator)
    {
        if (enemyController == null)
        {
            enemyController = animator.GetComponent<enemyController>();
        }
        return enemyController;
    }
 
}
