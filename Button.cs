using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void ButtonRulesPressed()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void ButtonPredictionPressed()
    {
        SceneManager.LoadScene("Scene2");
    }

    public void ButtonPerOnePressed()
    {
        SceneManager.LoadScene("Scene3");
    }

    public void ButtonPerAllPressed()
    {
        SceneManager.LoadScene("Scene4");
    }

    public void ButtonBackPressed()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Quit()
    {
        Application.Quit();
        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
            activity.Call("finishAndRemoveTask");
        }
    }
}
