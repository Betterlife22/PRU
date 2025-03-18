using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class SC_BackgroundScaler : MonoBehaviour
{
    private Image backgroundImage;
    private RectTransform rt;
    private float ratio;
    public float scrollSpeed = 3f; // Tốc độ cuộn
    private float imageWidth;

    void Start()
    {
        backgroundImage = GetComponent<Image>();
        rt = backgroundImage.rectTransform;
        ratio = backgroundImage.sprite.bounds.size.x / backgroundImage.sprite.bounds.size.y;
        imageWidth = rt.sizeDelta.x;
    }

    void Update()
    {
        if (!rt)
            return;

        // Scale image proportionally to fit the screen dimensions, while preserving aspect ratio
        if (Screen.height * ratio >= Screen.width)
        {
            rt.sizeDelta = new Vector2(Screen.height * ratio, Screen.height);
        }
        else
        {
            rt.sizeDelta = new Vector2(Screen.width, Screen.width / ratio);
        }

        // Di chuyển hình ảnh sang trái
        rt.anchoredPosition += Vector2.left * scrollSpeed * Time.deltaTime;

        // Nếu hình ảnh đã ra khỏi màn hình, đặt lại vị trí
        if (rt.anchoredPosition.x < -imageWidth)
        {
            rt.anchoredPosition += new Vector2(imageWidth, 0); // Đặt lại vị trí sang phải
        }
    }
}