using UnityEngine;

[CreateAssetMenu(fileName = "Weapons", menuName = "Scriptable Objects/Weapons")]
public class Weapons : ScriptableObject
{
    [Header("weapon information")]
    public string weaponName;
    public int damage;
    public float range;
    public Sprite icon;

}
