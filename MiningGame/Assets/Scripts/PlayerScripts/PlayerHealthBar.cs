using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthBar : MonoBehaviour
{
    public GameObject[] hearts;
    //public int num;

    //private void Start()
    //{
    //    ChangeHeartAmount(num);
    //}

    private void ChangeHeartAmount(int amountOfHearts)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < amountOfHearts)
            {
                hearts[i].gameObject.SetActive(true);
            }
            else
            {
                hearts[i].gameObject.SetActive(false);
            }
        }
    }
}
