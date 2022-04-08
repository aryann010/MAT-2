using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyController : MonoBehaviour
{
    private Animator animator;
    bool moveRight = true;
    float moveSpeed = 2f;
    public GameObject particle;


    private void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)

    {
        if (collision.gameObject.tag=="normal")
        {
            Destroy();

        }

    }

    private void Update()
    {




        if (transform.position.x < 0f)
        {
            moveRight = true;
            transform.localScale = new Vector2(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }

        if (transform.position.x > 9f)
        {
            moveRight = false;
            transform.localScale = new Vector2( Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }

        if (moveRight)

            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);

        else

            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
    }
    public void Destroy()
    {


        // Destroy(this.gameObject);
       // Instantiate(particle, transform.position, Quaternion.identity);
        StartCoroutine(waitFor3());
      





    }
    IEnumerator waitFor3()
    {
        yield return new WaitForSeconds(2f);
        enemyPool.Instance.isEnemyDead = true;
        enemyPool.Instance.returnToPool(this);
       
    }
  
}