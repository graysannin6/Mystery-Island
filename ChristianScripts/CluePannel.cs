using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CluePannel : MonoBehaviour
{
    ParseXML parse;
    public GameObject messagepannel;
    public Text cluemessage;
    private int check = 0;
    // Start is called before the first frame update
    void Start()
    {
        parse = gameObject.AddComponent<ParseXML>();

       
    }

    void OnTriggerEnter(Collider plyr)
    {
        if (plyr.gameObject.tag == "Flower")
        {
            
            if (check == 0)
            {
                messagepannel.SetActive(true);
                List<Dictionary<string, string>> allTextDic = parse.parseFile();
                Dictionary<string, string> dic = allTextDic[0];
                cluemessage.text = dic["firstclue"];
            }

            if (check == 1)
            {
                messagepannel.SetActive(true);
                List<Dictionary<string, string>> allTextDic = parse.parseFile();
                Dictionary<string, string> dic = allTextDic[0];
                cluemessage.text = dic["secondclue"];
            }

            check++;
            
        }

    }

    /*private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "clue1" || other.gameObject.tag == "clue2" || other.gameObject.tag == "clue3")
        {
            messagepannel.SetActive(false);
            
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
