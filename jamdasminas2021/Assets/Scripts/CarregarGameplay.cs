using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarregarGameplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CarregarCena");
        Debug.Log("chamou");
    }

    IEnumerator CarregarCena(){
        Debug.Log("chamouaaaaa");
        yield return new WaitForSeconds(16f);
        SceneManager.LoadScene("GamePlay");

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
