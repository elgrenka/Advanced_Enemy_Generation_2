using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioOnEnable : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        if (_audioSource.loop)
            _audioSource.Play();
        else
            _audioSource.PlayOneShot(_audioSource.clip);
    }

    private void OnDisable()
    {
        _audioSource.Stop();
    }
}