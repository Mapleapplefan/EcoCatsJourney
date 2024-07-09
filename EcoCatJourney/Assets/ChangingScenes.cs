using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangingScenes : MonoBehaviour
{
    public void PlayGame(){
    SceneManager.LoadSceneAsync("Level 1");
   }

   public void PlayLevel2(){
    SceneManager.LoadSceneAsync("Level 2");
   }
}
