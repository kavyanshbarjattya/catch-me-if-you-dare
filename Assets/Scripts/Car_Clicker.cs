using UnityEngine;
public class Car_Clicker : MonoBehaviour
{ 
    [SerializeField] public int clicksRequiredToDestroy;
    [SerializeField] private int clicked;
    private void Start()
    {
        clicked = 0; 
    }
    private void Update()
    {
        if (Application.isEditor && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Car"))
                {
                    clicked++;
                    if (clicked >= clicksRequiredToDestroy)
                    {
                        Destroy(hit.transform.gameObject);
                    }
                }
            }
        }
        else if (Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Car"))
                {
                    clicked++;
                    if (clicked >= clicksRequiredToDestroy)
                    {
                        Destroy(hit.transform.gameObject);
                    }
                }
            }
        }
    }
}