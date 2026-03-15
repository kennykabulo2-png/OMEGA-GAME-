using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    // Singleton instance
    public static UIManager Instance;

    // UI Panels
    [Header("Panels")]
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;
    public GameObject gameplayPanel;

    // Buttons
    [Header("Buttons")]
    public Button playButton;
    public Button settingsButton;
    public Button backButton;

    // UI States
    private Dictionary<string, GameObject> panels;

    void Awake()
    {
        // Implement Singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Initialize panels
        panels = new Dictionary<string, GameObject>
        {
            { "MainMenu", mainMenuPanel },
            { "Settings", settingsPanel },
            { "Gameplay", gameplayPanel }
        };

        // Set initial panel
        ShowPanel("MainMenu");

        // Button listeners
        playButton.onClick.AddListener(OnPlayButtonClicked);
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        backButton.onClick.AddListener(OnBackButtonClicked);
    }

    public void ShowPanel(string panelName)
    {
        // Hide all panels
        foreach (var panel in panels.Values)
        {
            panel.SetActive(false);
        }

        // Show the requested panel
        if (panels.ContainsKey(panelName))
        {
            panels[panelName].SetActive(true);
        }
        else
        {
            Debug.LogError("Panel not found: " + panelName);
        }
    }

    private void OnPlayButtonClicked()
    {
        ShowPanel("Gameplay");
    }

    private void OnSettingsButtonClicked()
    {
        ShowPanel("Settings");
    }

    private void OnBackButtonClicked()
    {
        ShowPanel("MainMenu");
    }
}