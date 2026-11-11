using UnityEngine;
using UnityEngine.SceneManagement;  // Importa o namespace para manipular cenas
using System.Collections;  // Importa o namespace para IEnumerator e coroutines

public class Dragon : MonoBehaviour
{
    [Header("Attributes")]
    public int health = 4;  // O inimigo morre após 4 danos

    [Header("References")]
    public Animator animator;

    // Nova variável pública para selecionar a cena
    public string sceneToLoad = " ";  // Nome da cena a ser carregada após a morte

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o jogador está colidindo com o inimigo
        if (collision.collider.CompareTag("Player"))
        {
            NeW_Player player = collision.collider.GetComponent<NeW_Player>();
            
            // Verifica se o jogador está indo para baixo (pulando sobre a cabeça do inimigo)
            if (player != null && player.currentJumps > 0 && player.rb2D.velocity.y < 0)
            {
                TakeDamage(player.currentJumps);  // Aplica dano ao inimigo
            }
        }
    }

    // Método para aplicar dano ao inimigo
    public void TakeDamage(int jumpCount)
    {
        // O inimigo recebe dano dependendo do número de pulos
        health--;

        if (health <= 0)
        {
            Die();  // O inimigo morre quando sua saúde chega a zero
        }
    }

    // Método para fazer o inimigo morrer
    private void Die()
    {
        animator.SetTrigger("Die");  // Ativa a animação de morte do inimigo
        // Inicia a Coroutine para esperar 2 segundos e depois trocar de cena
        StartCoroutine(DieAndChangeScene());
    }

    // Coroutine para esperar 2 segundos antes de trocar de cena
    private IEnumerator DieAndChangeScene()
    {
        // Aguarda 2 segundos
        yield return new WaitForSeconds(2f);

        // Troca para a cena configurada no Inspector
        SceneManager.LoadScene(sceneToLoad);
    }
}