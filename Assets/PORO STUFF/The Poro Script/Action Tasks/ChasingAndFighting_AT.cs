using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class ChasingAndFighting_AT : ActionTask {
		// For checking what layer to hit
        public LayerMask targetMask;

		// Range for both of the scans
        public float scanRadius = 3f;
		public float fightRadius = 0f;

		// Getting the parameters for the agent
        public BBParameter<NavMeshAgent> agents;
        Transform currentTarget;

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
			//Checking if enemy is in range to chase them
            Collider[] objectsInRange = Physics.OverlapSphere(agent.transform.position, scanRadius, targetMask);

			// ARE we in the range of an enemy??
            if (objectsInRange.Length > 0)
			{
                //There is enemy well then set the current target to the first object in the array
                currentTarget = objectsInRange[0].transform;
			}
			else
			{
				currentTarget = null;
			}

			//Making the agent go towards that position
			agents.value.SetDestination(currentTarget.position);

			//Checking for enemy but only in the fighting range
            Collider[] objectsFightingInRange = Physics.OverlapSphere(agent.transform.position, fightRadius, targetMask);
            foreach (Collider objectInRange in objectsFightingInRange)
            {
				//Getting the health variable 
                Blackboard enemyBlackBoard = objectInRange.GetComponentInParent<Blackboard>();
                float enemyHealth = enemyBlackBoard.GetVariableValue<float>("Health");

				// Setting it to 0
				enemyHealth = 0;
                enemyBlackBoard.SetVariableValue("Health", enemyHealth);
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