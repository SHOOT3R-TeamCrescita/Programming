using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public static int nextScene;
    public static float loadWait;

    [SerializeField] GameObject Load;
    [SerializeField] GameObject Btn;

    private AsyncOperation async;
    private bool next;

    float timer;

    private void Start()
    {
        Time.timeScale = 1f;
        next = false;
        StartCoroutine(LoadScene(loadWait));
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    public static void LoadScene(int sceneName, float watTime)
    {
        nextScene = sceneName;
        loadWait = watTime;

        SceneManager.LoadScene("Loading");
    }
    public void NextBtn()
    {
        next = true;
    }

    IEnumerator LoadScene(float waitTime)
    {
        timer = 0f;

        while (timer < waitTime)
        {
            Debug.Log(timer);
            
            yield return null;
        }
        
        async = SceneManager.LoadSceneAsync(nextScene);
        async.allowSceneActivation = false;

        

        Btn.SetActive(true);
        Load.SetActive(false);

        while(!async.isDone)
        {
            yield return true;

            if(next)
                async.allowSceneActivation = true;
        }
    }
}

/*float timer = 0.0f;

while (!op.isDone)
{
    yield return null;

    timer += Time.deltaTime;
    if (op.progress < 0.9f)
    {
        progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);

        if (progressBar.fillAmount >= op.progress)
        {
            timer = 0f;
        }
    }
    else
    {
        pregress.text = op.progress.ToString();
        progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 0.9f, timer);
        if (progressBar.fillAmount == 1.0f) 
        { 
            op.allowSceneActivation = true; 
            yield break; 
        }
    }
}*/

