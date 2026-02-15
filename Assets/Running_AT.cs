using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class Running_AT : ActionTask {
		public float fleeDistance = 10f;
		public float safeDistance = 15f;
        public BBParameter<NavMeshAgent> agents;
        public BBParameter<Transform> player;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			float distance = Vector3.Distance(agent.transform.position, player.value.position);
			
			if(distance < safeDistance)
			{
				Flee();
			}
			else
			{
				EndAction(true);
			}
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
		
		void Flee()
		{
			Vector3 direction = agent.transform.position - player.value.position;

			Vector3 newPosition = agent.transform.position + direction.normalized * fleeDistance;

			NavMeshHit hit;

			if(NavMesh.SamplePosition(newPosition, out hit, fleeDistance, NavMesh.AllAreas))
			{
				agents.value.SetDestination(hit.position);
			}	

		}
	}
}