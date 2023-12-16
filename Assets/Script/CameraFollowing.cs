using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraFollowing : MonoBehaviour
{

    private Vector3 leftPosition = new Vector3(-20, 0, 0);
    private Vector3 rightPosition = new Vector3(20, 0, 0);

    private Vector3 offset = new Vector3(0f, -0.5f, -10f);
    private float smoothTime = 0.125f;
    private Vector3 velocity = Vector3.zero;

    private Transform target;
    private bool isFollowingAlly = true; // �Ʊ��� ���󰡰� �ִ��� ����

    private void Start()
    {
        StartCoroutine(TargetUpdateRoutine());
    }

    private IEnumerator TargetUpdateRoutine()
    {
        while (true)
        {
            UpdateTarget();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void UpdateTarget()
    {
        Transform newTarget = isFollowingAlly ? FindRightMostAlly() : FindLeftMostEnemy();

        if (newTarget != null)
        {
            target = newTarget;
        }
        else if (isFollowingAlly) // �Ʊ��� ������ ������ Ÿ������ ����
        {
            isFollowingAlly = false;
            target = FindLeftMostEnemy();
        }

        if (target == null && !isFollowingAlly) // �Ʊ��� ���� ��� ���� ���
        {
            ReturnStage(); // ReturnStage �Լ� ȣ��
        }

    }

    private Transform FindRightMostAlly()
    {
        GameObject[] allies = GameObject.FindGameObjectsWithTag("Mercenary");
        Transform rightMost = null;
        float rightMostX = float.MinValue;

        foreach (GameObject ally in allies)
        {
            if (ally.transform.position.x > rightMostX)
            {
                rightMost = ally.transform;
                rightMostX = ally.transform.position.x;
            }
        }

        return rightMost;
    }

    private Transform FindLeftMostEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Transform leftMost = null;
        float leftMostX = float.MaxValue;

        foreach (GameObject enemy in enemies)
        {
            if (enemy.transform.position.x < leftMostX)
            {
                leftMost = enemy.transform;
                leftMostX = enemy.transform.position.x;
            }
        }

        return leftMost;
    }

    void Update()
    {
        if (target != null)
        {
            if (leftPosition.x <= target.position.x  && target.position.x <= rightPosition.x ) {
                Vector3 cameraOffset = isFollowingAlly ? new Vector3(3f, 0, 0) : new Vector3(-3f, 0, 0);

                Vector3 targetPosition = target.position + offset + cameraOffset;
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            }
        }
    }

    public void ReturnStage()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        GameManager.Instance.SubStage();
        GameManager.Instance.ChangeScene(sceneName);
    }
}
