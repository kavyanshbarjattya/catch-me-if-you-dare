using UnityEngine;
public class Car_Despawner : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            Destroy(other.gameObject, 3f);
        }
    }
}