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
        //라운드가 0 이하가 되는 것을 방지
        gameStage = Mathf.Max(1, gameStage -1);
    }


}
