using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ShowStageText : MonoBehaviour
{
    public TMP_Text gold;
    public TMP_Text mana;
    public TMP_Text dia;

    void Update()
    {
        gold.text = "Gold : " + GameManager.Instance.gold.ToString();
        mana.text = "Mana : " + GameManager.Instance.mana.ToString();
        dia.text = "Dia : " + GameManager.Instance.diamond.ToString();
    }

}
