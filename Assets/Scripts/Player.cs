using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    private float forward_speed;
    private float max_forward_speed;
    private float initial_forward_speed;
    private Rigidbody rb;

    private TouchScript touchScript;
    private Vector2 inputDelta;
    private float sensitivity = 20f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        touchScript = FindFirstObjectByType<TouchScript>();
        initial_forward_speed = 8f;
        max_forward_speed = 40f;
        forward_speed = initial_forward_speed;
    }

    void FixedUpdate()
    {
        forward_speed = math.min(forward_speed, max_forward_speed);
        Vector2 direction = touchScript.delta;
        inputDelta = touchScript.delta * sensitivity;

        //rb forward_speed kadar z ekseninde ilerlesin
        rb.linearVelocity = new Vector3(inputDelta.x, inputDelta.y, forward_speed);
    }
}
