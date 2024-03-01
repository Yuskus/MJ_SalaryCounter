using UnityEngine;

public class MainPage : MonoBehaviour
{
    private GameObject Panel3;
    private void Start()
    {
        Panel3 = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(7).gameObject;
        Panel3.SetActive(false);
    }

    public void ClosePanel3()
    {
        if (!Panel3.activeInHierarchy) { Panel3.SetActive(true); }
        else { Panel3.SetActive(false); }
    }
}
