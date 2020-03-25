using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    public int health
    {
        get { return p_health; }
        set { p_health = value; }
    }
    private int p_health;

    // Update is called once per frame
    void Update()
    {
        
    }
}
