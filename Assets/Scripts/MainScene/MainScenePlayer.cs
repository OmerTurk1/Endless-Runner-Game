using UnityEngine;

public class MainScenePlayer : MonoBehaviour
{
    public float forward_speed;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(0,0,forward_speed);
    }
}
