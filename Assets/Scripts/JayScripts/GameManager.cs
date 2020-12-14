using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Static class meant for holding anything that needa to persist between scenes or levels.
    // Also holds functionality for scene switching.

    // This can be used in a variety of ways, like getting music to persist betwee scenes,
    // keeping track of variables used in one scene to be used in another, etc.

    private static GameManager _GM;

    public static GameManager Instance
    {
        get
        {
            // If we have no current game manager...
            if (_GM == null)
            {
                // Find the first one we can!
                _GM = FindObjectOfType<GameManager>();

                // If that still doesn't work...
                if (_GM == null)
                {
                    // Create one!
                    GameObject gm = new GameObject("GM");
                    _GM = gm.AddComponent<GameManager>();
                }
            }

            return _GM;
        }
        private set
        {
            _GM = value;
        }
    }

    private void Awake()
    {
        // If _GM is already populated and it's value isn't equal to this one...
        if (_GM != null && _GM != this)
        {
            // Destroy this one! It's a copy, and we only need 1 GM at a given point!
            Destroy(gameObject);
            return;
        }

        // Set the _GM to be this instance, and make sure it can't be deleted when we switch scenes!
        _GM = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
