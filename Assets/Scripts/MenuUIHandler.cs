using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public TextMeshProUGUI highScoreText;

    public void NewPlayerNameEntered(string name)
    {
        GameManager.Instance.playerName = name;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerNameInput.onEndEdit.AddListener(NewPlayerNameEntered);
        playerNameInput.text = GameManager.Instance.playerName;
        highScoreText.text = GameManager.Instance.GetHighScoreMessage();
    }

    public void StartNew()
    {
        if (playerNameInput.text != "")
        {
            SceneManager.LoadScene(1);
        }
    }

    public void Exit()
    {
        GameManager.Instance.SaveHighScore();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
