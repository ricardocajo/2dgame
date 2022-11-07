using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    Image hpBar_image;
    GameObject mana_bar;

    void Start()
    {
        hpBar_image = gameObject.transform.Find("Health_bar").gameObject.GetComponent<Image>();
        mana_bar = gameObject.transform.Find("Mana_bar").gameObject;
        GameEvents.Instance.onPlayerHpLost += DecreaseHpBar;
    }

    private void DecreaseHpBar()
    {
        hpBar_image.fillAmount -= GameEvents.Instance.GetDamageValue() / 100;
    }
}
