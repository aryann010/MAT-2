using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class countdownTimer : MonoBehaviour
{
   public float currentTime = 0f;
    float startTime = 15f;

    public Text CountDownText;
    void  Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= 1 * Time.deltaTime;
           
            CountDownText.text = currentTime.ToString("0");
        }

        if (currentTime >= 3.5f) { CountDownText.color = Color.white; }
        if (currentTime < 3.5f) { CountDownText.color = Color.red; }
        if (currentTime <= 0) { SceneManager.LoadScene(0);   }

    }
}