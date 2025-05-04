using UnityEngine;
using Util; 
using TMPro;

public class TimeManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Timer gameTimer; 
    [SerializeField] private TextMeshProUGUI timerDisplay;
    void Start()
    {
        gameTimer = new Timer(240f);
        

    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
       
        gameTimer.Tick(dt);
        int remaining =Mathf.CeilToInt(gameTimer.RemainingSeconds);
        Debug.Log($"Remaining Time: {remaining}");
        Debug.Log(gameTimer.RemainingSeconds);
        timerDisplay.text = $"Time: {remaining} seconds";

    }
}
