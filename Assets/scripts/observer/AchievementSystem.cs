using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AchievementSystem : MonoBehaviour
{
    private Text killStreakText;
    private int killNumber;
   public CatapultController catapultController;

    
    private void Awake()
    {
        killStreakText = GetComponentInChildren<Text>();
      
        catapultController.OnPlayerKillingStreak += playerKillingStreak;
    }

    private void playerKillingStreak(int killingNumbers)

    {
         killNumber = killingNumbers;
    }

    private void Update()
    {
            killStreakText.text = "killing streak:" + killNumber.ToString();
        
    }
}
