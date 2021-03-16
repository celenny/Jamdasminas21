using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChamaInicio()
    {
        SceneManager.LoadScene("Inicio");
    }

    public void ChamaJogar()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void ChamaCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }
}
