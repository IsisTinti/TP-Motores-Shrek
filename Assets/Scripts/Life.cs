using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life
{
    int _maxlife;
    int _life;
    int _damage;
    int _upgradeLifeQuantity;

    public Life(int maxlife, int upgradeLifeQuantity)
    {
        _maxlife = maxlife;
        _life = maxlife;
        _upgradeLifeQuantity = upgradeLifeQuantity;

    }

    public void TakeDamage(int dmg)
    {
        _life -= dmg;

        if (_life <= 0)
        {
            Death();
        }

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
        Debug.Log("na de locos te moriste xd");
    }

    public void UpgradeLife()
    {
        _maxlife += _upgradeLifeQuantity;
       Debug.Log("Upgrade de vida! ahora tu vida maxima es de " + _maxlife);
    }
}
