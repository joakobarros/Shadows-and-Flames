using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneManage : MonoBehaviour
{
  public void Tutorial()
  {
    SceneManager.LoadScene("tutorial");
  }
  public void Menu()
  {
    SceneManager.LoadScene("Menú");
  }
  public void Creditos()
  {
    SceneManager.LoadScene("Créditos");
  }
  public void Taller()
  {
    SceneManager.LoadScene("Créditos");
  }

}