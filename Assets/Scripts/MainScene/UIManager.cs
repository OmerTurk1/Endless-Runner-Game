using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public void startGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void quitGame()
    {
        Application.Quit();
    }
    private void Update()
    {
        coinText.text = PermanentInfo.coin.ToString();
    }
}
