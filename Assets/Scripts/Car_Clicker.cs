using UnityEngine;
public class Car_Clicker : MonoBehaviour
{
    [SerializeField] public int clicksRequiredToDestroy;
    [SerializeField] public int clicked;
    [SerializeField] public int points;
    private void Start()
    {
        clicked = 0; 
    }
    
}