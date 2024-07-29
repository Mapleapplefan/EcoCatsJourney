using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator anim;
    void Start(){
        anim = GetComponent<Animator>();
    }

    void Update(){
       if (Input.GetKeyDown(KeyCode.Space)){
        anim.SetTrigger("Jump");
       }
    }
}
