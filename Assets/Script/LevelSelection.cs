using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button[] buttons;

    private void Awake()
    {
        //first level unlocked when game is first launched
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        //for loop to disable interactable property of all buttons
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        //for loop to re-enable interactive property of buttons equal to number of unlocked levels
        for (int i = 0;i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void OpenLevel (int levelId)
    {
        //send ID of level as parameter
        string levelName = "Level " + levelId;
        //load level
        SceneManager.LoadSceneAsync(levelName);
    }
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

}
