using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MobileUI : MonoBehaviour
{
    public string SongName;
    public string SongName1;

    // Start is called before the first frame update
    void Start()
    {
        FindFirstObjectByType<AudioManager>().Play(SongName);
        FindFirstObjectByType<AudioManager>().Stop(SongName1);
        FindFirstObjectByType<AudioManager>().Stop("GoodEndingTheme");
        FindFirstObjectByType<AudioManager>().Stop("SadEndingTheme");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        SceneManager.LoadScene("MainGame");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
