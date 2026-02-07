using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoundControl : MonoBehaviour
{
    public Transform playerTransform;
    public MapCreator mapCreator;
    public TextMeshProUGUI stayInsideText;
    public GameObject damageScreen;
    public Material damageScreenMaterial;

    public float horizontalAllowDistance;
    public float verticalAllowDistance;
    public float allowTime; // total allowed time outside
    private float currentTime;    // remained time

    private float bound_left, bound_right, bound_top, bound_bottom;

    public DieManager dieManager;

    void Start()
    {
        currentTime = allowTime;

        // take bounds
        bound_left = mapCreator.bound_left - horizontalAllowDistance;
        bound_right = mapCreator.bound_right + horizontalAllowDistance;
        bound_bottom = mapCreator.bound_bottom - verticalAllowDistance;
        bound_top = mapCreator.bound_top + verticalAllowDistance;
    }

    void Update()
    {
        // Bound Control
        bool isOutside = playerTransform.position.x < bound_left ||
                       playerTransform.position.x > bound_right ||
                       playerTransform.position.y < bound_bottom ||
                       playerTransform.position.y > bound_top;

        if (isOutside)
        {
            damageScreen.SetActive(true);

            // decrease time
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                Die();
            }
        }
        else
        {
            if(currentTime == allowTime)
            {
                damageScreen.SetActive(false);
                damageScreenMaterial.SetFloat("_Radius", 1f);
            }

            if (currentTime < allowTime)
            {
                currentTime += Time.deltaTime;
                currentTime = Mathf.Clamp(currentTime, 0, allowTime);
            }
        }

        damageScreenMaterial.SetFloat("_Radius", currentTime / allowTime);
    }

    void Die()
    {
        string explanation = "You stayed on restricted are for too long";
        dieManager.gameOver(explanation);
    }
}