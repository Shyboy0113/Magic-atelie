using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ShowRoundText : MonoBehaviour
{
    public TMP_Text roundText;
    public TMP_Text timeRemaining;

    float limitTime;

    private void Start()
    {
        limitTime = 30.0f;        
    }
    void Update()
    {
        roundText.text = "Round : " + GameManager.Instance.gameStage.ToString();

        if (limitTime <= 0f)
        {
            Debug.Log("타임아웃되었습니다.");
            timeRemaining.text = "남은 시간 : 0";

            GameManager.Instance.SubStage();

            string sceneName = SceneManager.GetActiveScene().name;
            GameManager.Instance.ChangeScene(sceneName);

        }
        else
        {
            timeRemaining.text = "남은 시간 : " + limitTime.ToString("F2");
        }

        limitTime -= Time.deltaTime;

    }

}
