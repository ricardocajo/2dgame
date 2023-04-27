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
        if(current_experience >= max_experience_level) {
            LevelUp();
        }
    }

    private void LevelUp() {
        current_experience -= max_experience_level;
        max_experience_level *= 3;
        level += 1;
    }

    public int GetLevel() {
        return level;
    }
}