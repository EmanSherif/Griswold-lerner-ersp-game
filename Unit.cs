using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
  public string unithp;

  public int attack;

  public int maxHP;
  public int currentHP;

  public void setAttack(int newAttack) {
    attack = newAttack;
  }

  public bool TakeDamage(int dmg) {
    currentHP -= dmg;
    if(currentHP <= 0) {
      return true;
    }

    return false;
  }
}
