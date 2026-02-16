using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class CheckingForEnemy_CT : ConditionTask {
		// Getting the layer to check for
        public LayerMask targetMask;

		//The Scan radius of the scam
        public float scanRadius = 3f;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			//Checcking if anything with that layer is in the area
            Collider[] objectsInRange = Physics.OverlapSphere(agent.transform.position, scanRadius, targetMask);

			// Then move onto the next node if there is atleast 1 thing with the chosen layer in the area
			return objectsInRange.Length >= 1;

        }
	}
}