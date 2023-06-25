using UnityEngine;
public class Car_Clicker : MonoBehaviour
{
    score_minus SM;
    [SerializeField] private int clicksRequiredToDestroy;
    [SerializeField] private int clicked;
    [SerializeField] public int points;
    private void Start()
    {
        SM = FindAnyObjectByType<score_minus>();
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
                    if (clicked == clicksRequiredToDestroy)
                    {
                        SM.AddScore(points);
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
                    if (clicked == clicksRequiredToDestroy)
                    {
                        SM.AddScore(points);
                        Destroy(hit.transform.gameObject);
                    }
                }
            }
        }
    }
}