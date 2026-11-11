using System.Collections; 
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.SceneManagement; 

public class ChangeScenes : MonoBehaviour // Define uma classe pública chamada ChangeScenes, que herda de MonoBehaviour.
{
    public string nomeDaCena; // Declara uma variável pública do tipo string, que armazenará o nome da cena a ser carregada.

    void OnTriggerEnter2D(Collider2D hit)  // Função chamada quando outro objeto entra em um trigger (área de colisão) 2D.
    {
        if (hit.CompareTag("Player"))  // Verifica se o objeto que entrou no trigger tem a tag "Player".
        {
           // Destroy(hit.gameObject); // Linha comentada, que destruiria o objeto "Player" ao colidir (não está ativa no código atual).
            SceneManager.LoadScene(nomeDaCena); // Carrega a cena especificada pela variável "nomeDaCena" usando o SceneManager.
        }
    }
   
    public void Jogar() // Método público chamado "Jogar".
    {
        StartCoroutine(Abrir()); // Inicia uma coroutine chamada "Abrir".
    }

    public void Sair() // Método público chamado "Sair" que pode ser usado para sair ou fechar o jogo.
    {
        StartCoroutine(Fechar()); // Inicia uma coroutine chamada "Exits".

        //esta linha fecha o Play após a morte do Jogador "USO TEMPORARIO"
        #if UNITY_EDITOR // Verifica se o código está sendo executado no Unity Editor.
            UnityEditor.EditorApplication.isPlaying = false; // Encerra a execução do jogo no Unity Editor.
        #endif   
    }

    private IEnumerator Abrir() // Coroutine privada chamada "Abrir", usada para adicionar um atraso antes de carregar uma cena.
    {
        yield return new WaitForSeconds(0.5f); // Espera por 0.5 segundos antes de executar a próxima linha.
        SceneManager.LoadScene(nomeDaCena); // Carrega a cena especificada pela variável "nomeDaCena".
    }

    private IEnumerator Fechar() // Coroutine privada chamada "Exits", usada para adicionar um atraso antes de fechar o jogo.
    {
        yield return new WaitForSeconds(0.6f); // Espera por 0.6 segundos antes de executar a próxima linha.
        Application.Quit(); // Fecha o aplicativo (jogo). Não funciona no editor, apenas em uma build final.
    }
}


/*using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public string nomeDaCena;  // Nome da cena de Game Over

    // Método que detecta a colisão com o Player
    void OnTriggerEnter2D(Collider2D hit)
    {
        // Adicionando log de depuração
        Debug.Log("Objeto colidiu com o colisor!");

        if (hit.CompareTag("Player"))  // Verifica se o objeto que tocou o colisor é o Player
        {
            Debug.Log("Player tocou o colisor! Destruindo Player...");
           // Destroy(hit.gameObject);  // Destroi o Player
            SceneManager.LoadScene(nomeDaCena);  // Carrega a cena de Game Over
        }
    }
}*/