using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    public Character character;
    Animator anim;
    SpriteRenderer sr;
    public SelectCharacter[] chars;

    private void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        if (DataManager.instance.currentCharacter == character) OnSelect();
        else OnDeSelect(); 
    }

    private void OnMouseUpAsButton()
    {
        DataManager.instance.currentCharacter = character;
        OnSelect();
        for(int i = 0; i< chars.Length; i++)
        {
            if (chars[i] != this) chars[i].OnDeSelect();
        }
    }
    void OnDeSelect()
    {
        anim.SetBool("RunStart", false);
        sr.color = new Color(0.5f, 0.5f, 0.5f);
    }
    void OnSelect()
    {
        anim.SetBool("RunStart", true);
        sr.color = new Color(0f, 0f, 0f);
    }

}
