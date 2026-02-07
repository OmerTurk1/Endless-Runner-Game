using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public GameObject scoresScreen;
    public TextMeshProUGUI highestDistanceText;
    public TextMeshProUGUI highestCoinText;
    public TextMeshProUGUI highestTotalText;

    public void startGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void openScoresScreen()
    {
        highestDistanceText.text = PermanentInfo.HighestScoreDistance.ToString()+" m";
        highestCoinText.text = "x"+PermanentInfo.HighestScoreCoin.ToString();
        highestTotalText.text = "x"+PermanentInfo.HighestScoreTotal.ToString();
        scoresScreen.SetActive(true);
    }
    public void closeScoresScreen()
    {
        scoresScreen.SetActive(false);
    }
    private void Update()
    {
        coinText.text = PermanentInfo.Coin.ToString();
    }
}
