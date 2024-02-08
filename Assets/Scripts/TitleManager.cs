using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public static TitleManager instance;
    public static bool eZMode;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(SceneManager.GetActiveScene().name + ":START");
        eZMode = false;

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartStage(string stageNum)
    {
        SceneManager.LoadSceneAsync("Stage" + stageNum);
    }

    public void EZMode()
    {
        eZMode = true;
    }

}