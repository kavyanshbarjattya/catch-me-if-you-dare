using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class car_spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] car;
    [SerializeField] private float destroySpeed;
    [SerializeField] private int xPos;
    [SerializeField] private Canvas normalcar_screen;
    [SerializeField] private Canvas powercar_screen;
    [SerializeField] private TextMeshProUGUI normal_car_score;
    [SerializeField] private TextMeshProUGUI power_car_score;

    private int normal_scoreHolder = 0;
    private int power_scoreHolder = 0;
    void Start()
    {
        StartCoroutine(CarWaiter());
        normalcar_screen.enabled = false;
        powercar_screen.enabled = false;
    }
    private void Update()
    {
        if(Application.isEditor && Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // This is for normal car
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Normal Car")
                {
                    normal_scoreHolder+= 10;
                    normal_car_score.text = "Normal Car : " + normal_scoreHolder;
                    Destroy(hit.transform.gameObject);
                    normalcar_screen.enabled = true;
                }
            }

            // This is for power car
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Power Car")
                {
                    power_scoreHolder+= 20;
                    power_car_score.text = "Power Car : " + power_scoreHolder;

                    Destroy(hit.transform.gameObject);
                    powercar_screen.enabled = true;
                }
            }

            // This is for fast car
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
            xPos = Random.Range(-30, 31);
            GameObject carclone = Instantiate(car[Random.Range(0,2)], new Vector3(xPos ,transform.position.y,transform.position.z), Quaternion.identity);
            yield return new WaitForSeconds(2f);
            Destroy(carclone , destroySpeed);
        }
    }

}
