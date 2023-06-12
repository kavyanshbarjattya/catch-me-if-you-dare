using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_spawner : MonoBehaviour
{
    [SerializeField] private GameObject car;
    [SerializeField] private float destroySpeed;
    [SerializeField] private float xPos;
    void Start()
    {
        StartCoroutine(CarWaiter());
    }
    private void Update()
    {
        if(Application.isEditor && Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Car")
                {
                    Debug.Log("Pressed");
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
            xPos = Random.Range(-30f, 31f);
            GameObject carclone = Instantiate(car, new Vector3(xPos ,transform.position.y,transform.position.z), Quaternion.identity);
            yield return new WaitForSeconds(2f);
            Destroy(carclone , destroySpeed);
        }
    }

}
