using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieManager : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOverScreen;
    public GameObject gameScreen;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI coinText;
    public void gameOver()
    {
        int distance = ((int)player.transform.position.z);
        distanceText.text = distance.ToString() + " m";
        coinText.text = "x" + player.GetComponent<Player>().money.ToString();
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
