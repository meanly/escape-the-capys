using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameCollision : MonoBehaviour
{
    public GameObject VictoryScreenParent; // Reference to the parent GameObject containing VictoryScreen
    public AudioSource audioSource;       // Audio source for playing sounds
    public AudioClip gameOverClip;        // Audio clip for the victory sound
    public float reloadDelay = 5f;        // Time to wait before reloading the scene

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Play the victory sound
            PlayGameOverSound();

            // Destroy the player game object
            Destroy(collision.gameObject);

            // Enable the VictoryScreen parent object
            EnableVictoryScreen();

            // Reload the scene after a delay
            Invoke("ReloadScene", reloadDelay);
        }   
    }

    void EnableVictoryScreen()
    {
        // Ensure VictoryScreenParent is not null and activate it
        if (VictoryScreenParent != null)
        {
            VictoryScreenParent.SetActive(true);
        }
    }

    void PlayGameOverSound()
    {
        if (audioSource != null && gameOverClip != null)
        {
            audioSource.clip = gameOverClip;
            audioSource.Play();
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0); // Reload Scene 0
    }
}
