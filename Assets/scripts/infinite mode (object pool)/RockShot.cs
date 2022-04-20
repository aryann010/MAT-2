using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockShot : MonoBehaviour
{
    private float lifeTime, maxLifeTime=8f;
    private void OnEnable()
    {
        lifeTime = 0f;
    }

    private void Update()
    {
        lifeTime += Time.deltaTime;
        if (lifeTime > maxLifeTime)
        {
            GetComponent<SpringJoint2D>().enabled = true;
            RockPool.Instance.returnToPool(this);
        }
    }
}
