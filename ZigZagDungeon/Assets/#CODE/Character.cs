using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public enum AbilityScore
{
    STR,
    DEX,
    CON,
    INT,
    WIS,
    CHA

}

public class Character : MonoBehaviour
{
   

    public Character()
        {



   
        }

}

public class Ability
{

    public int abilityScores;


    public AbilityScore ability;

    public Ability(AbilityScore ability, int abilityScore)
    {
        this.ability = ability;
        this.abilityScores = abilityScore;
    }
}