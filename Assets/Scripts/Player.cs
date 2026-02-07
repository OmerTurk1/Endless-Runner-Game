using Unity.Mathematics;
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Speed Settings")]
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
    private bool isDeath = false;

    // Related to Camera
    private Camera mainCamera;
    public float fov_increase;

    // Related to Money
    public int money = 0;

    [Header("Magnet Settings")]
    // Related to Magnet
    public float magnetRadius;
    public float magnetStrength;
    private bool is_magnet_active = false;
    private float magnet_timer = 0f;
    public float magnetDuration;
    public GameObject magnetImageObject;
    public Image magnetImage;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        touchScript = FindFirstObjectByType<TouchScript>();
        dieManager = FindFirstObjectByType<DieManager>();
        mainCamera = Camera.main;
        forward_speed = initial_forward_speed;
        magnet_timer = magnetDuration;
        time_checker();
    }
    void FixedUpdate()
    {
        inputDelta = isDeath ? Vector2.zero : touchScript.delta * sensitivity;
        // inputDelta = touchScript.delta * sensitivity;
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
    void Update()
    {
        if (is_magnet_active)
        {
            magnetImageObject.SetActive(true);
            MagnetEffect();

            // Süre yönetimi
            magnet_timer -= Time.deltaTime;
            magnetImage.fillAmount = magnet_timer / magnetDuration;
            if (magnet_timer <= 0) 
            {
                is_magnet_active = false;
                magnet_timer = magnetDuration;
            }
        }
        else
        {
            magnetImageObject.SetActive(false);
        }
    }
    void MagnetEffect()
    {
        // Oyuncunun etrafýndaki tüm collider'larý bul
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, magnetRadius);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Coin"))
            {
                // Parayý oyuncuya doðru hareket ettir
                hitCollider.transform.position = Vector3.MoveTowards(
                    hitCollider.transform.position,
                    transform.position,
                    magnetStrength * Time.deltaTime
                );
            }
        }
    }
    void StartMagnet()
    {
        is_magnet_active = true;
        magnet_timer = magnetDuration; // Her yeni mýknatýs alýþta süreyi tazeler
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Obstacle") || collision.transform.parent.CompareTag("Obstacle")) //because of multiple child colliders
        {
            string explanation = "You hit an obstacle.";
            isDeath = true;
            dieManager.gameOver(explanation);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Coin"))
        {
            money++;
        }
        else if (other.CompareTag("Magnet"))
        {
            StartMagnet();
        }
    }
}