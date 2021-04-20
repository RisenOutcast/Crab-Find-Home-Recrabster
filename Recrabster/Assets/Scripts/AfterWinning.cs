using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

namespace RO.Crab {
    public class AfterWinning : MonoBehaviour
    {
        public TMP_Text leftoverShellsText;
        public TMP_Text FinalPointsText;

        int points;
        bool shellsTurned = false;

        public int LeftoverShells;

        int kuorienWörtti;

        public GameObject exitNappi;

        bool upload = false;

        string PostScoreURL = "https://risenoutcast.com/CFHRLeaderboard/putCFHRLeaderboardData.php";

        //REMOVE AFTER TEST
        //int ro_id = 1;
        string username;
        int uppauspoints;

        // Start is called before the first frame update
        void Start()
        {
            LeftoverShells = Master.instance.kuorienMäärä;
            username = Master.instance.playerName;
            points = 0;
            kuorienWörtti = 50;
            uppauspoints = Master.instance.points + (Master.instance.kuorienMäärä * kuorienWörtti);
            Debug.Log("Final Score: " + uppauspoints.ToString());
            StartCoroutine(UploadScore(username, uppauspoints));
        }

        // Update is called once per frame
        void Update()
        {
            FinalPointsText.text = points.ToString() + " pts";
            leftoverShellsText.text = LeftoverShells.ToString();

            if (points < Master.instance.points)
            {
                points += 10;
            }
            if(points > Master.instance.points)
            {
                points = Master.instance.points;
            }

            if (points == Master.instance.points && !shellsTurned)
            {
                StartCoroutine(TurnShells());
                shellsTurned = true;
            }

            if(points == Master.instance.points && LeftoverShells == 0)
            {
                upload = true;
            }

            if (upload)
            {
                Debug.Log("This is where data gets upped!");
                upload = false;
            }
        }
        
        IEnumerator TurnShells()
        {
            yield return new WaitForSeconds(0.5F);
            bool turning = true;
            while (turning == true)
            {
                if (LeftoverShells <= 1)
                    turning = false;
                yield return new WaitForSeconds(0.2F);
                LeftoverShells -= 1;
                Master.instance.points += kuorienWörtti;
            }
        }

        IEnumerator UploadScore(string username, int points)
        {
            yield return new WaitForSeconds(1);
            WWWForm form = new WWWForm();
            form.AddField("username", username);
            form.AddField("points", points);

            using (UnityWebRequest www = UnityWebRequest.Post(PostScoreURL, form))
            {
                yield return www.SendWebRequest();

                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    Debug.Log("Form upload complete!");
                    Debug.Log(www.downloadHandler.text);
                }
            }

            exitNappi.SetActive(true);
        }
    }
}