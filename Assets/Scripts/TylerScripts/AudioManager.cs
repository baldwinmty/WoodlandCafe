using UnityEngine;
[System.Serializable]

public class Sound
{
    public string name;
    public AudioClip clip;

    public float volume = 1f;
    public float pitch = 1f;

    private AudioSource source;

    public void SetSource (AudioSource _source)
    {
        source = _source;
            source.clip = clip;
    }

    public void Play ()
    {
        source.volume = volume;
        source.pitch = pitch;
        source.Play();
    }
}

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    Sound[] sounds;
}
