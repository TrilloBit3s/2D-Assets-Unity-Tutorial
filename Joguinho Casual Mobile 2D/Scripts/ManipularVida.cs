//sofre dano enquanto estiver no colisor com temporizador
using UnityEngine;

public class ManipularVida : MonoBehaviour
{
    // Referência ao script de vida do jogador
    public VidaDoJogador playerHealth;

    // Quantidade de dano que será causado ao jogador
    public int dano = 10;

    // Intervalo de tempo entre os danos
    public float danoIntervalo = 1f;

    // Variável para controle de tempo
    private float tempoDesdeUltimoDano = 0f;

    // Evento de colisão com o jogador (apenas na colisão inicial)
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Verifica se o objeto colidido é o jogador
        {
            // Aplica o dano ao jogador
            AplicarDano(collision.gameObject);
        }
    }

    // Evento chamado enquanto o jogador estiver em contato contínuo com o colisor (Colisão contínua)
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Verifica se o objeto é o jogador
        {
            // Aplica o dano ao jogador a cada intervalo
            tempoDesdeUltimoDano += Time.deltaTime; // Aumenta o tempo que passou desde o último dano

            if (tempoDesdeUltimoDano >= danoIntervalo)  // Verifica se o intervalo foi alcançado
            {
                AplicarDano(collision.gameObject);
                tempoDesdeUltimoDano = 0f;  // Reseta o tempo
            }
        }
    }

    // Se o dano for causado por um gatilho (trigger), por exemplo, uma área de dano (evento contínuo)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verifica se o objeto é o jogador
        {
            // Aplica o dano ao jogador
            AplicarDano(other.gameObject);
        }
    }

    // Evento chamado enquanto o jogador estiver em contato contínuo com o gatilho (trigger)
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verifica se o objeto é o jogador
        {
            // Aplica o dano ao jogador a cada intervalo
            tempoDesdeUltimoDano += Time.deltaTime; // Aumenta o tempo que passou desde o último dano

            if (tempoDesdeUltimoDano >= danoIntervalo)  // Verifica se o intervalo foi alcançado
            {
                AplicarDano(other.gameObject);
                tempoDesdeUltimoDano = 0f;  // Reseta o tempo
            }
        }
    }

    // Função para aplicar o dano ao jogador
    private void AplicarDano(GameObject jogador)
    {
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(dano); // Chama o método TakeDamage
            Debug.Log("Jogador sofreu dano de " + dano);
        }
    }
}



/*
//Sofre dano com toques
using UnityEngine;

public class ManipularVida : MonoBehaviour
{
    // Referência ao script de vida do jogador
    public VidaDoJogador playerHealth;

    // Quantidade de dano que será causado ao jogador
    public int dano = 10;

    // Evento de colisão com o jogador
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Verifica se o objeto colidido é o jogador
        {
            // Aplica o dano ao jogador
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(dano); // Chama o método TakeDamage
                Debug.Log("Jogador sofreu dano de " + dano);
            }
        }
    }

    // Se o dano for causado por um gatilho (trigger), por exemplo, uma área de dano
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verifica se o objeto é o jogador
        {
            // Aplica o dano ao jogador
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(dano); // Chama o método TakeDamage
                Debug.Log("Jogador sofreu dano de " + dano);
            }
        }
    }
}
*/