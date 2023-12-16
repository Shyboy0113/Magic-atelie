using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Image hpBar;

    public Transform character; // ������ ĳ����
    public Vector3 offset; // HP �ٿ� ĳ���� ������ ������

    private Camera cam; // ī�޶� ����

    private void Start()
    {
        cam = Camera.main; // ���� ī�޶� ����
    }
    private void Update()
    {
        if (character != null)
        {
            // ĳ������ ���� ��ǥ�� ȭ�� ��ǥ�� ��ȯ
            Vector3 screenPosition = cam.WorldToScreenPoint(character.position + offset);

            // HP ���� ��ġ�� ĳ������ ��ġ�� ����
            hpBar.transform.position = screenPosition;
        }
    }
}
