using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitaniumOre : MonoBehaviour
{
    public float durability;
    public Sprite[] ores;
    public Sprite[] emptyOres;
    private Sprite rightEmptyOre;


    // Start is called before the first frame update
    void Start()
    {
        ChooseBlock(Random.Range(0, 3));
    }

    private void ChooseBlock(int chosenNumber)
    {
        switch (chosenNumber)
        {
            case 0:
                gameObject.GetComponent<SpriteRenderer>().sprite = ores[0];
                rightEmptyOre = emptyOres[0];
                durability = 1;
                break;
            case 1:
                gameObject.GetComponent<SpriteRenderer>().sprite = ores[1];
                rightEmptyOre = emptyOres[1];
                durability = 1;
                break;
            case 2:
                gameObject.GetComponent<SpriteRenderer>().sprite = ores[2];
                rightEmptyOre = emptyOres[2];
                durability = 1;
                break;
            case 3:
                gameObject.GetComponent<SpriteRenderer>().sprite = ores[3];
                rightEmptyOre = emptyOres[3];
                durability = 1;
                break;
            case 4:
                gameObject.GetComponent<SpriteRenderer>().sprite = ores[4];
                rightEmptyOre = emptyOres[4];
                durability = 1;
                break;
        }
    }

    public void RemoveTitanium()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = rightEmptyOre;
    }

    public void TakeDamage(int damage)
    {
        durability -= 1;
        if (durability <= 0)
        {
            Break();
        }
    }

    public void Break()
    {
        Destroy(gameObject);
    }
}
