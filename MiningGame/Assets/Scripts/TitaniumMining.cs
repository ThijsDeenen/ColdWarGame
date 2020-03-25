using System.Collections;
using UnityEngine;

public class TitaniumMining : MonoBehaviour
{
    public TitaniumOre titaniumOre;
    private GameObject pressEToUse;
    private bool isCloseEnough = false;
    private bool hasTitanium = true;
    // Start is called before the first frame update
    void Start()
    {
        pressEToUse = gameObject.transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (isCloseEnough)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                hasTitanium = false;
                pressEToUse.SetActive(false);
                titaniumOre.RemoveTitanium();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.parent.name == "Player" && hasTitanium)
        {
            pressEToUse.SetActive(true);
            isCloseEnough = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.transform.parent.name == "Player")
        {
            pressEToUse.SetActive(false);
            isCloseEnough = false;
        }
    }
}
