using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;



namespace NodeCanvas.Tasks.Actions {

	public class Eating_AT : ActionTask {

        // For checking what layer to hit
        public LayerMask targetMask;

        // Scan radiuses
        public float scanRadius = 3f;
        public float eatingRange;
        
        //Getting the agent stuff
        public BBParameter<NavMeshAgent> agents;
        Transform currentTarget;

        //Getting teh enerygy variable from the blackboard
        public BBParameter<float> energy;

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

            // Checking for the food
            Collider[] objectsInRange = Physics.OverlapSphere(agent.transform.position, scanRadius, targetMask);

            // IS THERE FOOD???
            if (objectsInRange.Length > 0)
            {
                //There is food well then set the current target to the first object in the array
                currentTarget = objectsInRange[0].transform;
            }
            else
            {
                currentTarget = null;
            }
            
            //Move that poro to the position of the food
            agents.value.SetDestination(currentTarget.position);

            //Checkking if the food is in range
            Collider[] objectsEatingInRange = Physics.OverlapSphere(agent.transform.position, eatingRange, targetMask);

            //Is in range??
            if (objectsEatingInRange.Length >= 1)
            {
                // If it is just set the energy value to 100
                energy.value = 100f;
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