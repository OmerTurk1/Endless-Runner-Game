using UnityEngine;

public class PermanentInfo : MonoBehaviour
{
    private static int coin;
    private static int highest_score_distance;
    private static int highest_score_coin;
    private static int highest_score_total;
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
    public static int HighestScoreDistance
    {
        get
        {
            return highest_score_distance;
        }
        set
        {
            highest_score_distance = value;
            PlayerPrefs.SetInt("HighestScoreDistance", highest_score_distance);
        }
    }
    public static int HighestScoreCoin
    {
        get
        {
            return highest_score_coin;
        }
        set
        {
            highest_score_coin = value;
            PlayerPrefs.SetInt("HighestScoreCoin", highest_score_coin);
        }
    }
    public static int HighestScoreTotal
    {
        get
        {
            return highest_score_total;
        }
        set
        {
            highest_score_total = value;
            PlayerPrefs.SetInt("HighestScoreTotal", highest_score_total);
        }
    }
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void InitializeAtStart()
    {
        // When game starts initially
        Coin = PlayerPrefs.GetInt("TotalCoin", 0);
        HighestScoreDistance = PlayerPrefs.GetInt("HighestScoreDistance", 0);
        HighestScoreCoin = PlayerPrefs.GetInt("HighestScoreCoin", 0);
        HighestScoreTotal = PlayerPrefs.GetInt("HighestScoreTotal", 0);
    }
}
