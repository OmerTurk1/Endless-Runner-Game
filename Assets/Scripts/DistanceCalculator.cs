using TMPro;
using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{
    public Transform player;
    public int distance;
    public TextMeshProUGUI distanceText;
    private void Update()
    {
        distance = (int)player.position.z;
        distanceText.text = distance.ToString()+" m";
    }
}
