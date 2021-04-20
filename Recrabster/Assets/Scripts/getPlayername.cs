using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace RO.Crab
{
    public class getPlayername : MonoBehaviour
    {

        public TMP_InputField namefield;
        public TMP_Text alert;
        public TMP_InputField OptionsNamefield;
        public GameObject enterPlayerobject;

        // Start is called before the first frame update
        void Start()
        {
            if (Master.instance.playerName != "")
                enterPlayerobject.SetActive(false);
            if (PlayerPrefs.GetString("playerName") != "")
                namefield.text = PlayerPrefs.GetString("playerName");
        }

        // Update is called once per frame
        public void getName()
        {
            if (namefield.text != "")
            {
                Master.instance.playerName = namefield.text;
                PlayerPrefs.SetString("playerName", namefield.text);
                PlayerPrefs.Save();
                OptionsNamefield.text = namefield.text;
                enterPlayerobject.SetActive(false);
            }
            else
                alert.text = "You must enter your name!";
        }
    }
}