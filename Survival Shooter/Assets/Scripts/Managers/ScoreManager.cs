using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score; 
	//shared variable through all scoremanager instances... 
	//I LEARNED SOTHING!!

    Text text;

    void Awake (){
        text = GetComponent <Text> ();
        score = 0;
    }
		
    void Update (){
        text.text = "Score: " + score;
    }
}
