using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class progress : MonoBehaviour
{
    public GameObject Ball;
    public Slider Slider;
    public GameObject Text;
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.highScore < health) {
            Text.GetComponent<TextMeshProUGUI>().SetText(AbbrevationUtility.AbbreviateNumber(GameManager.highScore)+ "/" + AbbrevationUtility.AbbreviateNumber(health));
        } else {
            Text.GetComponent<TextMeshProUGUI>().SetText(AbbrevationUtility.AbbreviateNumber(health)+ "/" + AbbrevationUtility.AbbreviateNumber(health));
        }
        Slider.value = GameManager.highScore/health;
        if (GameManager.highScore >= health) {
            Ball.GetComponent<Button>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {


    }
    public static class AbbrevationUtility
    {
        private static readonly SortedDictionary<long, string> abbrevations = new SortedDictionary<long, string>
        {
            {1000,"K"},
            {1000000, "M" },
            {1000000000, "B" },
            {1000000000000,"T"}
        };

        public static string AbbreviateNumber(float number)
        {
            if (number >= 1000) {
                for (int i = abbrevations.Count - 1; i >= 0; i--)
                {
                    KeyValuePair<long, string> pair = abbrevations.ElementAt(i);
                    if (Mathf.Abs(number) >= pair.Key)
                    {
                        int roundedNumber = Mathf.FloorToInt(number / pair.Key);
                        return roundedNumber.ToString() + pair.Value;
                    }
                }
            }
            return number.ToString();
        }
    }
}
