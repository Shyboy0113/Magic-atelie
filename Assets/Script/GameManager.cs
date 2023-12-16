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
        //���尡 0 ���ϰ� �Ǵ� ���� ����
        gameStage = Mathf.Max(1, gameStage -1);

    }

    public void ChangeScene(string sceneName)
    {
        if (sceneName is not null) SceneManager.LoadScene(sceneName);

    }


}
