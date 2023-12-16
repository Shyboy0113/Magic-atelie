using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goBeforeRound : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            GameManager.Instance.SubStage();
            GameManager.Instance.ChangeScene(sceneName);
        }

    }

}
