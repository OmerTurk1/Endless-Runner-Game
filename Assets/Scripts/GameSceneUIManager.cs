using TMPro;
using UnityEngine;

public class GameSceneUIManager : MonoBehaviour
{
    public GameObject player;
    public Player player_script;
    public int distance;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI coinText;
    private void Update()
    {
        distance = (int)player.transform.position.z;
        distanceText.text = distance.ToString()+" m";
        coinText.text = player_script.money.ToString();
    }
}
