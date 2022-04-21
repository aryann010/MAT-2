using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class enemyController : MonoBehaviour
{
    private Animator animator;
   public bool moveRight = true;
   public float moveSpeed = 2f;
    public GameObject particle;
    public Rigidbody2D rgbd;
    public CatapultController catapultController;
    

    private void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        rgbd = gameObject.GetComponent<Rigidbody2D>();
        catapultController = FindObjectOfType<CatapultController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)

    {
        if (collision.gameObject.tag=="fireball"&& SceneManager.GetActiveScene().buildIndex==5)
        {
            Destroy();
          
            catapultController.enemyHit(1);
          //  catapultController.missCount = 0;


        }
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ground")
        {

            Destroy();
        }
    }

    private void Update()
    {
    }
    public void Destroy()
    {

        if (SceneManager.GetActiveScene().buildIndex != 5)
        {
            Destroy(this.gameObject);
            Instantiate(particle, transform.position, Quaternion.identity);
          
           StartCoroutine(Wait());
        }

            StartCoroutine(waitFor3());

    }
     IEnumerator Wait()
     {
    

        yield return new WaitForSeconds(1f);

    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
          
        
    }
    IEnumerator waitFor3()
    {
        yield return new WaitForSeconds(2f);
        enemyPool.Instance.isEnemyDead = true;
        enemyPool.Instance.returnToPool(this);
       
    }
   
  
}