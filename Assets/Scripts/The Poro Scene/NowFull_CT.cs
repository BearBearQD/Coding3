using NodeCanvas.Framework;
using ParadoxNotion.Design;
using static UnityEngine.EventSystems.EventTrigger;


namespace NodeCanvas.Tasks.Conditions {

	public class NowFull_CT : ConditionTask {

		//Getting the energy from the blackboard
        public BBParameter<float> energy;
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
			//Is the energy more then 90, well ill be damned the poro seems to be full
            return energy.value >= 90;
        }
	}
}