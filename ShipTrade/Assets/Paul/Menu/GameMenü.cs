using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenü : MonoBehaviour
{
    public GameObject Menü; // Das Menü-Panel, das im Inspector zugewiesen wird

    public bool isMenuActive = false;

    void Update()
    {
        // Überprüft, ob die Escape-Taste gedrückt wurde
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Wechselt den Zustand des Menüs (ein/aus)
            isMenuActive = !isMenuActive;
            Menü.SetActive(isMenuActive);

            // Pausiere das Spiel, wenn das Menü aktiv ist
            Time.timeScale = isMenuActive ? 0 : 1;
        }
    }
    public void Setunfrozen()
    {
        isMenuActive = false;
        Time.timeScale = isMenuActive ? 0 : 1;
    }
}
