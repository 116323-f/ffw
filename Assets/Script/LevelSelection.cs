using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button[] buttons;
    public GameObject levelButtons;

    private void Awake()
    {
        //run ButtonsToArray first
        ButtonsToArray();
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

    //return to main menu
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    void ButtonsToArray()
    {
        //set size of button array equal to number of child objects of levelButtons object
        int childCount = levelButtons.transform.childCount;
        buttons = new Button [childCount];
        //assign button component of levelButtons object's children to the buttons array in order
        for (int i = 0; i < childCount; i++)
        {
            buttons[i] = levelButtons.transform.GetChild(i).gameObject.GetComponent<Button>();
        }

    }

}
