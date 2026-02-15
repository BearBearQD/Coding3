using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;



namespace NodeCanvas.Tasks.Actions {

	public class Eating_AT : ActionTask {
        public LayerMask targetMask;
        public float scanRadius = 3f;
        public float eatingRange;
        public BBParameter<NavMeshAgent> agents;
        Transform currentTarget;
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
            Collider[] objectsInRange = Physics.OverlapSphere(agent.transform.position, scanRadius, targetMask);

            if (objectsInRange.Length > 0)
            {
                currentTarget = objectsInRange[0].transform;
            }
            else
            {
                currentTarget = null;
            }
            agents.value.SetDestination(currentTarget.position);

            Collider[] objectsEatingInRange = Physics.OverlapSphere(agent.transform.position, eatingRange, targetMask);
            if (objectsInRange.Length > 0)
            {
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