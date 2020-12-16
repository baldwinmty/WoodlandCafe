using UnityEngine;
[System.Serializable]

public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f,1f)]
    public float volume = 1f;
    [Range(0.5f, 1.5f)]
    public float pitch = 1f;

    [Range(0f, .5f)]
    public float randomVolume = .1f;
    [Range(0f, .5f)]
    public float randomPitch = .1f;

    private AudioSource source;

    public void SetSource (AudioSource _source)
    {
        source = _source;
            source.clip = clip;
    }

    public void Play ()
    {
        source.volume = volume;
        source.pitch = pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f));
        source.Play();
    }
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    Sound[] sounds;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than 1 audio manager in scene");
        }
        else
        {
        instance = this;
        }
    }

    void Start ()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
            _go.transform.SetParent(this.transform);
            sounds[i].SetSource (_go.AddComponent<AudioSource>());
        }

       // PlaySound("Loop");
       // PlaySound("Birds");
       // PlaySound("Crickets");
       // PlaySound("Frogs");
    }

    public void PlaySound (string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Play();
                return;
            }
        }

        // no sound w/ _name
        Debug.Log("AudioManager: no sound of that name. " + _name);

    }

}
