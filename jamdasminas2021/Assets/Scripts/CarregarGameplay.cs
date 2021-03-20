using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarregarGameplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void CarregarCena(){
        SceneManager.LoadScene("GamePlay");
    }
    
  
    // Update is called once per frame
    void Update()
    {
        
    }
}
