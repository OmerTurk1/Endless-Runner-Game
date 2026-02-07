using UnityEngine;

public class StarterScript : MonoBehaviour
{
    [Header("Initially Closed")]
    public GameObject[] Falses;
    [Header("Initially Opened")]
    public GameObject[] Trues;
    private void Start()
    {
        Time.timeScale = 1;
        foreach(GameObject False in Falses)
        {
            False.SetActive(false);
        }
        foreach (GameObject True in Trues)
        {
            True.SetActive(true);
        }
    }
}
