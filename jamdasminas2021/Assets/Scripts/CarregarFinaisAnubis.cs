using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarregarFinaisAnubis : MonoBehaviour
{
    int score;
    // Start is called before the first frame update
    void Start()
    {
        CheckScore();
    }

    void CheckScore()
    {
        score = GameManagerScore.Instance.GetPontos();
        if (score > 0)
        {
            StartCoroutine("ChamaRacional");
        }
        else
        {
            StartCoroutine("ChamaEmocional");
        }
    }
    IEnumerator ChamaEmocional(){
        yield return new WaitForSeconds(9f);
        SceneManager.LoadScene("FinalEmocional");
    }
    IEnumerator ChamaRacional(){
        yield return new WaitForSeconds(9f);
        SceneManager.LoadScene("FinalRacional");
    }
}
