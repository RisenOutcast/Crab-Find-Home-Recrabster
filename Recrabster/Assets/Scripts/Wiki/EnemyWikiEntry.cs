using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Author M.J.Metsola @RisenOutcast
namespace RO.Crab
{
    public class EnemyWikiEntry : MonoBehaviour
    {
        public GameObject EnemyPrefab;
        private string attributes;

        public TMP_Text TitleField;
        public TMP_Text AttributeField;
        public TMP_Text DescriptionField;

        // Start is called before the first frame update
        void Start()
        {
            TitleField.text = EnemyPrefab.GetComponent<Vihu>().Name.ToString();
            AttributeField.text = "Health: " + EnemyPrefab.GetComponent<Vihu>().Health.ToString()
                + "\n" + "Speed: " + EnemyPrefab.GetComponent<Vihu>().Speed.ToString()
                + "\n" + "Worth: " + EnemyPrefab.GetComponent<Vihu>().worth.ToString() + " points";
            DescriptionField.text = EnemyPrefab.GetComponent<Vihu>().description;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
