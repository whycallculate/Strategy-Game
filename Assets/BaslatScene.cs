using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BaslatScene : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Image LoadingBarFill;


    public void ExitGames()
    {
        Application.Quit();
    }
    public void LoadScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);

    }
    public void LoadSceneAndLoadSave(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
        SaveManager.Instance.LoadFromJson();
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
        LoadingScreen.SetActive(true);

        while(!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            LoadingBarFill.fillAmount = progressValue;
            yield return null;
        }
    }





}
