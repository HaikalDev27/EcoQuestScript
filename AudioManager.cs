using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake() {

        if (instance == null) //if an object with this component script
            instance = this; //then leave it like so
        else
        {
            Destroy(gameObject); //but if it's not then destroy this object
            return;
        }

        DontDestroyOnLoad(gameObject); //because this will be exist in main scene but not in any other so we wont destroy this object on main scene while we'll create a new one in other scene
        
        foreach (Sound s in sounds) //Volume mixer in setting UI
        {
            s.source = gameObject.AddComponent<AudioSource>(); //get the source of our audio
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.outputAudioMixerGroup = s.output;
            s.source.loop = s.loop;
        }   
    }

    // Update is called once per frame
    public void Play(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Play(); //play the sound on source
    }

    public void Stop(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Stop(); //stopping the sound
    }
}
