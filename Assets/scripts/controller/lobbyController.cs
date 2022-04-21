
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class lobbyController : MonoBehaviour
{
    public Button playButton;
    public GameObject instructions;
    public Button Play,infiniteMode;


    private void Awake()
    {
        playButton.onClick.AddListener(play);
        Play.onClick.AddListener(PLAY);
        infiniteMode.onClick.AddListener(InfiniteMode);
     
    }
    private void play()
    {

        instructions.gameObject.SetActive(true);
    }
    private void PLAY()
    {
        SceneManager.LoadScene(1);
    }
    private void InfiniteMode()
    {
        SceneManager.LoadScene(5);
    }
}
