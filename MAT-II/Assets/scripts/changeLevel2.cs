using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeLevel2 : MonoBehaviour
{
    void Update()
    {
        bool change = Input.GetKey(KeyCode.Space);
        changeLevel(change);
    }
    private void changeLevel(bool c)
    {
        if (c)
            SceneManager.LoadScene(1);
    }
}
