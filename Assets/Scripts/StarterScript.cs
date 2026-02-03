using UnityEngine;

public class StarterScript : MonoBehaviour
{
    public GameObject touchScreen;
    public GameObject gameScreen;
    public GameObject pauseScreen;
    public GameObject gameOverScreen;
    public GameObject youSureScreen;
    public GameObject continueGameTimer;
    private void Start()
    {
        Time.timeScale = 1;
        touchScreen.SetActive(true);
        gameScreen.SetActive(true);
        pauseScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        youSureScreen.SetActive(false);
        continueGameTimer.SetActive(false);
    }
}
