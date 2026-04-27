using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private Label myLabel;
    private VisualElement Settings;
    private VisualElement Credits;

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        myLabel = root.Q<Label>("myLabel");
        Settings = root.Q<VisualElement>("Settings");
        Credits = root.Q<VisualElement>("Credits");

        root.Q<Button>("PlayBtn").clicked += PlayBtnClicked;
        root.Q<Button>("SettingsBtn").clicked += SettingsBtnClicked;
        root.Q<Button>("CreditsBtn").clicked += CreditsBtnClicked;
        root.Q<Button>("SettingsBack").clicked += SettingsBackClicked;
        root.Q<Button>("CreditsBack").clicked += CreditsBackClicked;
    }

    void PlayBtnClicked()
    {
        SceneManager.LoadScene("GameScene");
    }
    void SettingsBtnClicked()
    {
        Settings.style.display = DisplayStyle.Flex;
    }
    void CreditsBtnClicked()
    {
        Credits.style.display = DisplayStyle.Flex;
    }
    void SettingsBackClicked()
    {
        Settings.style.display = DisplayStyle.None;
    }
    void CreditsBackClicked()
    {
        Credits.style.display = DisplayStyle.None;
    }
}
