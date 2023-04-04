using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private Image hpBar_image;
    private Image manaBar_image;

    void Start()
    {
        hpBar_image = gameObject.transform.Find("Health_bar").gameObject.GetComponent<Image>();
        manaBar_image = gameObject.transform.Find("Mana_bar").gameObject.GetComponent<Image>();
        GameEvents.Instance.onPlayerHpLost += DecreaseHpBar;
        GameEvents.Instance.onPlayerManaLost += DecreaseManaBar;
    }

    private void DecreaseHpBar()
    {
        hpBar_image.fillAmount -= GameEvents.Instance.GetPlayerIncDamageValue() / 100;
    }

    private void DecreaseManaBar()
    {
        manaBar_image.fillAmount -= GameEvents.Instance.GetManaValue() / 100;
    }
}
