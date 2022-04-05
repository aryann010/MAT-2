using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class projectile : MonoBehaviour
{
    [SerializeField] private GameObject enemies;
    [SerializeField] private int nextSceneIndex;
    
    private int i;
    private Rigidbody2D rb;
    private SpringJoint2D springJoint;
    private bool isPressed;
  
  

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        springJoint = GetComponent<SpringJoint2D>();
        i = nextSceneIndex;
    }

    void Update()
    {
       
        if (isPressed)
        {
            rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (enemies == null)
        {
            StartCoroutine(Wait());
            
        }
     
    }

   
    private void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }
    private void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;
        StartCoroutine(Release());
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpringJoint2D>().enabled = false;
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(i);
    }
}




