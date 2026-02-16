using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class WanderingAround_AT : ActionTask {
		// Getting the agent from the blakcboard
        public BBParameter<NavMeshAgent> agents;

		// Setting the range of the wandering
		public float range;

		// making sure it only does it around a center point
        GameObject centrePoint; 

		//Use for initialization. This is called only once in the lifetimse of the task.
		//Return null if init was successfull. Return an error string otherwis
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			// Findiing where the centre point is with find gameobject with tag
			centrePoint = GameObject.FindWithTag("Centre");
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			// Basscially is the agent on top of the destination point
			if (agents.value.remainingDistance <= agents.value.stoppingDistance)
			{
				// Vector for the sake of knowing the result of the random point
				Vector3 point;
				
				//The random point is calculated
				if(RandomPoint(centrePoint.transform.position, range, out point))
				{
					// Make the agent go over to that point
					agents.value.SetDestination(point);
				}
			}
		}

		//Essentially a function for calulating a random position to move to, it takes a center a range and a result
		bool RandomPoint(Vector3 center, float range, out Vector3 result)
		{
			//Making a random point based on the center point + a random point inside the range
			Vector3 randomPoint = center + Random.insideUnitSphere * range;

			//Gettubg a sanmple position, essentailly looking and the random point and how its relative to the nav mesh zone, then raycasting it onto the nav mesh
			NavMeshHit hit;
			if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
			{
				// Make the result the position of that raycast
				result = hit.position;
				return true;
			}

			// If it doesnt hit something on the nav mesh then dont do anytrhing
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