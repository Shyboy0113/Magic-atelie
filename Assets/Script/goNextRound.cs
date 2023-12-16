using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goNextRound : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Mercenary"))
        {
            GameManager.Instance.AddStage();
            GameManager.Instance.ChangeScene(sceneName);
        }

    }

}
