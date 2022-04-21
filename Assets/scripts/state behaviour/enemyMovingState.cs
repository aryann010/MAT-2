using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyMovingState : enemyStateBase
{
   
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            getEnemyController(animator).rgbd.gravityScale = 0;
           



            if (getEnemyController(animator).transform.position.x < 0f)
            {
                getEnemyController(animator).moveRight = true;
                getEnemyController(animator).transform.localScale = new Vector2(-1f * Mathf.Abs(getEnemyController(animator).transform.localScale.x), getEnemyController(animator).transform.localScale.y);
            }

            if (getEnemyController(animator).transform.position.x > 9f)
            {
                getEnemyController(animator).moveRight = false;
                getEnemyController(animator).transform.localScale = new Vector2(Mathf.Abs(getEnemyController(animator).transform.localScale.x), getEnemyController(animator).transform.localScale.y);
            }

            if (getEnemyController(animator).moveRight)

                getEnemyController(animator).transform.position = new Vector2(getEnemyController(animator).transform.position.x + getEnemyController(animator).moveSpeed * Time.deltaTime, getEnemyController(animator).transform.position.y);

            else

                getEnemyController(animator).transform.position = new Vector2(getEnemyController(animator).transform.position.x - getEnemyController(animator).moveSpeed * Time.deltaTime, getEnemyController(animator).transform.position.y);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
