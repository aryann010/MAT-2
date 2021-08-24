
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class lobbyController : MonoBehaviour
{
    public Button playButton;
    public GameObject instructions;
    public Button Play;
    private void Awake()
    {
        playButton.onClick.AddListener(play);
        Play.onClick.AddListener(PLAY);
    }
    private void play()
    {

        instructions.gameObject.SetActive(true);
    }
    private void PLAY()
    {
        SceneManager.LoadScene(1);
    }
}
