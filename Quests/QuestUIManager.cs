using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUIManager : MonoBehaviour {

	public static QuestUIManager uiManager;

	public bool questAvailable = false;
	public bool questRunning = false;
	private bool questPanelActive = false;
	private bool questLogPanelActive = false;

	//PANELS
	public GameObject questPanel;
	public GameObject questLogPanel;

	//QUESTOBJECT
	private QuestObject currentQuestObject;

	//QUESTLISTS
	public List<Quest> availableQuests = new List<Quest> ();
	public List<Quest> activeQuests = new List<Quest> ();

	//BUTTONS
	public GameObject qButton;
	public GameObject qLogButton;
	private List<GameObject> qButtons = new List<GameObject> ();

	private GameObject acceptButton;
	private GameObject giveUpButton;
	private GameObject completeButton;

	//SPACER
	public Transform qButtonSpacer1;
	public Transform qButtonSpacer2;
	public Transform qLogButtonSpacer;

	//QUEST LOG INFOS
	public Text questTitle;
	public Text questDescription;
	public Text questSummary;

	//QUEST LOG INFOS
	public Text questLogTitle;
	public Text questLogDescription;
	public Text questLogSummary;

	void awake(){
		if (uiManager == null) {
			uiManager = this;
		} else if (uiManager != this) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);

		HideQuestPanel ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Q)){
			questPanelActive = !questPanelActive;
		}
			
	}

	//CALLED FROM QUEST OBJECT
	public void CheckQuests(int number){
		/*currentQuestObject = questObject;
		QuestManager.questManager.QuestRequest (questObject);
		if ((questRunning || questAvailable) && !questPanelActive) {
			ShowQuestPanel ();
		} else {
			Debug.Log ("No Quest Available");
		}*/
		Debug.Log ("hey there"+ number);
	}

	//SHOW PANEL
	public void ShowQuestPanel(){
		questPanelActive = true;
		questPanel.SetActive (questPanelActive);
		//FILL IN DATA
		FillQuestButtons();
	}

	//quest log

	//HIDE QUEST PANEL
	public void HideQuestPanel(){
		questPanelActive = false;
		questAvailable = false;
		questRunning = false;

		//clear TEXT
		questTitle.text = "";
		questDescription.text = "";
		questSummary.text = "";

		//clear LISTS
		availableQuests.Clear();
		activeQuests.Clear ();
		//clear BUTTON LIST
		for(int i = 0; i < qButtons.Count; i++){
			Destroy (qButtons[i]);
		}
		qButtons.Clear ();
		//HIDE PANEL
		questPanel.SetActive (questPanelActive);
	}

	//FILL BUTTON FOR QUEST PANEL
	void FillQuestButtons(){
		foreach(Quest availableQuest in availableQuests){
			GameObject questButton = Instantiate (qButton);
			QButtonScript qBScript = questButton.GetComponent<QButtonScript> ();

			qBScript.QuestID = availableQuest.id;
			qBScript.questTitle.text = availableQuest.title;

			questButton.transform.SetParent (qButtonSpacer1, false);
			qButtons.Add (questButton);
		}
	
		foreach(Quest activeQuest in activeQuests){
			GameObject questButton = Instantiate (qButton);
			QButtonScript qBScript = questButton.GetComponent<QButtonScript> ();

			qBScript.QuestID = activeQuest.id;
			qBScript.questTitle.text = activeQuest.title;

			questButton.transform.SetParent (qButtonSpacer2, false);
			qButtons.Add (questButton);
		}
	}
}
