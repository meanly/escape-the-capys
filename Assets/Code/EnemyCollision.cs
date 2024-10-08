using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyCollision : MonoBehaviour
{
    public Text gameOverText;
    public AudioSource audioSource;
    public AudioClip gameOverClip;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //dapat may player tag na "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            //play a sound
            PlayGameOverSound();

            //destroys the player
            Destroy(collision.gameObject);

            // display
            ShowGameOver();

            ReloadScene();
        }   
    }

    public void ReloadScene()
    {
        // Invoke the actual reload method after a 3-second delay
        Invoke("PerformReload", 3f);
    }

    void ShowGameOver()
    {
        gameOverText.text = "Game Over!";
        gameOverText.gameObject.SetActive(true);
    }

    void PlayGameOverSound()
    {
        if (audioSource != null && gameOverClip != null)
        {
            audioSource.clip = gameOverClip;
            audioSource.Play();
        }
    }
    private void PerformReload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
