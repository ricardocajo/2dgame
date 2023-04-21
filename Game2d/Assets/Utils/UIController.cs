using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private Image hpBar_image;
    private Image manaBar_image;
    private float player_max_hp;
    private float player_max_mana;

    void Start() {
        hpBar_image = gameObject.transform.Find("Health_bar").gameObject.GetComponent<Image>();
        manaBar_image = gameObject.transform.Find("Mana_bar").gameObject.GetComponent<Image>();
        GameEvents.Instance.onPlayerHpLost += DecreaseHpBar;
        GameEvents.Instance.onPlayerManaChange += ChangePlayerManaBar;
        GameEvents.Instance.onPlayerHpChange += ChangePlayerHpBar;
        player_max_hp = GameEvents.Instance.GetPlayerMaxHp();
        player_max_mana = GameEvents.Instance.GetPlayerMaxMana();
    }

    private void DecreaseHpBar() {
        hpBar_image.fillAmount -= GameEvents.Instance.GetPlayerIncDamageValue() / player_max_hp;
    }

    private void ChangePlayerManaBar() {
        manaBar_image.fillAmount = GameEvents.Instance.GetManaValue() / player_max_mana;
    }

    private void ChangePlayerHpBar() {
        hpBar_image.fillAmount = GameEvents.Instance.GetPlayerHpValue() / player_max_hp;
    }
}
