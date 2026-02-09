using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class WanderingAround_AT : ActionTask {
        public BBParameter<NavMeshAgent> agents;
		public float range;
        public BBParameter<Transform> centrePoint; 

		//Use for initialization. This is called only once in the lifetimse of the task.
		//Return null if init was successfull. Return an error string otherwis
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
			if (agents.value.remainingDistance <= agents.value.stoppingDistance)
			{
				Vector3 point;

				if(RandomPoint(centrePoint.value.position, range, out point))
				{
					agents.value.SetDestination(point);
				}
			}
		}

		bool RandomPoint(Vector3 center, float range, out Vector3 result)
		{
			Vector3 randomPoint = center + Random.insideUnitSphere * range;
			NavMeshHit hit;
			if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
			{
				result = hit.position;
				return true;
			}

			result = Vector3.zero;
			return false;
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}