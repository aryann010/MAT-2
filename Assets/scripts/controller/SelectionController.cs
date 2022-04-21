using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SelectionController : MonoBehaviour
{
  
    public Button Normal, Fireball;
    public GameObject normalGO, fireballGO;
    public bool isShotTaken = false;

    private void Awake()
    {
        
       
        
        Normal.onClick.AddListener(normal);
        Fireball.onClick.AddListener(fireball);
    }
    private void normal()
    {
        if (isShotTaken == false)
        {
            normalGO.SetActive(true);
            fireballGO.SetActive(false);
        }
        
    }
    private void fireball()
    {
        if (isShotTaken == false)
        {
            normalGO.SetActive(false);
            fireballGO.SetActive(true);
        }
    }
    public void exit()
    {
        SceneManager.LoadScene(0);
    }
}
