using UnityEngine;
using System.Collections;

public class AmbianceManager : MonoBehaviour
{
    [Header("Zaman Ayarlarý")]
    public float degisimSuresi;
    public float gecisHizi;

    [Header("Renk Listesi")]
    public Color[] atmosferRenkleri;

    private int currentIndex;
    private Camera hedefKamera;

    void Start()
    {
        currentIndex = Random.Range(0,atmosferRenkleri.Length);
        hedefKamera = Camera.main;

        if (atmosferRenkleri.Length > 0)
        {
            RenderSettings.fog = true;
            RenderSettings.fogColor = atmosferRenkleri[currentIndex];
            hedefKamera.backgroundColor = atmosferRenkleri[currentIndex];
            hedefKamera.clearFlags = CameraClearFlags.SolidColor;

            StartCoroutine(AtmosferDongusu());
        }
    }

    IEnumerator AtmosferDongusu()
    {
        while (true)
        {
            yield return new WaitForSeconds(degisimSuresi);

            int index_increase = Random.Range(1,atmosferRenkleri.Length - 1);
            currentIndex = (currentIndex + index_increase) % atmosferRenkleri.Length;

            float t = 0;
            Color baslangicRengi = RenderSettings.fogColor;
            Color hedefRenk = atmosferRenkleri[currentIndex];

            while (t < 1f)
            {
                t += Time.deltaTime * (1f / gecisHizi);

                Color yeniRenk = Color.Lerp(baslangicRengi, hedefRenk, t);

                RenderSettings.fogColor = yeniRenk;
                hedefKamera.backgroundColor = yeniRenk;

                yield return null;
            }
        }
    }
}