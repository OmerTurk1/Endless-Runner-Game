using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI highestDistanceText;
    public TextMeshProUGUI highestCoinText;
    public TextMeshProUGUI highestTotalText;
    public TMP_Dropdown gameModeSelector;
    public GameObject scoresScreen;
    public GameObject marketScreen;
    private void Start()
    {
        // dropdow settings
        int index = gameModeSelector.options.FindIndex(
            option => option.text == PermanentInfo.GameMode
        );
        if (index < 0) index = 0;
        gameModeSelector.SetValueWithoutNotify(index);
    }

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
    public void openMarketScreen()
    {
        marketScreen.SetActive(true);
    }
    public void closeMarketScreen()
    {
        marketScreen.SetActive(false);
    }
    public void OnDropdownValueChanged()
    {
        PermanentInfo.GameMode = gameModeSelector.options[gameModeSelector.value].text;
    }
    private void Update()
    {
        coinText.text = PermanentInfo.Coin.ToString();
    }
}
