public class Equipment {
    
    private Item weapon;
    private Item armor;
    private Item boots;

    public Equipment() {
        weapon = null;
        armor = null;
        boots = null;
    }

    public void SetWeapon(Item new_weapon) {
        weapon = new_weapon;
    }

    public void SetArmor(Item new_armor) {
        armor = new_armor;
    }

    public void SetBoots(Item new_boots) {
        boots = new_boots;
    }
}