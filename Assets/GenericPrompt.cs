using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GenericPrompt : SimpleSingleton<GenericPrompt>
{
    [SerializeField] TextMeshProUGUI bodyTxt;
    [SerializeField] TMP_InputField input;
    [SerializeField] Button btn;

    UnityAction<string> logic;

    // Start is called before the first frame update
    void Start()
    {
        UIManager.instance.genericPrompt = this;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show(string text, UnityAction<string> callLogic, string defaultText = "")
    {
        gameObject.SetActive(true);
        bodyTxt.text = text;
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(() =>
        {
            callLogic(input.text);
            gameObject.SetActive(false);
        });
        input.text = defaultText;
	}
}
