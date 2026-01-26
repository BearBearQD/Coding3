using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class timeOfDayShifts : ActionTask {
        public GameObject otherObject;
        public BBParameter<float> timeOfDay;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            Blackboard otherBlackboard = otherObject.GetComponent<Blackboard>();
            float currentChangeRateMinus = otherBlackboard.GetVariableValue<float>("rateOfChangeMinus");
            float currentChangeRatePlus = otherBlackboard.GetVariableValue<float>("rateOfChangePlus");
   
            if (timeOfDay.value <= 90 && timeOfDay.value > 80)
            {
                currentChangeRateMinus = -15;
                currentChangeRatePlus = 35;
            }
            else if (timeOfDay.value <= 80 && timeOfDay.value > 70)
            {
                currentChangeRateMinus = -20;
                currentChangeRatePlus = 30;
            }
            else if (timeOfDay.value <= 70 && timeOfDay.value > 60)
            {
                currentChangeRateMinus = -25;
                currentChangeRatePlus = 25;
            }
            else if (timeOfDay.value <= 60 && timeOfDay.value > 50)
            {
                currentChangeRateMinus = -30;
                currentChangeRatePlus = 20;
            }
            else if (timeOfDay.value <= 50 && timeOfDay.value > 40)
            {
                currentChangeRateMinus = -32;
                currentChangeRatePlus = 15;
            }
            else if (timeOfDay.value <= 40 && timeOfDay.value > 30)
            {
                currentChangeRateMinus = -35;
                currentChangeRatePlus = 10;
            }
            else if (timeOfDay.value <= 30 && timeOfDay.value > 20)
            {
                currentChangeRateMinus = -37;
                currentChangeRatePlus = 7;
            }
            else if (timeOfDay.value <= 20 && timeOfDay.value > 10)
            {
                currentChangeRateMinus = -40;
                currentChangeRatePlus = 6;
            }
            else if (timeOfDay.value <= 10 && timeOfDay.value > 0)
            {
                currentChangeRateMinus = -42;
                currentChangeRatePlus = 5;
            }
            else if (timeOfDay.value <= 0)
            {
                currentChangeRateMinus = -10;
                currentChangeRatePlus = 35;
                timeOfDay.value = 100;
            }
            otherBlackboard.SetVariableValue("rateOfChangeMinus", currentChangeRateMinus);
            otherBlackboard.SetVariableValue("rateOfChangePlus", currentChangeRatePlus);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			timeOfDay.value -= Time.deltaTime;
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}