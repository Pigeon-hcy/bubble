using UnityEngine;

public class Shake : MonoBehaviour
{
    public float shakeAngle = 10f;
    public float speed = 2f; 

    private RectTransform rectTransform; 

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        float angle = Mathf.Sin(Time.time * speed) * shakeAngle;
        rectTransform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
