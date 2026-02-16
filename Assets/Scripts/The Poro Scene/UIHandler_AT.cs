using NodeCanvas.DialogueTrees;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using TMPro;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class UIHandler_AT : ActionTask {

		//Calling the text object
        GameObject stateTextObject;

		//Making a string to make the text easier to edit
		public string text = "Current State: " + "";

		// Calling the actual component
		TMP_Text stateText;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			// Finding the text object that will have the tag State Text
            stateTextObject = GameObject.FindWithTag("State Text");

			//Getting the TMP pro component in that object
            stateText = stateTextObject.GetComponent<TMP_Text>();

			//Setting teh text to the string text set in the inspectorr
            stateText.text = text;
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

        }

		//Called when the task is disabled.
		protected override void OnStop() {

		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}