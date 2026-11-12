using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;

public class WallSecretTrigger : MonoBehaviour
{
    [Header("Tilemap da parede secreta")]
    public Tilemap wallSecrets;

    [Header("Configuração do Fade")]
    [Min(0.01f)]
    public float fadeDuration = 0.5f;

    private Color originalColor;
    private Coroutine fadeCoroutine;

    private void Start()
    {
        if (wallSecrets == null)
        {
            Debug.LogError("Wall Secrets não foi atribuído!");
            return;
        }

        originalColor = wallSecrets.color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FadeTo(0f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FadeTo(originalColor.a);
        }
    }

    private void FadeTo(float targetAlpha)
    {
        if (wallSecrets == null)
            return;

        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }

        fadeCoroutine = StartCoroutine(FadeCoroutine(targetAlpha));
    }

    private IEnumerator FadeCoroutine(float targetAlpha)
    {
        Color currentColor = wallSecrets.color;
        float startAlpha = currentColor.a;
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;

            float progress = Mathf.Clamp01(elapsed / fadeDuration);

            float alpha = Mathf.Lerp(
                startAlpha,
                targetAlpha,
                progress
            );

            wallSecrets.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            yield return null;
        }

        wallSecrets.color = new Color(
            originalColor.r,
            originalColor.g,
            originalColor.b,
            targetAlpha
        );

        fadeCoroutine = null;
    }
}