using UnityEngine;

public class PermanentInfo : MonoBehaviour
{
    private static int coin;
    public static int Coin
    {
        get
        {
            return coin;
        }
        set
        {
            coin = value;
            PlayerPrefs.SetInt("TotalCoin", coin);
        }
    }
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void InitializeAtStart()
    {
        // PlayerPrefs'ten veriyi sadece oyun ilk açýldýðýnda çekiyoruz
        Coin = PlayerPrefs.GetInt("TotalCoin", 0); ;
        Debug.Log("Oyun ilk kez açýldý. Hafýzadaki coin: " + Coin);
    }
    public void saveGame()
    {
        //playerprefs e kayýt
    }
}
