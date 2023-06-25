using UnityEngine;
public class car_move : MonoBehaviour
{
    [SerializeField] private float acceleration;
    [SerializeField] private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.velocity = new Vector3(0, rb.velocity.y, acceleration);
        //transform.Translate(Vector3.forward * acceleration * Time.deltaTime);
    }
}
