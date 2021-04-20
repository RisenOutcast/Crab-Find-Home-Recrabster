using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Leaderboards : MonoBehaviour
{
    public string[] userscores;

    public TMP_Text[] NameTexts;
    public TMP_Text[] PointsTexts;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        WWW leaderboardData = new WWW("https://risenoutcast.com/CFHRLeaderboard/getCFHRLeaderboardData.php");
        yield return leaderboardData;
        string leaderboardDataString = leaderboardData.text;
        print(leaderboardDataString);
        userscores = leaderboardDataString.Split(';');
        InstantiateLeaderboard();
    }

    // Get users data. data is userscores[*indexnumber*] and index is "User:" or "Points:"
    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }

    void InstantiateLeaderboard()
    {
        for (int i = 0; i < userscores.Length; i++)
        {
            NameTexts[i].text = GetDataValue(userscores[i], "User:");
            PointsTexts[i].text = GetDataValue(userscores[i], "Points:");
        }
    }
}
