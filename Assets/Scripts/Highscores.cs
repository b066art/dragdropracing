using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;
using TMPro;

public class Highscores : MonoBehaviour {

    [SerializeField] private Transform entryContainer;
    [SerializeField] private GameObject entryTemplate;
    [SerializeField] private int highscoresLimit = 10;
    private const string fileName = "highscores.xml";

    private void Awake() {
        if (!File.Exists(fileName)) {
            XDocument document = new XDocument(new XElement("players"));
            document.Save(fileName);
        }
        CreateHighscoresTable();
    }

    private void CreateHighscoresTable() {
        int templateOffset = 50;
        XDocument document = XDocument.Load(fileName);

        int i = 0;
        foreach (XElement el in document.Root.Elements()) {
            GameObject entry = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entry.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = entryRectTransform.anchoredPosition - new Vector2(0, templateOffset * i++);

            entry.transform.Find("Rank").GetComponent<TMP_Text>().text = "#" + i;
            entry.transform.Find("Name").GetComponent<TMP_Text>().text = el.Attribute("name").Value;
            entry.transform.Find("Time").GetComponent<TMP_Text>().text = el.Attribute("time").Value;

            entry.SetActive(true);
        }
    }

    public void NewRecord(string name, double time) {
        XDocument document = XDocument.Load(fileName);
        XElement root = document.Element("players");

        string strTime = time.ToString("0.0000");

        root.Add(new XElement("player", new XAttribute("name", name), new XAttribute("time", strTime)));

        var sortedElements = root.Elements("player").OrderBy(p => (string)p.Attribute("time"));
        root.ReplaceAll(sortedElements);

        int count = document.Descendants("player").Count();
        if (count > highscoresLimit) {
            document.Descendants("player").ElementAt(highscoresLimit).Remove();
        }

        document.Save(fileName);
    }
}


