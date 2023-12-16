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

    // UI ����
    public Image hpBar; // HP �ٸ� ���� �̹���

    private void Start()
    {
        currentHp = maxHp;
        currentMp = maxMp;
        currentAtk = maxAtk;
        currentMagic = maxMagic;

        InitializeHpBar(); // HP �� �ʱ�ȭ
    }

    private void InitializeHpBar()
    {
        if (hpBar != null)
        {
            hpBar.fillAmount = (float)currentHp / maxHp; // �ִ� HP�� ���� ���� HP�� ����
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHp -= damageAmount;
        UpdateHpBar(); // HP �� ������Ʈ

        Debug.Log($"{characterName}�� {damageAmount} ��ŭ�� �������� �Ծ����ϴ�. ���� ü�� : {currentHp}");

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
            hpBar.fillAmount = (float)currentHp / maxHp; // HP �ٸ� ���� HP ������ ������Ʈ
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

}
