using UnityEngine;
using System.Collections;

public class AmbianceManager : MonoBehaviour
{
    [Header("Zaman Ayarlarý")]
    public float waitingTime;
    public float transitionTime;

    [Header("Renk Listesi")]
    public Color[] selectedColor;

    private int currentIndex;
    private Camera targetCam;

    void Start()
    {
        currentIndex = 0;
        targetCam = Camera.main;

        if (selectedColor.Length > 0)
        {
            RenderSettings.fog = true;
            changeColor(selectedColor[currentIndex]);
            targetCam.clearFlags = CameraClearFlags.SolidColor;

            StartCoroutine(AmbianceLoop());
        }
        else
        {
            Debug.LogError("Atmosphere color amount cannot be zero!!!");
        }
    }

    IEnumerator AmbianceLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitingTime);

            currentIndex = (currentIndex + 1) % selectedColor.Length;

            float t = 0;
            Color startColor = RenderSettings.fogColor;
            Color targetColor = selectedColor[currentIndex];

            while (t < 1f)
            {
                t += Time.deltaTime * (1f / transitionTime);

                Color newColor = Color.Lerp(startColor, targetColor, t);

                changeColor(newColor);

                yield return null;
            }
        }
    }
    private void changeColor(Color newColor)
    {
        RenderSettings.fogColor = newColor;
        targetCam.backgroundColor = newColor;
    }
}