using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{

    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public GameObject PausePanel;
    public GameObject TitlePanel;
    public GameObject OptionPanel;
   
    
    public static bool GameIsPaused = false;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    
    public void SetVolume()
    {
        
        audioMixer.SetFloat("volume", volumeSlider.value);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void Resume()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Debug.Log("Resume");
    }
    
    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Back()
    {
        OptionPanel.SetActive(false);
        TitlePanel.SetActive(true);
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

}
