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
            Debug.Log("Ÿ�Ӿƿ��Ǿ����ϴ�.");
            timeRemaining.text = "���� �ð� : 0";

            GameManager.Instance.SubStage();

            string sceneName = SceneManager.GetActiveScene().name;
            GameManager.Instance.ChangeScene(sceneName);

        }
        else
        {
            timeRemaining.text = "���� �ð� : " + limitTime.ToString("F2");
        }

        limitTime -= Time.deltaTime;

    }

}
