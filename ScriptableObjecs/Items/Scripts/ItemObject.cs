using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Food,
    Charm,
    Armor,
    Weapon,
    Default
}

public enum Attributes
{
    Rating,
    Health,
    Stamina,
    Armor,
    Damage,
    Evasion

}
public abstract class ItemObject : ScriptableObject
{
    public Sprite uiDisplay;
    public bool stackable;
    public ItemType type;
    public string Name;
    [TextArea(15,20)]
    public string description;
    public Item data = new Item();

    public Item CreateItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }
}

[System.Serializable]
public class Item
{
    public string NameId;
    public int Id = -1;
    public ItemBuff[] buffs;
    public Item()
    {
        NameId = "";
        Id = -1;
    }
    public Item(ItemObject item)
    {
        NameId = item.name;
        Id = item.data.Id;
        buffs = new ItemBuff[item.data.buffs.Length];
        for (int i = 0; i < buffs.Length; i++)
        {
            buffs[i] = new ItemBuff(item.data.buffs[i].min, item.data.buffs[i].max)
            {
                attribute = item.data.buffs[i].attribute
            };
        }
    }
}

[System.Serializable]
public class ItemBuff : IModifiers
{
    //public string statsType;
    public Attributes attribute;
    public int value;
    public int min;
    public int max;
    public ItemBuff(int _min, int _max)
    {
        min = _min;
        max = _max;
        GenerateValue();
    }

    public void AddValue(ref int baseValue)
    {
        baseValue += value;
        //AddtoStats(statsType);
    }

    /*
    public void AddtoStats(string statsType)
    {
        Debug.Log("ItemType: " + statsType);
        Debug.Log("Attribute: " + attribute + " Value: " + value);
        switch (statsType)
        {
            case "Charm":
                switch (attribute)
                {
                    case Attributes.Rating:
                        break;
                    case Attributes.Health:
                        PlayerAccount.healthCharms = value;
                        Debug.Log("Health Charm: " + PlayerAccount.healthCharms);
                        break;
                    case Attributes.Stamina:
                        PlayerAccount.staminaCharms = value;
                        Debug.Log("Health Charm: " + PlayerAccount.staminaCharms);
                        break;
                    case Attributes.Armor:
                        PlayerAccount.armorCharms = value;
                        Debug.Log("Health Charm: " + PlayerAccount.armorCharms);
                        break;
                    case Attributes.Damage:
                        PlayerAccount.damageCharms = value;
                        Debug.Log("Health Charm: " + PlayerAccount.damageCharms);
                        break;
                    case Attributes.Evasion:
                        PlayerAccount.evasionCharms = value;
                        Debug.Log("Health Charm: " + PlayerAccount.evasionCharms);
                        break;
                    default:
                        break;
                }
                break;

            case "Armor":
                switch (attribute)
                {
                    case Attributes.Rating:
                        break;
                    case Attributes.Health:
                        PlayerAccount.healthArmor = value;
                        Debug.Log("Health Charm: " + PlayerAccount.healthArmor);
                        break;
                    case Attributes.Stamina:
                        PlayerAccount.staminaArmor = value;
                        Debug.Log("Health Charm: " + PlayerAccount.staminaArmor);
                        break;
                    case Attributes.Armor:
                        PlayerAccount.armorArmor = value;
                        Debug.Log("Health Charm: " + PlayerAccount.armorArmor);
                        break;
                    case Attributes.Damage:
                        PlayerAccount.damageArmor = value;
                        Debug.Log("Health Charm: " + PlayerAccount.damageArmor);
                        break;
                    case Attributes.Evasion:
                        PlayerAccount.evasionArmor = value;
                        Debug.Log("Health Charm: " + PlayerAccount.evasionArmor);
                        break;
                    default:
                        break;
                }
                break;

            case "Weapon":
                switch (attribute)
                {
                    case Attributes.Rating:
                        break;
                    case Attributes.Health:
                        PlayerAccount.healthWeapon = value;
                        Debug.Log("Health Charm: " + PlayerAccount.healthWeapon);
                        break;
                    case Attributes.Stamina:
                        PlayerAccount.staminaWeapon = value;
                        Debug.Log("Health Charm: " + PlayerAccount.staminaWeapon);
                        break;
                    case Attributes.Armor:
                        PlayerAccount.armorWeapon = value;
                        Debug.Log("Health Charm: " + PlayerAccount.armorWeapon);
                        break;
                    case Attributes.Damage:
                        PlayerAccount.damageWeapon = value;
                        Debug.Log("Health Charm: " + PlayerAccount.damageWeapon);
                        break;
                    case Attributes.Evasion:
                        PlayerAccount.evasionWeapon = value;
                        Debug.Log("Health Charm: " + PlayerAccount.evasionWeapon);
                        break;
                    default:
                        break;
                }
                break;

            default:
                break;
        }
    }
    */

    public void GenerateValue()
    {
        value = UnityEngine.Random.Range(min, max);
    }
}
