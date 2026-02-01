using UnityEngine;

public class ObstacleDeactivator : MonoBehaviour
{
    private Transform playerTransform;
    public float distanceToDisable = 15f; // threshold for disable

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (transform.position.z < playerTransform.position.z - distanceToDisable)
        {
            gameObject.SetActive(false); // Dont delete, just set active false!
        }
    }
}