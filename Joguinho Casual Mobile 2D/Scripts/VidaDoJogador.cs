using UnityEngine;
using UnityEngine.UI; // Para trabalhar com UI (Image)
using UnityEngine.SceneManagement; // Para carregar cenas (Game Over)
using System.Collections; // Necessário para corrotinas

public class VidaDoJogador : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Image healthBarImage;
    public Animator playerAnimator;
    private float deathDelay = 3f;
    private bool isDead = false;
    public NeW_Player playerMovementScript;
    
    [Header("Sounds")]
    public AudioSource audioSource;
    public AudioClip somMorte;
    public AudioClip somDano;

    public Renderer renderPersonagem;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Inicializa a cor para branco no começo
        if (renderPersonagem != null)
        {
            renderPersonagem.material.color = Color.white;
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;  // Se o jogador já morreu, não recebe mais dano

        currentHealth -= damage;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        UpdateHealthUI();

        // Verifica se a vida chegou a zero
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            PlaySound(somDano);
            StartCoroutine(StopHurtAnimation());
        }

        // Torna o personagem vermelho (indicado que ele tomou dano)
        if (renderPersonagem != null && !isDead) 
        {
            renderPersonagem.material.color = Color.red;
        }

        // Ativa a animação de "hurt" apenas se o jogador não estiver morto
        if (playerAnimator != null && !isDead) 
        {
            playerAnimator.SetBool("hurt", true); 
        }
    }

    // Método chamado quando o jogador morre
    void Die()
    {
        if (isDead) return;

        isDead = true;
       // Debug.Log("O jogador morreu!");

        // Bloqueia a movimentação do jogador
        if (playerMovementScript != null)
        {
            playerMovementScript.enabled = false;
        }

        // Reproduz o som de morte
        PlaySound(somMorte);

        // Verifique se o Animator não é null e o Trigger "Die" existe
        if (playerAnimator != null)
        {
            // Desativa a animação "hurt" antes de iniciar a animação de morte
            playerAnimator.SetBool("hurt", false);
           // Debug.Log("Trigger Die acionado!");
            playerAnimator.SetTrigger("Die");
        }

        // Restaura a cor do personagem para branco na morte
        if (renderPersonagem != null)
        {
            renderPersonagem.material.color = Color.white;
        }

        // Inicia o processo de Game Over após a animação
        StartCoroutine(WaitForDeathAndGameOver());
    }

    private IEnumerator WaitForDeathAndGameOver()
    {
        yield return new WaitForSeconds(deathDelay);
        GameOver();
    }

    // Método para finalizar o jogo
    void GameOver()
    {
        //Debug.Log("Game Over!");
        SceneManager.LoadScene("GameOver");
    }

    // Atualiza a barra de vida
    void UpdateHealthUI()
    {
        if (healthBarImage != null)
        {
            float healthPercentage = (float)currentHealth / maxHealth;
            healthBarImage.fillAmount = Mathf.Clamp01(healthPercentage);
        }
    }

    // Corrotina que desativa a animação de "hurt" após um breve intervalo
    private IEnumerator StopHurtAnimation()
    {
        yield return new WaitForSeconds(0.5f);

        // Só desativa a animação "hurt" se o jogador não estiver morto
        if (playerAnimator != null && !isDead)
        {
            playerAnimator.SetBool("hurt", false);
        }

        // Restaura a cor do personagem (volta para o branco)
        if (renderPersonagem != null && !isDead)
        {
            renderPersonagem.material.color = Color.white;
        }
    }

    // Método para tocar sons (uso genérico)
    void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}