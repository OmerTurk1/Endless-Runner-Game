using System.Collections;
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
    public TextMeshProUGUI explanationText;
    public Material youDieScreenMaterial;
    public float darkingTime;
    public void gameOver(string explanation)
    {
        // perform animation
        int distance = ((int)player.transform.position.z);
        distanceText.text = distance.ToString() + " m";
        coinText.text = "x" + player.GetComponent<Player>().money.ToString();
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
        SceneManager.LoadScene("MainScene");
    }
}
