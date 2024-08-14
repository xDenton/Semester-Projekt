using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Logoeinblendung : MonoBehaviour
{
    public RawImage logoRawImage; // Das Image-Objekt für das Logo
    public RawImage fadeOverlay; // Ein schwarzes Overlay-Image für das Fade-Out
    public float fadeInDuration = 1.5f; // Dauer für das Einblenden des Logos
    public float displayDuration = 2.0f; // Dauer, wie lange das Logo angezeigt wird
    public float fadeOutDuration = 1.5f; // Dauer für das Ausblenden des Logos
    public float sceneTransitionDuration = 2.0f; // Dauer für das Fade-Out zur nächsten Szene
    public string nextSceneName = "Intro"; // Die nächste Szene, die geladen wird


    // Start is called before the first frame update
    void Start()
    {
        fadeOverlay.color = new Color(0, 0, 0, 0);
        StartCoroutine(ShowLogoAndTransition());
    }

    IEnumerator ShowLogoAndTransition()
    {
        // Einblenden des Logos
        yield return StartCoroutine(FadeIn(logoRawImage));

        // Zeit, während das Logo sichtbar ist
        yield return new WaitForSeconds(displayDuration);

        // Ausblenden des Logos
        yield return StartCoroutine(FadeOut(logoRawImage));

        // Einblenden des schwarzen Overlays für den Szenenwechsel
        yield return StartCoroutine(FadeIn(fadeOverlay, sceneTransitionDuration));

        // Wechsele zur nächsten Szene
        SceneManager.LoadScene(nextSceneName);
    }

    IEnumerator FadeIn(RawImage image, float duration = -1)
    {
        if (duration < 0) duration = fadeInDuration;
        float elapsedTime = 0f;
        Color color = image.color;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / duration);
            image.color = color;
            yield return null;
        }
    }

    IEnumerator FadeOut(RawImage image, float duration = -1)
    {
        if (duration < 0) duration = fadeOutDuration;
        float elapsedTime = 0f;
        Color color = image.color;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            color.a = 1f - Mathf.Clamp01(elapsedTime / duration);
            image.color = color;
            yield return null;
        }
    }
}
