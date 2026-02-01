using UnityEngine;

public class ObstacleDeactivator : MonoBehaviour
{
    private Transform playerTransform;
    public float distanceToDisable = 15f; // Oyuncunun ne kadar gerisinde kalýnca kapansýn?

    void Start()
    {
        // Sahnedeki oyuncuyu bul (Etiketinin "Player" olduðunu varsayýyorum)
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Eðer engel oyuncunun belirlenen mesafe kadar arkasýnda kaldýysa
        if (transform.position.z < playerTransform.position.z - distanceToDisable)
        {
            gameObject.SetActive(false); // Silme, sadece pasif yap!
        }
    }
}