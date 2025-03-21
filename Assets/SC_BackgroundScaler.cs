using UnityEngine;
using UnityEngine.UI;

public class SC_BackgroundDarkener : MonoBehaviour
{
    private Image bgImage;
    [Range(0f, 0.5f)] public float darkenAmount = 0.2f; // Giảm bớt độ tối
    [Range(0f, 0.3f)] public float desaturationAmount = 0.1f; // Giảm màu nhẹ hơn
    private RectTransform rt;
    public float shakeAmount = 20f; // Mức độ rung

    void Start()
    {
        bgImage = GetComponent<Image>();
        ApplyDarkGothicEffect();
        rt = GetComponent<RectTransform>();
    }

    void Update()
    {
        float x = Mathf.Sin(Time.time * 3) * shakeAmount;
        float y = Mathf.Cos(Time.time * 3) * shakeAmount;
        rt.anchoredPosition += new Vector2(x, y) * Time.deltaTime;
    }

    void ApplyDarkGothicEffect()
    {
        Color color = bgImage.color;

        // Giảm sáng nhưng giữ lại độ chi tiết
        color.r = Mathf.Lerp(color.r, 0.6f, darkenAmount);
        color.g = Mathf.Lerp(color.g, 0.6f, darkenAmount * (1 - desaturationAmount));
        color.b = Mathf.Lerp(color.b, 0.6f, darkenAmount);

        bgImage.color = color;
    }
}
