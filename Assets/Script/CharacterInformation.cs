using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInformation : MonoBehaviour
{

    public string characterName;

    public int currentHp;
    public int currentMp;

    public int currentAtk;
    public int currentMagic;

    public int maxHp;
    public int maxMp;
    public int maxAtk;
    public int maxMagic;

    // UI 관련
    public Image hpBar; // HP 바를 위한 이미지

    private void Start()
    {
        currentHp = maxHp;
        currentMp = maxMp;
        currentAtk = maxAtk;
        currentMagic = maxMagic;

        InitializeHpBar(); // HP 바 초기화
    }

    private void InitializeHpBar()
    {
        if (hpBar != null)
        {
            hpBar.fillAmount = (float)currentHp / maxHp; // 최대 HP에 대한 현재 HP의 비율
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHp -= damageAmount;
        UpdateHpBar(); // HP 바 업데이트

        Debug.Log($"{characterName}가 {damageAmount} 만큼의 데미지를 입었습니다. 남은 체력 : {currentHp}");

        if (currentHp <= 0)
        {
            currentHp = 0;
            Die();
        }
    }

    private void UpdateHpBar()
    {
        if (hpBar != null)
        {
            hpBar.fillAmount = (float)currentHp / maxHp; // HP 바를 현재 HP 값으로 업데이트
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

}
