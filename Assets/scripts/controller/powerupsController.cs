using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class powerupsController : MonoBehaviour
{
    public GameObject add10Sec, other;
    public GameObject normal, fireball,extra;
    public bool isOnGround=false,isAgain=true;
    public countdownTimer countdownTimer;

  
    private void Awake()
    {
        Button b1 = add10Sec.gameObject.GetComponent<Button>();
        Button b2 = other.gameObject.GetComponent<Button>();
        b1.onClick.AddListener(addTime);
        b2.onClick.AddListener(Other);
    }
    private void Update()
    {
        if (isOnGround && countdownTimer.currentTime < 8f&& isAgain) { other.gameObject.SetActive(true); add10Sec.gameObject.SetActive(false); }
        if (countdownTimer.currentTime <3.5f&& isAgain) { add10Sec.gameObject.SetActive(true); }
    }
  
    private void addTime()
    {
        add10Sec.gameObject.SetActive(false);
        countdownTimer.currentTime += 10f;
        isAgain = false;
       
    }
    private void Other()
    {
        other.gameObject.SetActive(false);
        countdownTimer.currentTime += 3f;
        isAgain = false;
        extra.gameObject.SetActive(true);
        
    }
}
