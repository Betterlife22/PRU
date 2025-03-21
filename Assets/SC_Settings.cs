using UnityEngine;
using UnityEngine.UI;

public class SC_Settings : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    public AudioSource musicSource;
    public AudioSource sfxSource;

    void Start()
    {
        gameObject.SetActive(false);
        // Load giá trị lưu trữ trước đó (nếu có)
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);

        // Áp dụng âm lượng
        SetMusicVolume(musicSlider.value);
        SetSFXVolume(sfxSlider.value);

        // Thêm sự kiện thay đổi giá trị
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void SaveSettings()
    {
        PlayerPrefs.Save();
        Debug.Log("Đã lưu cài đặt âm thanh!");
    }
}
