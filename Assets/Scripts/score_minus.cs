using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score_minus : MonoBehaviour
{
    public car_spawner car;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Fast Car"))
        {
            car.fast_scoreHolder -= 20;
        }
    }
}
