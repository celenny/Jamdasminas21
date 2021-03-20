using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarregarFinaisAnubis : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    IEnumerator ChamaEmocional(){
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("FinalEmocional");
    }
    IEnumerator ChamaRacional(){
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("FinalRacional");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
