using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {
    
    private int QualityLevel;
    private int fullscreen;
    private float audio;
    private int height;
    private int width;

    public Text Text;
    public Slider quality;
    public Slider volume;
    public Toggle fullScreen;

    void Awake()
    {
        if (!PlayerPrefs.HasKey("Set"))
        {
            QualityLevel = QualitySettings.GetQualityLevel();
            audio = AudioListener.volume;
            if (Screen.fullScreen)
            {
                fullscreen = 1;
            }
            else
            {
                fullscreen = 0;
            }
            width = Screen.height;
            height = Screen.width;
            PlayerPrefs.SetInt("QualityLevel", QualityLevel);
            PlayerPrefs.SetInt("Fullscreen", fullscreen);
            PlayerPrefs.SetFloat("Audio", audio);
            PlayerPrefs.SetInt("Set", 1);
            PlayerPrefs.Save();
            Text.text = height + " x " + width;
            Debug.Log(height);
            Debug.Log(width);
        }
        else
        {
            QualityLevel = PlayerPrefs.GetInt("QualityLevel");
            fullscreen = PlayerPrefs.GetInt("Fullscreen");
            audio = PlayerPrefs.GetFloat("Audio");
            QualitySettings.SetQualityLevel(QualityLevel);
            if (fullscreen == 1)
                Screen.fullScreen = true;
            else
                Screen.fullScreen = false;
            AudioListener.volume=audio;


        }
        width = Screen.height;
        height = Screen.width;
        Text.text = height + " x " + width;
    }

    public void Open()
    {
        quality.value = QualityLevel;
        volume.value = audio;

    }

    public void ResIncrease()
    {
        if (width == 480 && height == 640)
        {
            height = 720;
            Text.text = "720 x 480";
        }
        else if (height == 720 && width == 480)
        {
            width = 576;
            Text.text = "720 x 576";
        }
        else if (height == 720 && width == 576)
        {
            width = 600;
            height = 800;
            Text.text = "800 x 600";
        }
        else if (height == 800 && width == 600)
        {
            height = 1024;
            width = 768;
            Text.text = "1024 x 768";
        }
        else if (height == 1024 && width == 768)
        {
            height = 1152;
            width = 864;
            Text.text = "1152 x 864";
        }
        else if (height == 1152 && width == 864)
        {
            height = 1280;
            width = 720;
            Text.text = "1280 x 720";
        }
        else if (height == 1280 && width == 720)
        {
            height = 1280;
            width = 768;
            Text.text = "1280 x 768";
        }
        else if (height == 1280 && width == 768)
        {
            height = height;
            width = 800;
            Text.text = "1280 x 800";
        }
        else if (height == 1280 && width == 800)
        {
            height = 1280;
            width = 960;
            Text.text = "1280 x 960";
        }
        else if (height == 1280 && width == 960)
        {
            height = 1280;
            width = 1024;
            Text.text = "1280 x 1024";
        }
        else if (height == 1280 && width == 1024)
        {
            height = 1360;
            width = 768;
            Text.text = "1360 x 768";
        }
        else if (height == 1360 && width == 768)
        {
            height = 1366;
            width = 768;
            Text.text = "1366 x 768";
        }
        else if (height == 1366 && width == 768)
        {
            height = 1600;
            width = 900;
            Text.text = "1600 x 900";
        }
        else if (height == 1600 && width == 900)
        {
            height = 1600;
            width = 1024;
            Text.text = "1600 x 1024";
        }
        else if (height == 1600 && width == 1024)
        {
            height = 1680;
            width = 1050;
            Text.text = "1680 x 1050";
        }
        else if (height == 1680 && width == 1050)
        {
            height = 1920;
            width = 1080;
            Text.text = "1920 x 1080";
        }
        else if (height == 1920 && width == 1080)
        {
            height = 2715;
            width = 1527;
            Text.text = "2715 x 1527";
        }
        else if (height == 2715 && width == 1527)
        {
            height = 640;
            width = 480;
            Text.text = "640 x 480";
        }
    }

    public void ResDecrease()
    {
        if (height == 720 && width == 576)
        {
            height = 720;
            width = 480;
            Text.text = "720 x 480";
        }
        else if (height == 800 && width == 600)
        {
            height = 800;
            width = 576;
            Text.text = "720 x 576";
        }
        else if (height == 1024 && width == 768)
        {
            width = 600;
            height = 800;
            Text.text = "800 x 600";
        }
        else if (height == 1152 && width == 864)
        {
            height = 1024;
            width = 768;
            Text.text = "1024 x 768";
        }
        else if (height == 1280 && width == 720)
        {
            height = 1152;
            width = 864;
            Text.text = "1152 x 864";
        }
        else if (height == 1280 && width == 768)
        {
            height = 1280;
            width = 720;
            Text.text = "1280 x 720";
        }
        else if (height == 1280 && width == 800)
        {
            height = 1280;
            width = 768;
            Text.text = "1280 x 768";
        }
        else if (height == 1280 && width == 960)
        {
            height = height;
            width = 800;
            Text.text = "1280 x 800";
        }
        else if (height == 1280 && width == 1024)
        {
            height = 1280;
            width = 960;
            Text.text = "1280 x 960";
        }
        else if (height == 1360 && width == 768)
        {
            height = 1280;
            width = 1024;
            Text.text = "1280 x 1024";
        }
        else if (height == 1366 && width == 768)
        {
            height = 1360;
            width = 768;
            Text.text = "1360 x 768";
        }
        else if (height == 1600 && width == 900)
        {
            height = 1366;
            width = 768;
            Text.text = "1366 x 768";
        }
        else if (height == 1600 && width == 1024)
        {
            height = 1600;
            width = 900;
            Text.text = "1600 x 900";
        }
        else if (height == 1680 && width == 1050)
        {
            height = 1600;
            width = 1024;
            Text.text = "1600 x 1024";
        }
        else if (height == 1920 && width == 1050)
        {
            height = 1680;
            width = 1050;
            Text.text = "1680 x 1050";
        }
        else if (height == 2715 && width == 1527)
        {
            height = 1920;
            width = 1080;
            Text.text = "1920 x 1080";
        }
        else if (height == 640 && width == 480)
        {
            height = 2715;
            width = 1527;
            Text.text = "2715 x 1527";
        }
        else if (height == 720 && width == 480)
        {
            height = 640;
            width = 480;
            Text.text = "640 x 480";
        }
    }

    public void Close()
    {
        PlayerPrefs.SetInt("QualityLevel", QualityLevel);
        PlayerPrefs.SetInt("Fullscreen", fullscreen);
        PlayerPrefs.SetFloat("Audio", audio);
        PlayerPrefs.SetInt("Set", 1);
        PlayerPrefs.SetInt("Height", height);
        PlayerPrefs.SetInt("Width", width);
        PlayerPrefs.Save();
        QualitySettings.SetQualityLevel(QualityLevel);
        if (fullscreen == 1)
            Screen.fullScreen = true;
        else
            Screen.fullScreen = false;
        AudioListener.volume = audio;
        Screen.SetResolution(height, width, Screen.fullScreen);

    }

    public void QualityChange()
    {
        QualityLevel = (int)quality.value;
    }

    public void VolumeChange()
    {
        audio = volume.value;
    }

    public void ScreenChange()
    {
        Screen.fullScreen = fullScreen.isOn;
    }


}
