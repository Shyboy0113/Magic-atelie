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
        Debug.Log("���̵� �ƿ�");
        // ���̵� �ƿ��� �����մϴ�.
        GameManager.Instance.FadeOut();

        // 1�� ��ٸ��ϴ�.
        yield return new WaitForSeconds(1.0f);

        // ��� ����
        if (next)
        {
            Debug.Log("���� ��");
            nextStage();
        }
        else
        {
            Debug.Log("���� ��");
            beforeStage();
        }

        // ���̵� ���� �����մϴ�.
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
