using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class car_spawner : MonoBehaviour
{
    [Header("---------------SerializedFields---------------")]
    [SerializeField] private GameObject car;
    [SerializeField] private float destroySpeed;
    [SerializeField] private Transform normalcar_Trans;
    [SerializeField] private int spawntimer;

    private GameObject carclone;

    void Start()
    {
        StartCoroutine(CarWaiter());
    }
    private void Update()
    {
        
        if (Application.isEditor && Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // This is for normal car
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Normal Car")
                {
                    Destroy(hit.transform.gameObject);
                }
            }

        }
        else if (Input.touchCount > 0)
        {
            var ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit))
            {
                if (hit.collider.tag == "Car")
                {
                    Destroy(hit.transform.gameObject);
                }
            }
        }
 
    }
    IEnumerator CarWaiter() // this will apply waiting time to car spawner
    {
        while (car)
        {
            carclone = Instantiate(car,normalcar_Trans.position , Quaternion.identity);
            spawntimer = Random.Range(1, 3);
            yield return new WaitForSeconds(spawntimer) ;
            Destroy(carclone , destroySpeed);
        }
    }

}
