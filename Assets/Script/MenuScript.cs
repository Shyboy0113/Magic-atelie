using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        SceneManager.LoadScene("MainPage");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
