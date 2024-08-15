using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Videozusammen : MonoBehaviour
{
    public VideoPlayer videoPlayer1;  // Das erste VideoPlayer-Objekt
    public VideoPlayer videoPlayer2;  // Das zweite VideoPlayer-Objekt
    public Canvas buttonsCanvas;      // Das Canvas, das die Buttons enthält
    public RawImage videoDisplay;     // Das Raw Image, das die Videos anzeigt
    public RawImage fadeOverlay;      // Optionales Overlay für sanfte Übergänge
    public float fadeDuration = 1.0f; // Dauer des Fade-Übergangs
    public Button button1;            // Der erste Button
    public Button button2;            // Der zweite Button
    public RawImage resultImage;         // Das Bild-Objekt

    void Start()
    {
        buttonsCanvas.gameObject.SetActive(false); // Verberge die Buttons zu Beginn
        resultImage.gameObject.SetActive(false);   // Verberge das Bild zu Beginn
        fadeOverlay.color = new Color(0, 0, 0, 0); // Setze das Overlay auf transparent

        // Weise die RenderTexture des ersten Videos zu
        videoPlayer1.targetTexture = new RenderTexture(1920, 1080, 0);
        videoDisplay.texture = videoPlayer1.targetTexture;

        // Starte das erste Video
        videoPlayer1.loopPointReached += OnVideo1End;
        videoPlayer1.Play();

        // Füge den Buttons Funktionen hinzu
        button1.onClick.AddListener(OnButton1Click);
        button2.onClick.AddListener(OnButton2Click);
    }

    void OnVideo1End(VideoPlayer vp)
    {
        StartCoroutine(TransitionToSecondVideo());
    }

    IEnumerator TransitionToSecondVideo()
    {
        // Optionaler Fade-Out des ersten Videos
        yield return StartCoroutine(FadeOut(fadeDuration));

        videoPlayer1.gameObject.SetActive(false);  // Deaktiviere das erste Video

        // Weise die RenderTexture des zweiten Videos zu
        videoPlayer2.targetTexture = new RenderTexture(1920, 1080, 0);
        videoDisplay.texture = videoPlayer2.targetTexture;

        videoPlayer2.gameObject.SetActive(true);   // Aktiviere das zweite Video

        // Optionaler Fade-In des zweiten Videos
        yield return StartCoroutine(FadeIn(fadeDuration));

        videoPlayer2.loopPointReached += OnVideo2End;
        videoPlayer2.Play();
    }

    void OnVideo2End(VideoPlayer vp)
    {
        // Zeige das Bild und die Buttons an, wenn das zweite Video endet
        resultImage.gameObject.SetActive(true);
        buttonsCanvas.gameObject.SetActive(true);
    }

    void OnButton1Click()
    {
        // Funktionalität für Button 1
        Debug.Log("Button 1 clicked!");
        // Beispielsweise kannst du hier eine Szene wechseln oder ein Menü öffnen
    }

    void OnButton2Click()
    {
        // Funktionalität für Button 2
        Debug.Log("Button 2 clicked!");
        // Beispielsweise kannst du hier eine andere Szene wechseln oder ein anderes Menü öffnen
    }

    IEnumerator FadeIn(float duration)
    {
        float elapsedTime = 0f;
        Color color = fadeOverlay.color;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            color.a = 1f - Mathf.Clamp01(elapsedTime / duration);
            fadeOverlay.color = color;
            yield return null;
        }
    }

    IEnumerator FadeOut(float duration)
    {
        float elapsedTime = 0f;
        Color color = fadeOverlay.color;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / duration);
            fadeOverlay.color = color;
            yield return null;
        }
    }
}
