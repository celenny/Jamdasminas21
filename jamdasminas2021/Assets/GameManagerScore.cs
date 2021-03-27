using UnityEngine;
using System.Collections;

public class GameManagerScore : MonoBehaviour
{
    public static GameManagerScore Instance;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (Instance == null)
        {Instance = this;}
        else{Destroy(gameObject);}
        //PlayerPrefs.GetInt("pontuacao", 0);
    }

    public int GetPontos()
    {
        return PlayerPrefs.GetInt("pontuacao");
    }

    public void SetPontos(int pontuacaoJogador)
    {
            PlayerPrefs.SetInt("pontuacao", pontuacaoJogador);
            PlayerPrefs.Save();
    }
}
