using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPool : MonoBehaviour
{
    [SerializeField] private enemyController birdPrefab;
    private Queue<enemyController> bird = new Queue<enemyController>();
    public static enemyPool Instance;
    public bool isEnemyDead;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }
    public enemyController get()
    {

        if (bird.Count == 0)
        {

            addBird(1);
        }
        return bird.Dequeue();
    }
    public void addBird(int count)
    {
        for (int i = 0; i < count; i++)
        {
            enemyController BirdPrefab = Instantiate(birdPrefab);
            BirdPrefab.gameObject.SetActive(false);
            bird.Enqueue(BirdPrefab);


        }
    }

    public void returnToPool(enemyController birdPrefab)
    {
        birdPrefab.gameObject.SetActive(false);
        bird.Enqueue(birdPrefab);
    }
}
