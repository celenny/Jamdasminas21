using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balanceleft : MonoBehaviour {

    public Animator Animaleft;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void Button1() {
        //Animaleft.Play("left");
        Animaleft.SetBool("Move", true);
        Invoke("Button2", 2.0f);
    }

    public void Button2() {
        Animaleft.SetBool("Move", false);
    }

    public void Button3() {
        //Animaleft.Play("left");
        Animaleft.SetBool("MoveRight", true);
        Invoke("Button4", 2.0f);
    }

    public void Button4() {
        Animaleft.SetBool("MoveRight", false);
    }
}
