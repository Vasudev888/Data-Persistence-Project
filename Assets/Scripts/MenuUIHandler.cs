using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    [SerializeField]public InputField inputField;
    [SerializeField]public Text bestScoreText;


    private void Awake()
    {
        bestScoreText.text = "BestScore: " + GameManager.instance.bestScoreName + " :" + GameManager.instance.bestScore;
    }

    public void StartGame()
    {
        GameManager.instance.currentName = inputField.text;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        GameManager.instance.SaveBestScore();

        EditorApplication.ExitPlaymode();

        Application.Quit();
    }

}
