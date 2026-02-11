using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Transform target;
    private Vector3 offset;
    private float smoothTime;
    private Vector2 velocityXY;

    private void Start()
    {
        transform.SetParent(null);

        target = FindFirstObjectByType<Player>().transform;
        offset = new Vector3(0, 1, -4);
        transform.rotation = Quaternion.Euler(6f, 0f, 0f);
        smoothTime = 0.04f;
    }
    void FixedUpdate()
    {
        Vector3 currentPos = transform.position;

        Vector2 targetXY = new Vector2(
            target.position.x + offset.x,
            target.position.y + offset.y
        );

        Vector2 smoothXY = Vector2.SmoothDamp(
            new Vector2(currentPos.x, currentPos.y),
            targetXY,
            ref velocityXY,
            smoothTime
        );

        float fixedZ = target.position.z + offset.z;

        transform.position = new Vector3(
            smoothXY.x,
            smoothXY.y,
            fixedZ
        );
    }
}
