using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour
{
    public Text bookText;
    public string[] names;

    public void DisplayNamesOnBook()
    {
        string namesText = string.Join("\n", names);
        bookText.text = namesText;
    }
}
