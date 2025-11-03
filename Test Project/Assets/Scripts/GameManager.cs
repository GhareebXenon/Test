using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{

    // This is the "king" (the only one) 
    public static GameManager Instance;
    public AudioSource audioSource;

    void Awake()
    {
        // If there's no king yet, this one becomes king
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // stay alive between scenes
        }
        else
        {
            // If another king shows up, destroy it
            Destroy(gameObject);
        }
    }

    public int score = 0;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
            Debug.Log("Game Magner Score =" + score);

    }

    public void StartSfx(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}

