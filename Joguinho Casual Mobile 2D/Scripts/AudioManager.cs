//Controle de audio individual
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Array de AudioSources para tocar os áudios
    private AudioSource[] audioSources;

    // Os quatro áudios diferentes
    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public AudioClip audioClip3;
    public AudioClip audioClip4;

    // Volumes individuais para cada áudio
    [Range(0f, 1f)] public float volumeAudio1 = 1f;
    [Range(0f, 1f)] public float volumeAudio2 = 1f;
    [Range(0f, 1f)] public float volumeAudio3 = 1f;
    [Range(0f, 1f)] public float volumeAudio4 = 1f;

    // Inicializa os AudioSources
    void Start()
    {
        // Cria o array de AudioSource (com 4 fontes, um para cada áudio)
        audioSources = new AudioSource[4];

        // Verifica se o GameObject já tem 4 AudioSources. Caso contrário, adiciona.
        for (int i = 0; i < 4; i++)
        {
            if (audioSources[i] == null)
            {
                audioSources[i] = gameObject.AddComponent<AudioSource>();
            }
        }

        // Inicializa os AudioSources com volumes específicos
        audioSources[0].volume = volumeAudio1;
        audioSources[1].volume = volumeAudio2;
        audioSources[2].volume = volumeAudio3;
        audioSources[3].volume = volumeAudio4;

        // Verifica se os clips foram atribuídos
        if (audioClip1 == null || audioClip2 == null || audioClip3 == null || audioClip4 == null)
        {
            Debug.LogWarning("Alguns clips de áudio não foram atribuídos.");
        }
    }

    // Método para tocar um áudio em um AudioSource específico
    private void PlayAudio(int sourceIndex, AudioClip clip)
    {
        if (audioSources.Length > sourceIndex && clip != null)
        {
            audioSources[sourceIndex].clip = clip;
            audioSources[sourceIndex].Play();
            //Debug.Log($"Tocando áudio: {clip.name} na fonte {sourceIndex + 1}");
        }
        else
        {
            Debug.LogWarning("Erro ao tocar o áudio. Índice ou Clip inválido.");
        }
    }

    // Evento de animação 1: Tocar o primeiro áudio
    public void PlayAudioEvent1()
    {
        PlayAudio(0, audioClip1);
    }

    // Evento de animação 2: Tocar o segundo áudio
    public void PlayAudioEvent2()
    {
        PlayAudio(1, audioClip2);
    }

    // Evento de animação 3: Tocar o terceiro áudio
    public void PlayAudioEvent3()
    {
        PlayAudio(2, audioClip3);
    }

    // Evento de animação 4: Tocar o quarto áudio
    public void PlayAudioEvent4()
    {
        PlayAudio(3, audioClip4);
    }

    // Método opcional para parar todos os áudios
    public void StopAudio()
    {
        foreach (var audioSource in audioSources)
        {
            audioSource.Stop();
        }
    }

    // Métodos para ajustar o volume de cada AudioSource individualmente
    public void SetVolumeAudio1(float newVolume)
    {
        volumeAudio1 = Mathf.Clamp(newVolume, 0f, 1f);
        audioSources[0].volume = volumeAudio1;
        //Debug.Log($"Volume do áudio 1 ajustado para: {volumeAudio1}");
    }

    public void SetVolumeAudio2(float newVolume)
    {
        volumeAudio2 = Mathf.Clamp(newVolume, 0f, 1f);
        audioSources[1].volume = volumeAudio2;
       // Debug.Log($"Volume do áudio 2 ajustado para: {volumeAudio2}");
    }

    public void SetVolumeAudio3(float newVolume)
    {
        volumeAudio3 = Mathf.Clamp(newVolume, 0f, 1f);
        audioSources[2].volume = volumeAudio3;
       // Debug.Log($"Volume do áudio 3 ajustado para: {volumeAudio3}");
    }

    public void SetVolumeAudio4(float newVolume)
    {
        volumeAudio4 = Mathf.Clamp(newVolume, 0f, 1f);
        audioSources[3].volume = volumeAudio4;
        //Debug.Log($"Volume do áudio 4 ajustado para: {volumeAudio4}");
    }
}


