using UnityEngine;
using UnityEngine.UI;

public class QuestButton : MonoBehaviour
{

    [SerializeField] public string QuestTitle = "Name of Quest";
    public QuestsManager manager;

    Button button;
    Text text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        GetComponent<RectTransform>().position = Vector3.zero;
    }

    void OnClick()
    {
        manager.QuestPressed(QuestTitle);
        Destroy(gameObject);
    }

    public void SetTitle(string newName)
    {
        QuestTitle = newName;
        text = this.GetComponentsInChildren<Text>(true)[0];
        text.text = newName;
    }
    
}
