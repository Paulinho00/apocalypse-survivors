using UnityEngine;

public class StageTime : MonoBehaviour
{
    public float time;
    TimeUI timeUI;

    private void Awake()
    {
        timeUI = FindObjectOfType<TimeUI>();
    }

    void Update()
    {
        time += Time.deltaTime;
        timeUI.UpdateTime(time);
    }
}
