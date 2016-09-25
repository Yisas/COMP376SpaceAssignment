using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

    public AudioSource sceneChangeAudiosource;
    public float delayInterval;
    public bool cursorVisible;

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneEnumerator(sceneName));
    }

    private IEnumerator LoadSceneEnumerator(string sceneName)
    {
        sceneChangeAudiosource.Play();
        Cursor.visible = cursorVisible;
        yield return new WaitForSeconds(delayInterval);
        SceneManager.LoadScene(sceneName);
    }
}
