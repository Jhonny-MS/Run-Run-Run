using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    public int life = 100;
    public GameController gameController;
   
    void Start()
    {
        
    }


    void Update()
    {
        Dead();
    }

    public void Dead()
    {
        if (life <= 0)
        {
            gameController.AwakeUi();
        }

    }
}
