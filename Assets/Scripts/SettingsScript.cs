using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private Slider effectsVolumeSlider;
    [SerializeField]
    private Slider ambientVolumeSlider;

    private GameObject content;

    void Start()
    {
        content = transform.Find("Content").gameObject;
        Time.timeScale = content.activeInHierarchy ? 0.0f : 1.0f;

        OnEffectsSlider(effectsVolumeSlider.value);
        OnAmbientSlider(ambientVolumeSlider.value);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Time.timeScale = content.activeInHierarchy ? 1.0f : 0.0f;
            content.SetActive( ! content.activeInHierarchy );
        }
    }

    public void OnEffectsSlider(float value)
    {
        float dB = Mathf.Lerp( -80.0f, 10.0f, value );
        audioMixer.SetFloat("EffectsVolume", dB);
        // Debug.Log(value);
    }
    public void OnAmbientSlider(float value)
    {
        float dB = Mathf.Lerp( -80.0f, 10.0f, value );
        audioMixer.SetFloat("AmbientVolume", dB);
    }
    public void OnMuteAllToggle(bool value)
    {
        float dB = value ? -80.0f : 0.0f;
        audioMixer.SetFloat("MasterVolume", dB);
    }
}
/* �.�. ������ �� ������ ���������� ����������
 * - ��������� ������� �����
 * - �������� ����� ������
 * - ������ ������� ��������� ������� �� Settings
 * ��������� ������.
 */
