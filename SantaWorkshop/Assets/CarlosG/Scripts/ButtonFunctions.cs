using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Options()
    {

    }

}
