public class Experience {
    
    private int current_experience;
    private int level;
    private int max_experience_level;

    public Experience() {
        current_experience = 0;
        level = 1;
        max_experience_level = 10;
    }

    public void GainExp(int value) {
        current_experience += value;
    }

    private void LevelUp() {

    }
}