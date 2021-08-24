using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public Button exitButton;

    private void Awake()
    {
        exitButton.onClick.AddListener(exit);
    }
    private void exit()
    {

        SceneManager.LoadScene(0);
    }
}
