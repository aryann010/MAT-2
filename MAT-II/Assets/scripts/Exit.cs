using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exit : MonoBehaviour
{
    public Button exitButton;

    private void Awake()
    {
        exitButton.onClick.AddListener(Exit);
    }
    private void Exit()
    {

        SceneManager.LoadScene(0);
    }
}