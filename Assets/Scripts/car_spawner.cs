using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class car_spawner : MonoBehaviour
{
    [Header("---------------SerializedFields---------------")]
    [SerializeField] private GameObject[] car;
    [SerializeField] private float destroySpeed;
    [SerializeField] private int xPos;
    [SerializeField] private GameObject fast_car;
    [SerializeField] private GameObject normal_car;

    [Header("---------------Public class---------------")]
    public int powercar_reseter; // this will reset the powercar health
    public int powercar_damage = 100;

    private int power_carhealth;
    private GameObject carclone;

    void Start()
    {
        StartCoroutine(CarWaiter());
        power_carhealth = powercar_reseter;
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

            // This is for fast car
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Fast Car")
                {
                    Destroy(hit.transform.gameObject);
                }
            }

            // This is for power car
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Power Car")
                {
                    // this is the power_car health :
                    power_carhealth -= powercar_damage;
                    if (power_carhealth == 0)
                    {
                        Destroy(hit.transform.gameObject);
                        power_carhealth = powercar_reseter;
                    }
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
        while (car[0])
        {
            xPos = Random.Range(-25, 25);
             carclone = Instantiate(car[Random.Range(0,3)], new Vector3(xPos ,transform.position.y,transform.position.z), Quaternion.identity);
            yield return new WaitForSeconds(2f);
            Destroy(carclone , destroySpeed);
        }
    }

}
