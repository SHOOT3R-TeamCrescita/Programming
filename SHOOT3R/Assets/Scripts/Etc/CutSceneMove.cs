using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutSceneMove : MonoBehaviour
{
    [SerializeField] Transform stop;
    [SerializeField] Image Fade;
    public static bool isEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeOut());
        isEnd = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(gameObject.transform.position,stop.position,0.025f);
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(3.0f);

        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            Fade.color = new Color(0, 0, 0, fadeCount);
        }
        isEnd = false;
        SceneManager.LoadScene(3);
    }
}
