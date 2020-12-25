using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Text dialogText;

    public Image dialogBackground;

    public string[] sentences;

    private int index;

    private float typingSpeed = 0.02f;

    public GameObject yesButton;
    public GameObject noButton;

    Martial martialBoss;
    Player player;
    int coincount;

   [SerializeField] int requiredCoin;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        martialBoss = GameObject.Find("Martial_Boss").GetComponent<Martial>();
        coincount = player.coinCount;
        if (coincount < requiredCoin)
        {
            StartCoroutine(Type(0));
        }
        else if (coincount >= requiredCoin)
        {
            yesButton.SetActive(false);
            noButton.SetActive(false);
            StartCoroutine(LoadEndGame());
        }
    }

    private void OnEnable()
    {
        coincount = player.coinCount;
        dialogText.text = "";

        if (coincount < requiredCoin)
        {
            StartCoroutine(Type(0));
        }
        else if (coincount >= requiredCoin)
        {
            yesButton.SetActive(false);
            noButton.SetActive(false);
            StartCoroutine(LoadEndGame());
        }
    }

    private void Update()
    {
        
        if (dialogText.text == sentences[index])
        {
            yesButton.SetActive(true);
            noButton.SetActive(true);
        }
    }

    IEnumerator Type(int numberOfSentences)
    {
        foreach (char letter in sentences[numberOfSentences].ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator LoadEndGame()
    {
        StartCoroutine(Type(1));
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(2);
    }

    IEnumerator AttackToHero()
    {
        StartCoroutine(Type(2));
        yield return new WaitForSeconds(2f);
        dialogBackground.gameObject.SetActive(false);
        dialogText.gameObject.SetActive(false);
        martialBoss.TriggerAttackAnimation();
    }

public void YesButtonDialog()
    {
        dialogText.text = "";
        yesButton.SetActive(false);
        noButton.SetActive(false);
        StartCoroutine(AttackToHero());
       
        
    }

    public void NoButtonDialog()
    {
        dialogText.text = "";
        yesButton.SetActive(false);
        noButton.SetActive(false);
        StartCoroutine(Type(3));
    }


    //public void NextSentences()
    //{
    //    yesButton.SetActive(false);
    //    noButton.SetActive(false);

    //    if (index < sentences.Length - 1)
    //    {
    //        index++;
    //        dialogText.text = "";
    //        StartCoroutine(Type());
    //    }
    //    else
    //    {
    //        dialogText.text = "";
    //        yesButton.SetActive(false);
    //        noButton.SetActive(false);
    //    }
    //}

}
