using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    private int gameStage = 1;

    public void AddStage()
    {
        gameStage += 1;
    }

    public void SubStage()
    {
        //���尡 0 ���ϰ� �Ǵ� ���� ����
        gameStage = Mathf.Max(1, gameStage -1);
    }


}
