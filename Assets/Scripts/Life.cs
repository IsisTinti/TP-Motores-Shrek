using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life
{
    int _maxlife;
    int _life;
    int _damage;
    int _upgradeLifeQuantity;

    public Life(int maxlife, int life, int damage, int upgradeLifeQuantity)
    {
        _maxlife = maxlife;
        _life = life;
        _damage = damage;
        _upgradeLifeQuantity = upgradeLifeQuantity;

    }

    public  void TakeDamage()
    {
        _life -= _damage;
      
    }

    public void GetLife()
    {
        
        _life +=15;
        if (_life>_maxlife)
        {
            _life = _maxlife;
        }
       

    }

    public void Death()
    {
        //print("na de locos te moriste xd");
    }

    public void UpgradeLife()
    {
        _maxlife += _upgradeLifeQuantity;
       // print("Upgrade de vida! ahora tu vida maxima es de " + _maxlife);
    }
}
