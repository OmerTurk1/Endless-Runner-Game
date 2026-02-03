using UnityEngine;

public class PermanentInfo : MonoBehaviour
{
    public static int coin;
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void InitializeAtStart()
    {
        // PlayerPrefs'ten veriyi sadece oyun ilk açýldýðýnda çekiyoruz
        coin = 0;
        Debug.Log("Oyun ilk kez açýldý. Hafýzadaki coin: " + coin);
    }
    public void saveGame()
    {
        //playerprefs e kayýt
    }
}
