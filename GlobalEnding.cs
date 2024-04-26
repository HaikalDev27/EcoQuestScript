using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GlobalEnding : MonoBehaviour
{
    public string EndTheme;
    public UnityEvent Action;

    // Start is called before the first frame update
    void Start()
    {
        FindFirstObjectByType<AudioManager>().Stop("MainMenuTheme");
        FindFirstObjectByType<AudioManager>().Stop("MainTheme");
        FindFirstObjectByType<AudioManager>().Play(EndTheme);
        Action.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnToMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
