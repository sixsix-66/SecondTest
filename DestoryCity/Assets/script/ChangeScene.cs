using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnClickto1()
    {
        SceneManager.LoadScene("Scene_1");
    }
    public void OnClickto2()
    {
        SceneManager.LoadScene("Scene_2");
    }
    /*
    public void OnClickto3()
    {
        SceneManager.LoadScene("Scene_3");
    }
    public void OnClickto4()
    {
        SceneManager.LoadScene("Scene_4");
    }
    public void OnClickto5()
    {
        SceneManager.LoadScene("Scene_5");
    }

    */
    // Update is called once per frame
    void Update()
    {
        
    }
}
