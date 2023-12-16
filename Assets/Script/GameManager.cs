using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public int gameStage = 1;

    public void AddStage()
    {
        gameStage += 1;
    }

    public void SubStage()
    {
        //라운드가 0 이하가 되는 것을 방지
        gameStage = Mathf.Max(1, gameStage -1);

    }

    public void ChangeScene(string sceneName)
    {
        if (sceneName is not null) SceneManager.LoadScene(sceneName);

    }


}
