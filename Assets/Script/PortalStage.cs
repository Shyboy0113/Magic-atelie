using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalStage : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            StartCoroutine(ChangeStageRoutine(false));
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Mercenary"))
        {
            StartCoroutine(ChangeStageRoutine(true));
        }
    }

    private IEnumerator ChangeStageRoutine(bool next)
    {
        Debug.Log("페이드 아웃");
        // 페이드 아웃을 시작합니다.
        GameManager.Instance.FadeOut();

        // 1초 기다립니다.
        yield return new WaitForSeconds(1.0f);

        // 장면 변경
        if (next)
        {
            Debug.Log("다음 씬");
            nextStage();
        }
        else
        {
            Debug.Log("이전 씬");
            beforeStage();
        }

        // 페이드 인을 시작합니다.
        GameManager.Instance.FadeIn();
    }

    private void nextStage()
    {
        GameManager.Instance.AddStage();
        GameManager.Instance.ChangeScene(sceneName);
    }

    private void beforeStage()
    {
        GameManager.Instance.SubStage();
        GameManager.Instance.ChangeScene(sceneName);
    }
}
