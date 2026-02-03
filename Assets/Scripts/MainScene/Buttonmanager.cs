using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttonmanager : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
