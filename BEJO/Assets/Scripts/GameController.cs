using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //public Cubes enemy;

    public Questions[] question;
    private static List<Questions> unansweredQ;
    

    private Questions currentQ;

    //private Cubes cb = GetComponent<Cubes>().TakeDamage();
    //string cubeChoiceTag = cb.cubeTag;

    [SerializeField]
    private Text questText;

    // Start is called before the first frame update
    void Start()
    {
        if (unansweredQ == null || unansweredQ.Count == 0)
        {
            unansweredQ = question.ToList<Questions>();
        }

        //damage = GetComponent<PlayerController>();

        SetCurrentQuestion();

    }
    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQ.Count);
        currentQ = unansweredQ[randomQuestionIndex];

        questText.text = currentQ.quest;

        unansweredQ.RemoveAt(randomQuestionIndex);
    }


}   
