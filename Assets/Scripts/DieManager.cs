using UnityEngine;
using UnityEngine.SceneManagement;

public class DieManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject gameScreen;
    public void gameOver()
    {
        gameScreen.SetActive(false);
        gameOverScreen.SetActive(true);
    }
    public void restartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("MainScene");
    }
}
