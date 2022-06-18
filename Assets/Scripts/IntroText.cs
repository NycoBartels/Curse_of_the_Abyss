using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroText : MonoBehaviour
{
    private TextMeshProUGUI tmp;
    private Animator anim;

    public string[] line;
    private int counter = 0;

    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        anim = GetComponent<Animator>();
    }


    void StartLine()
    {
        print("start line");
        if (counter > line.Length) StartGame();
        tmp.text = line[counter];
        anim.Play("FadeIn");
    }

    void EndLine()
    {
        print("line ended");
        counter++;
        anim.Play("FadeOut");
    }

    void StartGame()
    {
        //TO DO: Scene load game after last line. call this in animation event
        print("Insert 1 Euro to continue...");
    }

}
