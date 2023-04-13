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

}