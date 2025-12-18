using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public Text pointsText, maxPointsText;

    [SerializeField] private int points = 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateMaxPoints();
    }

    public void IncreasePoints()
    {
        points+=1;
        Debug.Log($"PUNTO SUMADO - Total: {points} | Llamado desde: {System.Environment.StackTrace}");

        pointsText.text = points.ToString();
        UpdateMaxPoints();
    }

    public void UpdateMaxPoints()
    {
        int maxPoints = PlayerPrefs.GetInt("Max", 0);

        if (points >= maxPoints)
        {
            maxPoints = points;
            PlayerPrefs.SetInt("Max", maxPoints);
        }

        maxPointsText.text = "BEST: " + maxPoints.ToString();
    }
}
