using System.Collections.Generic;

public class Skills_list {

//Skill name -> Skill properties
public static Dictionary<string, Dictionary<string,float>> skills = new Dictionary<string, Dictionary<string,float>> {

    {"attack_1", new Dictionary<string, float>{
        {"damage", 20f},
        {"mana", 2f},
        {"movement", 0f},
        {"selfdamage", 0f},
        {"buff", 0f}
    }},
    {"attack_2", new Dictionary<string, float>{
        {"damage", 10f},
        {"mana", 1f},
        {"movement", 0f},
        {"selfdamage", 0f},
        {"buff", 0f}
    }},
    {"roll", new Dictionary<string, float>{
        {"damage", 0f},
        {"mana", 10f},
        {"movement", 10f},
        {"selfdamage", 0f},
        {"buff", 0f}
    }},
    {"skill_1", new Dictionary<string, float>{
        {"damage", 40f},
        {"mana", 20f},
        {"movement", 10f},
        {"selfdamage", 10f},
        {"buff", 0f}
    }},
    {"skill_2", new Dictionary<string, float>{
        {"damage", 40f},
        {"mana", 16f},
        {"movement", 0f},
        {"selfdamage", 7f},
        {"buff", 0f}
    }},
    {"skill_3", new Dictionary<string, float>{
        {"damage", 50f},
        {"mana", 40f},
        {"movement", 0f},
        {"selfdamage", 0f},
        {"buff", 20f}
    }},
    {"defend", new Dictionary<string, float>{
        {"damage", 0f},
        {"mana", 5f},
        {"movement", 0f},
        {"selfdamage", 0f},
        {"buff", 0f}
    }}
    //TODO maybe add some type of buffs / potion
};
}