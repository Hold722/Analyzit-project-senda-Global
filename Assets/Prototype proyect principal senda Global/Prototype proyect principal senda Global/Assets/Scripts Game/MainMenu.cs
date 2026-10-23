using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Menu Panels")]
    public GameObject mainmenu;
    public GameObject optionsMenu;

    // Open the options panel and hide main menu
    public void OpenOptions()
    {
        mainmenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    // Close the options panel and return to main menu
    public void CloseOptionsPanel()
    {
        mainmenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    // Load the first level of the game
    public void PlayGame()
    {
        // Fixed the typo with the extra quote character
        SceneManager.LoadScene("Level1");
    }

    // Quit the application
    public void ExitGame()
    {
        Application.Quit();
        // Useful for testing inside the Unity Editor
        Debug.Log("Game Exited successfully.");
    }
}