using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public InventoryObject equipment;


    public Attribute[] attributes;

    private void Start()
    {

        for (int i = 0; i < attributes.Length; i++)
        {
            attributes[i].SetParent(this);
        }
        for (int i = 0; i < equipment.GetSlots.Length; i++)
        {
            equipment.GetSlots[i].OnBeforeUpdate += OnBeforeSlotUpdate;
            equipment.GetSlots[i].OnAfterUpdate += OnAfterSlotUpdate;
        }
    }

    public void OnBeforeSlotUpdate(InventorySlot _slot)
    {
        //Equipment slot check before update
        if (_slot.ItemObject == null)
            return;

        //Print Removed Equipment Description
        switch (_slot.parent.inventory.type)
        {
            case InterfaceType.Inventory:
                break;
            case InterfaceType.Equipment:
                //print(string.Concat("Removed ", _slot.ItemObject, " on ", _slot.parent.inventory.type, ", Allowed Items: ", string.Join(", ", _slot.AllowedItems)));

                PlayerAccount.equipNameModified = " ";
                PlayerAccount.equipDescModified = " ";

                for (int i = 0; i < _slot.item.buffs.Length; i++)
                {
                    for (int j = 0; j < attributes.Length; j++)
                    {
                        if (attributes[j].type == _slot.item.buffs[i].attribute)
                            attributes[j].value.RemoveModifier(_slot.item.buffs[i]);
                    }
                }

                break;
            default:
                break;
        }
    }
    public void OnAfterSlotUpdate(InventorySlot _slot)
    {
        //Equipment slot check after update
        if (_slot.ItemObject == null)
            return;

        //Print equipped items
        switch (_slot.parent.inventory.type)
        {
            case InterfaceType.Inventory:
                break;
            case InterfaceType.Equipment:
                //print(string.Concat("Placed ", _slot.ItemObject, " on ", _slot.parent.inventory.type, ", Allowed Items: ", string.Join(", ", _slot.AllowedItems)));

                // Print Placed Equipment Description
                /*
                print(string.Concat("Placed ", _slot.ItemObject.type));
                print(string.Concat("Placed ", _slot.ItemObject.description));
                **/

                PlayerAccount.equipNameModified = _slot.ItemObject.Name;
                PlayerAccount.equipDescModified = _slot.ItemObject.description;

                switch (_slot.ItemObject.type)
                {
                    case ItemType.Food:
                        break;
                    case ItemType.Charm:
                        PlayerAccount.currentCharms = _slot.ItemObject.Name;
                        PlayerAccount.descriptionCharms = _slot.ItemObject.description;
                        //Debug.Log("Charm Equipped: " + PlayerAccount.currentCharms);
                        break;
                    case ItemType.Armor:
                        PlayerAccount.currentArmor = _slot.ItemObject.Name;
                        PlayerAccount.descriptionArmor = _slot.ItemObject.description;
                        //Debug.Log("Armor Equipped: " + PlayerAccount.currentArmor);
                        break;
                    case ItemType.Weapon:
                        PlayerAccount.currentWeapon = _slot.ItemObject.Name;
                        PlayerAccount.descriptionWeapon = _slot.ItemObject.description;
                        //Debug.Log("Weapon Equipped: " + PlayerAccount.currentWeapon);
                        break;
                    case ItemType.Default:
                        break;
                    default:
                        break;
                }

                for (int i = 0; i < _slot.item.buffs.Length; i++)
                {
                    for (int j = 0; j < attributes.Length; j++)
                    {
                        if (attributes[j].type == _slot.item.buffs[i].attribute)
                            attributes[j].value.AddModifier(_slot.item.buffs[i]);
                            /*
                            Debug.Log("Name: " + _slot.ItemObject.Name);
                            Debug.Log("Attribute: " + attributes[j].type); // Attribute type
                            Debug.Log("Value: " + _slot.item.buffs[i]);
                            */
                    }
                }
                break;
            default:
                break;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        var item = other.GetComponent<GroundItem>();
        if (item)
        {
            //Debug.Log("Collided!");
            Item _item = new Item(item.item);
            if (inventory.AddItem(_item, 1))
            {
                //Destroy Item Object
                Destroy(other.gameObject);
            }
            Destroy(other.gameObject);
        }
    }

    public void buttonSave()
    {
        inventory.Save();
        equipment.Save();
    }

    public void buttonLoad()
    {
        inventory.Load();
        equipment.Load();
    }

    public void AttributeModified(Attribute attribute)
    {
        //Debug.Log(string.Concat(attribute.type, " was updated! Value is now ", attribute.value.ModifiedValue));

        switch (attribute.type)
        {
            case Attributes.Rating:
                PlayerAccount.ratingModified = attribute.value.ModifiedValue;
                //Debug.Log("Added Health" + attribute.value.ModifiedValue);
                break;
            case Attributes.Health:
                PlayerAccount.modifiedHealth = attribute.value.ModifiedValue;
                PlayerAccount.totalHealth = PlayerAccount.maxHealth + PlayerAccount.modifiedHealth;
                //PlayerAccount.healthModified = attribute.value.ModifiedValue;
                //Debug.Log("Added Health" + attribute.value.ModifiedValue);
                break;
            case Attributes.Stamina:
                PlayerAccount.modifiedStamina = attribute.value.ModifiedValue;
                PlayerAccount.totalStamina = PlayerAccount.maxStamina + PlayerAccount.modifiedStamina;
               // PlayerAccount.staminaModified = attribute.value.ModifiedValue;
                //Debug.Log("Added Stamina" + attribute.value.ModifiedValue);
                break;
            case Attributes.Armor:
                PlayerAccount.modifiedArmor = attribute.value.ModifiedValue;
                PlayerAccount.totalArmor = PlayerAccount.baseArmor + PlayerAccount.modifiedArmor;
                //PlayerAccount.armorModified = attribute.value.ModifiedValue;
                //Debug.Log("Added Armor" + attribute.value.ModifiedValue);
                break;
            case Attributes.Damage:
                PlayerAccount.modifiedDamage = attribute.value.ModifiedValue;
                PlayerAccount.totalDamage = PlayerAccount.baseDamage + PlayerAccount.modifiedDamage;
                //PlayerAccount.damageModified = attribute.value.ModifiedValue;
                //Debug.Log("Added Damage" + attribute.value.ModifiedValue);
                break;
            case Attributes.Evasion:
                PlayerAccount.modifiedEvasion = attribute.value.ModifiedValue;
                PlayerAccount.totalEvasion = PlayerAccount.baseEvasion + PlayerAccount.modifiedEvasion;
                //PlayerAccount.evasionModified = attribute.value.ModifiedValue;
                //Debug.Log("Added Evasion" + attribute.value.ModifiedValue);
                break;
            default:
                break;
        }
    }

    public void Exit()
    {
        inventory.Clear();
        equipment.Clear();
        Debug.Log("{Player Inventory} Exit Inventory Cleared!");
    }

    public void ClearItems()
    {
        inventory.Clear();
        equipment.Clear();
        Debug.Log("{Player Inventory} Inventory Cleared!");
    }

    /*
    private void OnApplicationQuit()
    {
        inventory.Clear();
        equipment.Clear();
    }
    */
}

[System.Serializable]
public class Attribute
{
    [System.NonSerialized]
    public PlayerInventory parent;
    public Attributes type;
    public ModifiableInt value;

    public void SetParent(PlayerInventory _parent)
    {
        parent = _parent;
        value = new ModifiableInt(AttributeModified);
    }
    public void AttributeModified()
    {
        parent.AttributeModified(this);
    }
}
