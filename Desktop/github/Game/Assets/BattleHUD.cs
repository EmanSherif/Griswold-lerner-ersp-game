using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text HPText;
    public Text AttackText;
    public Slider HP;

    public void SetHUD(Unit unit) {
      HPText.text = unit.unithp;
      AttackText.text = "Attack: " + unit.attack;
      HP.maxValue = unit.maxHP;
      HP.value = unit.currentHP;
    }

    public void SetHP(int hp) {
      HP.value = hp;
      HPText.text = hp + "/" + HP.maxValue;
    }

    public void SetAttack(int attack) {
      AttackText.text = "Attack: " + attack;
    }
}
