using UnityEngine;
using System.Collections;

public class changeScene : MonoBehaviour {
	
	// Update is called once per frame
	public void changeToScene (int sceneToChangeTo) {

        Application.LoadLevel(sceneToChangeTo);
	}

    public void quitGame()
    {
        Application.Quit();
    }

    public void retryLevel()
    {
        Application.LoadLevel(1);
    }

    public void returnToMenu()
    {
        Application.LoadLevel(0);
    }
}
