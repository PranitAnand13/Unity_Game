using UnityEngine;

[RequireComponent(typeof(Light))]
public class DayNightCycle : MonoBehaviour
{
    [Header("Day Cycle Settings")]
    [Tooltip("Duration of a full day cycle in seconds.")]
    [SerializeField]
    private float dayDurationInSeconds = 120f;

    [Tooltip("Gradient representing the sun's color over the course of the day.")]
    [SerializeField]
    private Gradient lightColorOverTime;

    private Light directionalLight;
    private float timeOfDay; // 0 to 1 (percentage of full day)

    void Start()
    {
        directionalLight = GetComponent<Light>();
    }

    void Update()
    {
        if (dayDurationInSeconds <= 0f) return;

        // Update time of day (0 to 1)
        timeOfDay += Time.deltaTime / dayDurationInSeconds;
        if (timeOfDay > 1f)
            timeOfDay -= 1f;

        // Rotate light
        float rotationAngle = 360f * Time.deltaTime / dayDurationInSeconds;
        transform.Rotate(Vector3.right, rotationAngle);

        // Change color based on time of day
        directionalLight.color = lightColorOverTime.Evaluate(timeOfDay);
    }
}
