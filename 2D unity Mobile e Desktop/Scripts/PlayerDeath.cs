using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private bool morreu = false;

    private void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.CompareTag("Death") && !morreu)
        {
            morreu = true;
            SceneManager.LoadScene("GameOver");
        }
    }
}