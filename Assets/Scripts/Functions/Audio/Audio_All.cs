using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_All : MonoBehaviour
{ 
    [SerializeField]
    private AudioSource Confirmed;

    [SerializeField]
    private AudioSource Level_Remain;

    [SerializeField]
    private AudioSource Level_UP;

    [SerializeField]
    private AudioSource Step_False;

    [SerializeField]
    private AudioSource Step_Right;
    
    
    
    public void Sound_Confirmed() => Confirmed.Play();
    public void Sound_Level_Remain() => Level_Remain.Play();
    public void Sound_Step_False() => Step_False.Play();
    public void Sound_Level_UP() => Level_UP.Play();
    public void Sound_Step_Right() => Step_Right.Play();

}
