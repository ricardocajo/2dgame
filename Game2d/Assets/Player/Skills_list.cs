using System.Collections.Generic;

public class Skills_list {

//Skill name -> Skill properties
public static Dictionary<string, Dictionary<string,float>> skills = new Dictionary<string, Dictionary<string,float>> {

    {"skill1", new Dictionary<string, float>{
        {"damage", 10f},
        {"mana", 10f},
        {"movement", 10f},
        {"selfdamage", 10f},
        {"buff", 10f}
    }},
    {"skill2", new Dictionary<string, float>{
        {"damage", 20f},
        {"mana", 20f},
        {"movement", 10f},
        {"selfdamage", 10f},
        {"buff", 10f}
    }},
    {"skill3", new Dictionary<string, float>{
        {"damage", 30f},
        {"mana", 30f},
        {"movement", 10f},
        {"selfdamage", 10f},
        {"buff", 10f}
    }},
    {"skill4", new Dictionary<string, float>{
        {"damage", 40f},
        {"mana", 10f},
        {"movement", 10f},
        {"selfdamage", 10f},
        {"buff", 10f}
    }},
    {"skill5", new Dictionary<string, float>{
        {"damage", 0f},
        {"mana", 10f},
        {"movement", 10f},
        {"selfdamage", 10f},
        {"buff", 10f}
    }},
    {"skill6", new Dictionary<string, float>{
        {"damage", 50f},
        {"mana", 10f},
        {"movement", 10f},
        {"selfdamage", 10f},
        {"buff", 10f}
    }}
    
};
}