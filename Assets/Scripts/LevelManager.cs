using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{

    public float autoLoadNextLevelAfter; //in seconds

    void Start()
    {
        if (autoLoadNextLevelAfter <= 0)
        {
            //Debug.Log ("Level Autoload disabled");
        }
        else
        {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Physics.gravity = new Vector3(0f, -2f, 0f);
        }
    }


    public void LoadLevel(string name)
    {
        //Debug.Log ("New Level load: " + name);
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        //Debug.Log ("Quit requested");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Update()
    {
        
    }

}


//  \n
//  <>