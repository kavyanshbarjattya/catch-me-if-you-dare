using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_move : MonoBehaviour
{
    [SerializeField] private float acceleration;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * acceleration * Time.deltaTime);
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Land"))
        {
            Debug.Log("Collision Exit");
        }
    }

}
