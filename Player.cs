using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public int coins;

    public int Max_Health = 100;
    public int P_Invisibility;
    public int P_Frog;
    public int P_Giant;
   
    Entity P_Entity;
    
    void Start()
    {
        Life = Max_Health;
        P_Entity = new Entity(En_transform,En_RB,Speed,Force_Jump);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
