using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public bool isRight;
    public Vector3 newPosition;

    public string sceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isRight is true)
        {
            if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                collision.gameObject.transform.position = newPosition;
            }
        }
        else
        {
            if(collision.gameObject.layer == LayerMask.NameToLayer("Mercenary"))
            {

            }
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
