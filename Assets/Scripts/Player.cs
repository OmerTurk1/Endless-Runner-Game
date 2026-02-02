using Unity.Mathematics;
using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour
{
    // Related to Speed
    public float forward_speed;
    public float max_forward_speed;
    public float initial_forward_speed;
    public float forward_speed_increase;
    public float forward_speed_increase_time;
    private Rigidbody rb;
    public float time_per_speedup; // increase the speed once this much time is spent

    // Related to Touch
    private TouchScript touchScript;
    private Vector2 inputDelta;
    private float sensitivity = 50f; // if you want to drag character more, increase it

    // Related to death
    private DieManager dieManager;

    // Related to Camera
    private Camera mainCamera;
    public float fov_increase;

    // Related to Money
    public int money;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        touchScript = FindFirstObjectByType<TouchScript>();
        dieManager = FindFirstObjectByType<DieManager>();
        mainCamera = Camera.main;
        forward_speed = initial_forward_speed;
        money = 0;

        time_checker();
    }
    void FixedUpdate()
    {
        inputDelta = touchScript.delta * sensitivity;
        rb.linearVelocity = new Vector3(inputDelta.x, inputDelta.y, forward_speed);
    }
    public void time_checker()
    {
        StartCoroutine(TimerRoutine());
    }
    IEnumerator TimerRoutine()
    {
        while (forward_speed < max_forward_speed)
        {
            yield return new WaitForSeconds(time_per_speedup);
            Debug.Log("Speed increasing animation started");

            float startSpeed = forward_speed;
            float startFOV = mainCamera.fieldOfView;

            float targetSpeed = forward_speed + forward_speed_increase;
            float targetFOV = mainCamera.fieldOfView + fov_increase;
            float elapsedTime = 0;

            while (elapsedTime < forward_speed_increase_time)
            {
                float t = elapsedTime / forward_speed_increase_time;

                forward_speed = Mathf.Lerp(startSpeed, targetSpeed, t);
                mainCamera.fieldOfView = Mathf.Lerp(startFOV, targetFOV, t);

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            forward_speed = Mathf.Min(targetSpeed, max_forward_speed);
            mainCamera.fieldOfView = targetFOV;

            Debug.Log("Speed increased to: " + forward_speed);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Obstacle") || collision.transform.parent.CompareTag("Obstacle")) //because of multiple child colliders
        {
            Debug.Log("You died!");
            dieManager.gameOver();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Coin"))
        {
            money++;
        }
    }
}
