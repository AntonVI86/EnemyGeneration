using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class EnemyAudioSource : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();       
    }

    public void PlayClip(AudioClip clip) 
    {
        _audioSource.PlayOneShot(clip);
    }

    public void PlayClip(AudioClip[] clips)
    {
        int clipIndex = Random.Range(0, clips.Length);

        _audioSource.PlayOneShot(clips[clipIndex]);
    }
}
