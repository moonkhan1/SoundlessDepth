using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public AudioSource _mainTheme;
    public AudioSource _bubbleTheme;
    float _currenttime = 0f;
    float _playTime = 3f;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start() {
        _bubbleTheme.Play();
        _mainTheme.Play();
       
    }

    // Update is called once per frame
    void Update()
    {   
            

        
    }

    public void LoadScene(string name)
        {
            StartCoroutine(LoadLevel(name));
        }

        IEnumerator LoadLevel(string name)
        {
            yield return SceneManager.LoadSceneAsync(name);
            
        }

        
}
