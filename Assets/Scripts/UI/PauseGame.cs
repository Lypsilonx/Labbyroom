using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PauseGame : MonoBehaviour
{
    Menu pauseMenu;
    private string startScene = "Start";

    private void Awake()
    {
        pauseMenu = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerController>().settings.GetMenu("PauseMenu");
        
        pauseMenu.OpenMenu = PauseTime;
        pauseMenu.CloseMenu = ResumeTime;

        GameObject.Find("UI/PauseMenu(Clone)/MenuButton").GetComponent<Button>().onClick.AddListener(() => {
            LoadMenu();
        });
        GameObject.Find("UI/PauseMenu(Clone)/SaveInput").GetComponent<InputField>().onEndEdit.AddListener((string value) => {
            if (value != "")
            {
                SaveGame(value);
            }
        });
        GameObject.Find("UI/PauseMenu(Clone)/QuitButton").GetComponent<Button>().onClick.AddListener(() => {
            QuitGame();
        });
    }

    private void PauseTime() { Time.timeScale = 0.0f; }
    private void ResumeTime() { Time.timeScale = 1.0f; }

    public void LoadMenu()
    {
        Time.timeScale = 1.0f;
        if(SceneLoader.loadedFile)
            SceneLoader.loadedFile.data = SceneLoader.SeriaizeGameData();
        else
        {
            SaveFile sf = SceneLoader.loadedFile = new SaveFile();
            sf.name = "Quicksave";
            sf.data = SceneLoader.SeriaizeGameData();
        }
        SceneManager.LoadScene(startScene);
    }

    public void SaveGame(string name)
    {
        Debug.Log("saving: " + name);
        string data = SceneLoader.SeriaizeGameData();

        string destination = Application.persistentDataPath + "/" + name + ".save";

        File.WriteAllText(destination, data);
    }

    public void QuitGame()
    {
        Utility.QuitGame();
    }
}
