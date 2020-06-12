using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
  public string unithp;

  public int attack;

  public int maxHP;
  public int currentHP;
  static public int currentPlayerHP = 10;

  public void setAttack(int newAttack) {
    attack = newAttack;
  }

  public void setNewMaxHP(int maxHealth) {
    maxHP = maxHealth;
    unithp = maxHealth + "/" + maxHealth;
    currentHP = maxHealth;
  }

  public bool TakeDamage(int dmg) {
    currentHP -= dmg;
    if(currentHP <= 0) {
      return true;
    }

    return false;
  }

  public void setCurrentHP(int hp) {
    currentHP = hp;
  }

  static public bool playerTakeDamage(int dmg) {
    currentPlayerHP -= dmg;
    if(currentPlayerHP <= 0) {
      return true;
    }

    return false;
  }

  static public int getCurrentPlayerHP() {
    return currentPlayerHP;
  }
}
