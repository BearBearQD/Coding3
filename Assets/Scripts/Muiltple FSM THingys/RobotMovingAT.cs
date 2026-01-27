using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class RobotMovingAT : ActionTask {
        public BBParameter<float> speed;
		private Vector3 targetPosition;
		public float minX = -20f;
		public float maxX = 20f;
		public float minZ = -20f;
		public float maxZ = 20f;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			float randomX = Random.Range(minX, maxX);
			float randomZ = Random.Range(minZ, maxZ);

			targetPosition = new Vector3(randomX, agent.transform.position.y, randomZ);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			agent.transform.position = Vector3.MoveTowards(agent.transform.position, targetPosition, speed.value * Time.deltaTime);

			if(Vector3.Distance(agent.transform.position, targetPosition) < 0.2f)
			{
                Debug.Log("DING DING");
                EndAction(true);

			}
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}