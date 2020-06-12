using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue1 : MonoBehaviour
{
  public void levelTwo() {
    Debug.Log("leveltwo");
    SceneManager.LoadScene("LevelTwo");
  }
}
