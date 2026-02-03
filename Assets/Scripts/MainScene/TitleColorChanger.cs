using System.Collections; // Needed for IEnumerator
using TMPro;
using UnityEngine;

public class TitleColorChanger : MonoBehaviour
{
    public TextMeshProUGUI title_1;
    public float changeColorTime;
    public float waitTime;

    private void Start()
    {
        StartCoroutine(ChangeColorRoutine());
    }

    private IEnumerator ChangeColorRoutine()
    {
        while (true)
        {
            Color startColor = title_1.color;
            Color endColor = Random.ColorHSV(0f, 1f, 0.8f, 1f, 0.8f, 1f);

            float elapsed = 0f;

            while (elapsed < changeColorTime)
            {
                elapsed += Time.deltaTime;
                float normalizedTime = elapsed / changeColorTime;

                title_1.color = Color.Lerp(startColor, endColor, normalizedTime);

                yield return null;
            }

            title_1.color = endColor;

            yield return new WaitForSeconds(waitTime);
        }
    }
}