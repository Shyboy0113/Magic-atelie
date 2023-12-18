using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ShowStageText : MonoBehaviour
{
    public TMP_Text roundText;
    public TMP_Text timeRemaining;

    void Update()
    {
        roundText.text = "Stage : " + GameManager.Instance.gameStage.ToString();

        if (GameManager.Instance.limitTime <= 0f)
        {
            Debug.Log("타임아웃되었습니다.");
            timeRemaining.text = "남은 시간 : 0";

            GameManager.Instance.SubStage();

            string sceneName = SceneManager.GetActiveScene().name;
            GameManager.Instance.ChangeScene(sceneName);

        }
        else
        {
            timeRemaining.text = "남은 시간 : " + GameManager.Instance.limitTime.ToString("F2");
        }

        GameManager.Instance.limitTime -= Time.deltaTime;

    }

}
