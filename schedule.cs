using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class schedule : MonoBehaviour {
	public List<Task> behavior;
	//public Transform destination;
	public GameObject timecounter;

	calendar timecount;
	UnityEngine.AI.NavMeshAgent agent;
	Animator anim;

	public int debughour;
	public int debugminute;


	[System.Serializable]
	public struct Task{
		public string name;
		public int starthour;
		public int endhour;

		public int duration;
		public int findDuration(){
			return duration = endhour - starthour;
		}

		public Transform location; //TODO:list of waypoints
	}


	//check time, if time go point

	//24 mn, 1mn = 1h

	//3 tiers:
	//moonlight/daylight: 12h each
	//sunrise/day/sunset/twilight: 6h each
	//dawn/morning/afternoon/mid afternoon/dusk/evening/midnight/small hours: 3h each

	//base routine: (bed table desk)
	//6h - wake up/breakfast (bed, table)
	//9h - begining work (desk)
	//12h - lunch break (table)
	//18h - going home/dinner (table)
	//21h - sleeping (bed)

	//state:
	//sleeping
	//waking up
	//standing up from bed
	//laying on bed

	//walking

	//sitting
	//eating at table
	//standing up from sit
	//working on desk

	//task:
	//location
	//start
	//stop
	//action (animation/goto/state)

	//if  start =< time > stop AND NOT at location then do task, return

	void Start(){
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		anim = GetComponent<Animator> ();

		timecount = timecounter.GetComponent<calendar> ();


		int i = 0; while(i < behavior.Count){
			Task t = behavior [i];

			t.duration = t.findDuration();
			i++; Debug.Log (t.duration);
		}
	}

	void Update(){
		

		//TODO: only check at the end of each task, compute percent of interval
		foreach (Task t in behavior) {
			if (t.starthour <= timecount.displaygamehour & timecount.displaygamehour < t.endhour)
				agent.SetDestination (t.location.position);
			//TODO:if element is last take care of the looping comparison, look at manual patrol example of looping

			//TODO:anim.
		}
		debughour = timecount.displaygamehour;
		debugminute = timecount.displaygameminute;

	}

}
