using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public static Timer Instance;
    [SerializeField] private TextMeshProUGUI TextTimer;
    [SerializeField] private float ElapsedTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        ElapsedTime -= Time.deltaTime;
        int Minutes = Mathf.FloorToInt(ElapsedTime / 60);
        int seconds = Mathf.FloorToInt(ElapsedTime % 60);
        TextTimer.text = string.Format("{0:00}:{1:00}", Minutes, seconds);
    }
}