/*
//Audio não é atropelado pelo outro
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Array de AudioSources para tocar os áudios
    private AudioSource[] audioSources;

    // Os quatro áudios diferentes
    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public AudioClip audioClip3;
    public AudioClip audioClip4;

    // Inicializa os AudioSources
    void Start()
    {
        // Cria o array de AudioSource (com 4 fontes, um para cada áudio)
        audioSources = new AudioSource[4];

        // Obtém os AudioSources disponíveis no GameObject
        AudioSource[] sources = GetComponents<AudioSource>();
        
        // Se já houver menos de 4 AudioSources, cria os outros
        if (sources.Length < 4)
        {
            for (int i = 0; i < 4; i++)
            {
                if (i >= sources.Length)
                {
                    AudioSource newSource = gameObject.AddComponent<AudioSource>();
                    sources = GetComponents<AudioSource>();  // Atualiza a lista de AudioSources
                }
            }
        }

        audioSources = sources;

        // Inicializa os AudioSources para que possam ser usados para os clips
        if (audioSources.Length < 4)
        {
            Debug.LogError("Não há 4 AudioSources no GameObject.");
        }
    }

    // Método para tocar um áudio em um AudioSource específico
    private void PlayAudio(int sourceIndex, AudioClip clip)
    {
        if (audioSources.Length > sourceIndex && clip != null)
        {
            audioSources[sourceIndex].clip = clip;
            audioSources[sourceIndex].Play();
            Debug.Log($"Tocando áudio: {clip.name} na fonte {sourceIndex + 1}");
        }
        else
        {
            Debug.LogWarning("Erro ao tocar o áudio. Índice ou Clip inválido.");
        }
    }

    // Evento de animação 1: Tocar o primeiro áudio
    public void PlayAudioEvent1()
    {
        PlayAudio(0, audioClip1);
    }

    // Evento de animação 2: Tocar o segundo áudio
    public void PlayAudioEvent2()
    {
        PlayAudio(1, audioClip2);
    }

    // Evento de animação 3: Tocar o terceiro áudio
    public void PlayAudioEvent3()
    {
        PlayAudio(2, audioClip3);
    }

    // Evento de animação 4: Tocar o quarto áudio
    public void PlayAudioEvent4()
    {
        PlayAudio(3, audioClip4);
    }

    // Método opcional para parar todos os áudios
    public void StopAudio()
    {
        foreach (var audioSource in audioSources)
        {
            audioSource.Stop();
        }
    }
}
*/


/*using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Um único AudioSource para tocar os áudios
    private AudioSource audioSource;

    // Os três áudios diferentes
    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public AudioClip audioClip3;
    public AudioClip audioClip4;

    // Inicializa o AudioSource
    void Start()
    {
        // Obtém o componente AudioSource do GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource não encontrado no GameObject.");
        }
    }

    // Evento de animação 1: Tocar o primeiro áudio
    public void PlayAudioEvent1()
    {
        if (audioClip1 != null)
        {
            audioSource.clip = audioClip1; // Atribui o áudio ao AudioSource
            audioSource.Play(); // Toca o áudio
            Debug.Log("AudioEvent1: Tocar áudio 1.");
        }
        else
        {
            Debug.LogWarning("AudioClip1 não foi atribuído.");
        }
    }

    // Evento de animação 2: Tocar o segundo áudio
    public void PlayAudioEvent2()
    {
        if (audioClip2 != null)
        {
            audioSource.clip = audioClip2; // Atribui o áudio ao AudioSource
            audioSource.Play(); // Toca o áudio
        }
    }

    // Evento de animação 3: Tocar o terceiro áudio
    public void PlayAudioEvent3()
    {
        if (audioClip3 != null)
        {
            audioSource.clip = audioClip3; // Atribui o áudio ao AudioSource
            audioSource.Play(); // Toca o áudio
        }
    }

    // Evento de animação 4: Tocar o terceiro áudio
    public void PlayAudioEvent4()
    {
        if (audioClip4 != null)
        {
            audioSource.clip = audioClip4; // Atribui o áudio ao AudioSource
            audioSource.Play(); // Toca o áudio
        }
    }

    // Método opcional para parar o áudio
    public void StopAudio()
    {
        audioSource.Stop(); // Para o áudio
    }
}*/