using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class Sleeping_AT : ActionTask {

		// Getting the time variable from the blackboard
        public BBParameter<float> time;

		//Getting a sky box to change to
        public Material newSkybox;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			// Setting the time variable to be 200
			time.value = 200;

			// stuff for the sky box
            Effects();
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

		void Effects()
		{
			// Changing the night time one
            RenderSettings.skybox = newSkybox;
            DynamicGI.UpdateEnvironment();
        }

	}
}