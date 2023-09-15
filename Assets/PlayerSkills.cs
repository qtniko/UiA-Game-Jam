using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    public enum SkillType
    {
        Bomb,
    }
    private List<SkillType> unlockedList;
    public PlayerSkills()
    {
        unlockedList = new List<SkillType>();
    }
    public void UnlockBomb()
    {
        //gameObject.BombAbility.enabled = true;
        
    }
    
}
