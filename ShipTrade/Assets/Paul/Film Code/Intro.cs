using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Image fadeImage; // Das schwarze UI-Image
    public string Scenename;
    public float fadeDuration = 2.0f; // Dauer des Fade-Effekts

    private bool isFading = false;
    // Start is called before the first frame update
    void Start()
    {
        // Setze das Image-Alpha auf 0 (vollständig transparent)
        fadeImage.color = new Color(0, 0, 0, 0);

        videoPlayer.loopPointReached += OnVideoEnd;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Starte den Fade-Effekt
        StartCoroutine(FadeOut());

    }

    IEnumerator FadeOut()
    {
        isFading = true;
        float elapsedTime = 0f;

        // Fahre das Alpha des Images hoch
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        // Szene laden
        SceneManager.LoadScene(Scenename);
    }
}
