public class Stats {
    
    private int points_to_distribute;
    private int strenght;

    public Stats() { 
        points_to_distribute = 0;       
        strenght = 1;
    }

    public void AddStrenght(int value) {
        strenght += value;
    }

    public void AddPointsToDistribute(int points) {
        points_to_distribute += points;
    }
}