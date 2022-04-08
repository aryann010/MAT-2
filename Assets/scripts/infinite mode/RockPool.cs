using System;
using System.Collections.Generic;
using UnityEngine;



public class RockPool : MonoBehaviour
{
    [SerializeField] private RockShot rockPrefab;
    public bool isReleased, isInstantiated;

    private Queue<RockShot> rockShot = new Queue<RockShot>();
    public static RockPool Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }
    public RockShot get()
    {
       
        if (rockShot.Count == 0)
        {
           
           addRock(1);
       }
       return rockShot.Dequeue();
    }
    public void addRock(int count)
    {
       for (int i = 0; i < count; i++)
        {
            RockShot RockPrefab = Instantiate(rockPrefab);
            RockPrefab.gameObject.SetActive(false);
            rockShot.Enqueue(RockPrefab);
        
        

       }
    }
 
    public void returnToPool(RockShot rockPrefab)
    {
        rockPrefab.gameObject.SetActive(false);
     
         rockShot.Enqueue(rockPrefab);
    }

}
