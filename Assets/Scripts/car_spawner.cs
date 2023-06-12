using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_spawner : MonoBehaviour
{
    [SerializeField] private GameObject car;
    [SerializeField] private float destroySpeed;
    private float xPos;
    void Start()
    {
        StartCoroutine(CarWaiter());
        xPos = Random.Range(-30f, 32f);
    }
    IEnumerator CarWaiter() // this will apply waiting time to car spawner
    {
        while (car)
        {
            GameObject carclone = Instantiate(car, new Vector3(xPos ,transform.position.y,transform.position.z), Quaternion.identity);
            yield return new WaitForSeconds(2f);
            Destroy(carclone , destroySpeed);
        }
    }
}
