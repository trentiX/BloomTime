using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : ScriptableObject
{
    public string skillName;
}

[System.Serializable]
[CreateAssetMenu(fileName = "New Upgrade Skill", menuName = "Create Skill/Upgrade Skill")]
public class Upgrade : Skill
{
    public PlayerStatType playerStatType;
    public float upgradeValue;
}

[System.Serializable]
[CreateAssetMenu(fileName = "New Weapon", menuName = "Create Skill/Weapon")]
public class NewWeapon : Skill
{
    public GameObject weaponPrefab;
    public float weaponAttackCooldown;
}
