using UnityEngine;

public class ObjectDeactivator : MonoBehaviour
{
    private Transform playerTransform;
    public float distanceToDisable = 5f; // threshold for disable

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