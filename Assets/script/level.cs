using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class level : MonoBehaviour
{
    int levelno;
    // Start is called before the first frame update
    void Start()
    {
        levelno = PlayerPrefs.GetInt("levelno", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void levelchange(int levelno)
    {
        PlayerPrefs.SetInt("levelno", levelno);
        SceneManager.LoadScene("l"+levelno);
    }
}
