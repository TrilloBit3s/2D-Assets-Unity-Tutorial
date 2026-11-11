using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Método para iniciar o jogo
    public void PlayGame()
    {
        // Tenta carregar a próxima cena na sequência (índice + 1)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    // Método para sair do jogo
    public void QuitGame()
    {
        Application.Quit();
    }
}