using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieManager : MonoBehaviour
{
    [Header("General Settings")]
    public GameObject player;
    public GameObject gameOverScreen;
    public GameObject gameScreen;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI totalGainText;
    public TextMeshProUGUI explanationText;
    public Material youDieScreenMaterial;
    public float darkingTime;
    public float distancePerCoin;

    [Header("Highest Score Settings")]
    public GameObject isHighestScoreDistanceText;
    public GameObject isHighestScoreCoinText;
    public GameObject isHighestScoreTotalText;

    private bool isDead = false;
    public void gameOver(string explanation)
    {
        if (isDead)
            return;
        Debug.Log("You died");
        isDead = true;
        player.GetComponent<Player>().forward_speed = 0f;

        int distance = (int)player.transform.position.z;
        distanceText.text = distance.ToString() + " m";
        if(distance > PermanentInfo.HighestScoreDistance)
        {
            isHighestScoreDistanceText.SetActive(true);
            PermanentInfo.HighestScoreDistance = distance;
        }

        int coin_collected = player.GetComponent<Player>().money;
        coinText.text = "x" + coin_collected.ToString();
        if (coin_collected > PermanentInfo.HighestScoreCoin)
        {
            isHighestScoreCoinText.SetActive(true);
            PermanentInfo.HighestScoreCoin = coin_collected;
        }

        int total_gain = coin_collected + (int)(distance / distancePerCoin);
        totalGainText.text = "x"+total_gain.ToString();
        if (total_gain > PermanentInfo.HighestScoreTotal)
        {
            isHighestScoreTotalText.SetActive(true);
            PermanentInfo.HighestScoreTotal = total_gain;
        }
        PermanentInfo.Coin += total_gain;

        explanationText.text = explanation;

        gameScreen.SetActive(false);
        gameOverScreen.SetActive(true);
        StartCoroutine(darkerTimer());
    }
    private IEnumerator darkerTimer()
    {
        float elapsedTime = 0;
        float startRadius = 1.0f;
        float endRadius = 0.0f;

        float startFov = 80f;
        float endFov = 60f;

        youDieScreenMaterial.SetFloat("_Radius", startRadius);

        while (elapsedTime < darkingTime)
        {
            elapsedTime += Time.deltaTime;

            float newRadius = Mathf.Lerp(startRadius, endRadius, elapsedTime / darkingTime);
            youDieScreenMaterial.SetFloat("_Radius", newRadius);

            float newFov = Mathf.Lerp(startFov, endFov, elapsedTime / darkingTime);
            Camera.main.fieldOfView = newFov;

            yield return null;
        }

        youDieScreenMaterial.SetFloat("_Radius", endRadius);
        Camera.main.fieldOfView = endFov;
    }
    public void restartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void mainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }
}
