using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    Controls controls;
    public bool pause;
    public bool reload;

    private void Awake()
    {
        Time.timeScale = 1f;
        if (gm == null)
        {
            gm = this;
        }
        controls = new Controls();
        controls.UI.Reload.performed += _ => Reload();
        controls.UI.Pause.performed += _ => Pause();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Pause()
    {
        pause = true;
    }

    private void Reload()
    {
        reload = true;
    }

    public void LevelSelect(string name)
    {
        StartCoroutine(WaitforLoadingNextScene(name));
    }

    public void LevelSelectWithoutDelay(string name)
    {
        StartCoroutine(WaitforLoadingNextScene(name, 0f));
    }

    public void LevelSelect(int index, float timetoWait = 1f)
    {
        StartCoroutine(WaitforLoadingNextScene(index, timetoWait));
    }

    public void LevelSelect(string name, float timetoWait = 1f)
    {
        StartCoroutine(WaitforLoadingNextScene(name, timetoWait));
    }


    IEnumerator WaitforLoadingNextScene(int sceneIndex, float timetoWait = 1f)
    {
        yield return new WaitForSecondsRealtime(timetoWait);
        Debug.Log($"Scene number is {sceneIndex}");
        SceneManager.LoadScene(sceneIndex);
    }

    IEnumerator WaitforLoadingNextScene(string sceneName, float timetoWait = 1f)
    {
        yield return new WaitForSecondsRealtime(timetoWait);
        Debug.Log($"Scene name is {sceneName}");
        SceneManager.LoadScene(sceneName);
    }
}
