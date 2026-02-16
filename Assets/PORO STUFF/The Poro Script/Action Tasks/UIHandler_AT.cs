using NodeCanvas.DialogueTrees;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace NodeCanvas.Tasks.Actions {

	public class UIHandler_AT : ActionTask {

		//Calling the objects
        GameObject stateTextObject;
		GameObject imageObject;

		//Making a string to make the text easier to edit
		public string text = "Current State: " + "";
		public Sprite imageToFill;

		// Calling the actual component
		TMP_Text stateText;
		Image stateImage;
		
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			//Getting the image object that has the tag image box
			imageObject = GameObject.FindWithTag("ImageBox");

            // Finding the text object that will have the tag State Text
            stateTextObject = GameObject.FindWithTag("State Text");

			//Getting those components in those objects
			stateImage = imageObject.GetComponent<Image>();
            stateText = stateTextObject.GetComponent<TMP_Text>();

			if (stateImage == null)
			{
				Debug.Log("Clap");
			}
			//Setting the text to the string text set in the inspectorr
            stateText.text = text;

			// Setting the image to the one in the inspector
			stateImage.sprite = imageToFill;
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