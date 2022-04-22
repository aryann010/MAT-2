using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class projectile : MonoBehaviour
{
  
    [SerializeField] private int nextSceneIndex;
    
    private int i;
    private Rigidbody2D rb;
    private SpringJoint2D springJoint;

    private bool isPressed;
    private Animator anim;
    public powerupsController puController;
   public SelectionController selectionController;
    private CatapultController catapultController;
    public delegate void PlayerKillSreakEvent(int killNumber);
    public event PlayerKillSreakEvent OnPlayerKillingStreak;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        springJoint = GetComponent<SpringJoint2D>();
        i = nextSceneIndex;
        anim = gameObject.GetComponent<Animator>();
        catapultController = FindObjectOfType<CatapultController>();
  
    }

    void Update()
    {
       
        if (isPressed)
        {
            rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
      
    }
  
    void OnCollisionEnter2D(Collision2D collision)
    {
       
       
       
        anim.SetBool("isCollide", true);
        // puController.isOnGround = true;

       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground"&&anim.GetBool("isCollide")==false)
        {
            // catapultController.missCount++;
            catapultController.reset();
            
          //  OnPlayerKillingStreak(0);

        }

    }

    private void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }
    private void OnMouseUp()
    {
      
        
      //  selectionController.isShotTaken = true;
        if (this.gameObject.tag == "fireball")           
        {
            anim.SetBool("isThrow", true);
        }

        isPressed = false;
        rb.isKinematic = false;
        StartCoroutine(Release());
        
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpringJoint2D>().enabled = false;
        yield return new WaitForSeconds(1f);
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            RockPool.Instance.isReleased = true;
            RockPool.Instance.isInstantiated = false;
        }
    }
  
   
}




