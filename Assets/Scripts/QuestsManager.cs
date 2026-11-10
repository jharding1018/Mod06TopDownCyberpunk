using Esper.FeelSpeak;
using Esper.FeelSpeak.UI.UGUI;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class QuestsManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    QuestButton[] Children = new QuestButton[0];

    [SerializeField] QuestButton buttonPrefab;
    string LastDialogue = "";

    bool readyForEnd = false;

    void Start()
    {
        AddQuest("Intro");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddQuest(string Name)
    {
        QuestButton newButton = Instantiate(buttonPrefab);
        newButton.manager = this;
        newButton.SetTitle(Name);
        newButton.transform.SetParent(this.transform);
        newButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(807.5f, 406.5f);
        Children.Append(newButton);
    }

    public void QuestPressed(string Name)
    {
        LastDialogue = Name;
        FeelSpeak.GetDialogueGraph(Name).Trigger();
        
    }

    public void OnContinue(InputValue value)
    {
        if (FeelSpeak.HasActiveDialogue)
        {
            DialogueBox.Instance?.Next();
        } else
        {
            AddQuests();
        }
    }

    private void AddQuests()
    {
        // Add quests based on previously finished quest
        if (LastDialogue.Equals("Intro"))
        {
            AddQuest("Boost Credentials");
            AddQuest("Locate Explosives");
        } else if (LastDialogue.Equals("Boost Credentials"))
        {
            AddQuest("Rigged from the Start");
        } else if (LastDialogue.Equals("Locate Explosives"))
        {
            AddQuest("Stolen Hardware");
        } else if (LastDialogue.Equals("Stolen Hardware") || LastDialogue.Equals("Rigged from the Start"))
        {
            if (!readyForEnd)
            {
                AddQuest("Arkwright Corp");
                readyForEnd = true;
            }
        } else if (LastDialogue.Equals("Arkwright Corp"))
        {
            AddQuest("Escape!");
        }

        LastDialogue = "";
    }
}
