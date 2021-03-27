using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class balanceleft : MonoBehaviour {
    public Animator Animaleft;
    [SerializeField] GameObject personRationalOnScene, personEmotionalOnScene; //variável para manter a sprite que será mostrada em cena 
    [SerializeField] Transform pointPersonRationalSpawn, pointPersonEmotionalSpawn; //variável para spawnar as personagens fora de cena
    [SerializeField] Transform pointPersonRationalOnScene, pointPersonEmotionalOnScene; //variável para mover os personagens para ficar em cena
    [SerializeField] Transform pointPersonRationalDying, pointPersonEmotionalDying; //variavel para mover os personagens para sair da cena
    [SerializeField] Transform outScene,beforeScene;
    [SerializeField] Text txtDescriptionRational, txtDescriptionEmotional;
    public string rationalDescriptionOnScene, emotionalDescriptionOnScene;
    private string[] rationalDescription;
    private string[] emotionalDescription;
    private Sprite[] persons; // vetor para guardar as sprites que serão sorteadas
    private int score = 0;
    [SerializeField] float speed = 50.0f;
    public int rounds = 3;
    public int atRound;
    private bool chosedbutton;
    private bool somouTurno = false;
 
    public void Button1() {
        //Animaleft.Play("left");
        Animaleft.SetBool("Move", true);
        Invoke("Button2", 2.0f);
        chosedbutton = true;
        AddScore();
    }

    public void Button2() {
        Animaleft.SetBool("Move", false);
    }

    public void Button3() {
        //Animaleft.Play("left");
        Animaleft.SetBool("MoveRight", true);
        Invoke("Button4", 2.0f);
        chosedbutton = true;
        SubScore();
    }

    public void Button4() {
        Animaleft.SetBool("MoveRight", false);
    }

    void Start()
    {
        rationalDescription = new string[4];
        rationalDescription[0] = "Um escriba que trabalhava no palácio, sempre ouvia mais sua mente do que seu coração. Ajudou com a escrita, criação de leis, e esteve presente na criação de vários edifícios. Quando acompanhava guardas para pegar os impostos das classes mais baixas, tomava um pouco do dinheiro para si. Foi morto por uma pessoa que almejava seu título. ";
        rationalDescription[1] = "Essa pessoa era sacerdote, estava sempre ao lado do Faraó, realizava cultos e agradava os deuses. Ajudava a população. Tinha escravos e maltratava os animais que tinha de “estimação”. Morreu picado por um escorpião.";
        rationalDescription[2] = "Um líder que cuidava das decisões do exército, religiosas, econômicas e judiciais. Doava comida para seu povo diariamente. Tomava mulheres de seus trabalhadores para si próprio, colocava escravos para lutarem entre si. Morreu esfaqueado.";
        rationalDescription[3] = "Um grande Faraó, ajudou a erguer ainda mais o Egito, diminuiu a fome entre os pobres e melhorou a condição de vida da população. Mas era extremamente arrogante, tratava todos os seus empregados muito mal. Morreu pelas mãos de um dos empregados.";

        emotionalDescription = new string[4];
        emotionalDescription[0] = "Era uma pessoa cuidadosa, não tinha muito dinheiro, mas sempre que alguém necessitava, doava parte de seus suprimentos. Se alguém tentasse se opor a ele, arrumava brigas com todos. Morreu após tentar pegar comida do mercado para sobreviver. ";
        emotionalDescription[1] = "Essa pessoa era um escravo de uma casa rica. Lá ele sofria muito e acabou matando seu “dono”. Fugiu escondido da vila e caminhou até que encontrasse outro lugar para morar. Lá encontrou o amor e teve um filho. Com pouco dinheiro, saqueava outros moradores. Morreu afogado num rio.";
        emotionalDescription[2] = "Essa pessoa era artesã. Ele fazia seus trabalhos para a alta hierarquia e pequenos mercadores que os vendia no mercado. Tratava bem as pessoas que estavam ao seu redor, embora sentisse repulsa do faraó. Negou-se a se curvar diante do Faraó. Foi morto como traidor.";
        emotionalDescription[3] = "Teve 4 filhos muito cedo, e dedicou sua vida a eles. Deu muito amor, mas precisava roubar para alimentá-los. Morreu antes de ver todos os filhos completarem a maioridade";

        persons = new Sprite[6];
        persons[0] = Resources.Load<Sprite>("Personagens/PERSONAGEM1");
        persons[1] = Resources.Load<Sprite>("Personagens/PERSONAGEM2");
        persons[2] = Resources.Load<Sprite>("Personagens/PERSONAGEM3");
        persons[3] = Resources.Load<Sprite>("Personagens/PERSONAGEM4");
        persons[4] = Resources.Load<Sprite>("Personagens/PERSONAGEM5");
        persons[5] = Resources.Load<Sprite>("Personagens/PERSONAGEM6");
        atRound = 0;
        SpawnPersons();

    }


    void Update()
    {
        if (personEmotionalOnScene.GetComponent<Transform>().position.x > pointPersonEmotionalOnScene.position.x)
            {
                MovePersonsToScene();
            }
   
        //if (personRationalOnScene.GetComponent<Transform>().position.x > pointPersonRationalDying.position.x)
        //        MovePersonsOutScene();
 

        if (personEmotionalOnScene.GetComponent<Transform>().position.x < outScene.position.x)
        {
            chosedbutton = false;
        }

        if (atRound == rounds)
        {
            GameManagerScore.Instance.SetPontos(score);

            CheckScore();
        }
        
    }

    public void SpawnPersons()
    {
        personRationalOnScene.GetComponent<Transform>().position = pointPersonRationalSpawn.position;
        personEmotionalOnScene.GetComponent<Transform>().position = pointPersonEmotionalSpawn.position;

        //selecionar aleatoriamente os personagens e carregar na sprite
        int position = Random.Range(0, 5);
        personRationalOnScene.GetComponent<SpriteRenderer>().sprite = persons[position];

        position = Random.Range(0, 5);
        personEmotionalOnScene.GetComponent<SpriteRenderer>().sprite = persons[position];

        position = Random.Range(0, 3);
        rationalDescriptionOnScene = rationalDescription[position];

        position = Random.Range(0, 3);
        emotionalDescriptionOnScene = emotionalDescription[position];

    }


    public void MovePersonsToScene()
    {

        //TODO mover personagens para ficar na cena e carregar descrição dos personagens
        Vector2 destinationRational, destinationEmotional;
        destinationRational = pointPersonRationalOnScene.position;
        personRationalOnScene.GetComponent<Transform>().position = Vector2.Lerp(personRationalOnScene.GetComponent<Transform>().position, destinationRational, Time.deltaTime);

        destinationEmotional = pointPersonEmotionalOnScene.position;
        personEmotionalOnScene.GetComponent<Transform>().position = Vector2.Lerp(personEmotionalOnScene.GetComponent<Transform>().position, destinationEmotional, Time.deltaTime);

        ShowDescription();

    }


    public void MovePersonsOutScene()
    {
        //mover personagens para sair da cena e remover descrição dos personagens
        Vector2 destinationRational, destinationEmotional;
        destinationRational = pointPersonRationalDying.position;
        personRationalOnScene.GetComponent<Transform>().position = Vector2.Lerp(personRationalOnScene.GetComponent<Transform>().position, destinationRational, Time.deltaTime);

        destinationEmotional = pointPersonEmotionalDying.position;
        personEmotionalOnScene.GetComponent<Transform>().position = Vector2.Lerp(personEmotionalOnScene.GetComponent<Transform>().position, destinationEmotional, Time.deltaTime);
    }

    public void ShowDescription()
    {
        txtDescriptionRational.text = rationalDescriptionOnScene;
        txtDescriptionEmotional.text = emotionalDescriptionOnScene;
    }

    void CheckScore()
    {
        GameManagerScore.Instance.GetPontos();
        StartCoroutine("ChamaFinal");
    }
    IEnumerator ChamaFinal()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("anunbisFinal");
    }

    public void AddScore()
    {

        atRound++;
        if (atRound < 3) {
            score++;
            SpawnPersons();
        }
        
    }

    public void SubScore()
    {

        atRound++;
        if (atRound < 3) {
            score--;
            SpawnPersons();
        }
    }
}
