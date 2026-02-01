using System.Collections;
using TMPro;
using UnityEngine;

public class PauseandContinue : MonoBehaviour
{
    public GameObject GameScreen;
    public GameObject PauseScreen;
    public float waittime;
    public TextMeshProUGUI waittimetext;
    public GameObject waittimeobject;
    public void PauseGame() // stop game
    {
        GameScreen.SetActive(false);
        PauseScreen.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Game stopped.");
    }

    public void ContinueGame() // continue game
    {
        StartCoroutine(Timer());
    }
    public IEnumerator Timer()
    {
        PauseScreen.SetActive(false);
        GameScreen.SetActive(true);

        float currentTimer = waittime;

        waittimetext.text = currentTimer.ToString();

        waittimeobject.SetActive(true);
        while (currentTimer > 0)
        {
            waittimetext.text = currentTimer.ToString("F0"); // "F0" removes decimals
            yield return new WaitForSecondsRealtime(1f);
            currentTimer--;
        }
        waittimeobject.SetActive(false);

        Time.timeScale = 1f;
        Debug.Log("Game continues.");
    }
}