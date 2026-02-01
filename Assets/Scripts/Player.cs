using Unity.Mathematics;
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    // Related to Speed
    private float forward_speed;
    private float max_forward_speed;
    private float initial_forward_speed;
    private float forward_speed_increase;
    private Rigidbody rb;

    // Related to Touch
    private TouchScript touchScript;
    private Vector2 inputDelta;
    private float sensitivity = 50f; // if you want to drag character more, increase it

    private float time_per_speedup; // increase the speed once this much time is spent
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        touchScript = FindFirstObjectByType<TouchScript>();
        initial_forward_speed = 10f;
        max_forward_speed = 50f;
        forward_speed_increase = 4f;
        forward_speed = initial_forward_speed;
        time_per_speedup = 10f;
        time_checker();
    }
    void FixedUpdate()
    {
        forward_speed = math.min(forward_speed, max_forward_speed);
        inputDelta = touchScript.delta * sensitivity;
        rb.linearVelocity = new Vector3(inputDelta.x, inputDelta.y, forward_speed);
    }
    public void time_checker()
    {
        StartCoroutine(TimerRoutine());
    }
    IEnumerator TimerRoutine()
    {
        while (forward_speed<max_forward_speed)
        {
            yield return new WaitForSeconds(time_per_speedup); // wait for some time
            forward_speed += forward_speed_increase;

            Debug.Log("SPEED INCREASE: new speed is: "+forward_speed);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Obstacle") || collision.transform.parent.CompareTag("Obstacle")) //because of multiple child colliders
        {
            Debug.Log("You died!");
        }
    }
}
