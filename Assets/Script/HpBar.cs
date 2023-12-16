using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Image hpBar;

    public Transform character; // 추적할 캐릭터
    public Vector3 offset; // HP 바와 캐릭터 사이의 오프셋

    private Camera cam; // 카메라 참조

    private void Start()
    {
        cam = Camera.main; // 메인 카메라 참조
    }
    private void Update()
    {
        if (character != null)
        {
            // 캐릭터의 월드 좌표를 화면 좌표로 변환
            Vector3 screenPosition = cam.WorldToScreenPoint(character.position + offset);

            // HP 바의 위치를 캐릭터의 위치에 맞춤
            hpBar.transform.position = screenPosition;
        }
    }
}
