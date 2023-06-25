using UnityEngine;
public class Car_Despawner : MonoBehaviour
{
    score_minus SM;
    private void Start()
    {
        SM = FindAnyObjectByType<score_minus>();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            SM.LowerScore(other.GetComponent<Car_Clicker>().points);
            Destroy(other.gameObject, 3f);
        }
    }
}