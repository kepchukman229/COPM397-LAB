using System.Collections;
using UnityEngine;

public class AudioContoller : PersistentSingleton<AudioContoller>
{
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private AudioClip jumpSFX;
    [SerializeField] private AudioClip deathSFX;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;



    private IEnumerator Start()
    {
        Debug.Log("audiocontroller.start");
        yield return new WaitForSeconds(4f);
        Debug.Log("audiocontroller.playmusic after 4 seconds");
        PlayBgMusic();
    }





    public void PlayJumpSFX()
    {
        sfxSource.clip = jumpSFX;
        sfxSource.Play();
    }

    public void PlayDeathSFX()
    {
        sfxSource.clip = deathSFX;
        sfxSource.Play(); 
    }

    public void PlayBgMusic()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }
}
