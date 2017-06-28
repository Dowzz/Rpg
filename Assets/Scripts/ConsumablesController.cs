using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumablesController : MonoBehaviour
{
    CharacterStats Stats;

    // Use this for initialization
    void Start()
    {
        Stats = GetComponent<Player>().characterStats;

    }
    public void ConsumeItem(Item item)
    {
        GameObject itemtospawn = Instantiate(Resources.Load<GameObject>("Consumables/" + item.ObjectSlug));
        if (item.ItemModifier)
        {
            itemtospawn.GetComponent<IConsummable>().Consume(Stats);
        }
        else
            itemtospawn.GetComponent<IConsummable>().Consume();

    }


}
