using UnityEngine;
using TMPro;
public class score_minus : MonoBehaviour
{
    [SerializeField] public static int score;
    [SerializeField] public float apparentScore;
    [SerializeField] public TextMeshProUGUI text;
    private void Start()
    {
        score = 0;
    }
    private void Update()
    {
        //apparentScore = Mathf.Lerp(apparentScore, score, Time.deltaTime);
        text.text = (Mathf.RoundToInt(score)).ToString();
    }
    public void AddScore(int s)
    {
        score += s;
    }
    public void LowerScore(int s)
    {
        score -= s;
        if(score <= 0)
        {
            score = 0;
        }
    }
}