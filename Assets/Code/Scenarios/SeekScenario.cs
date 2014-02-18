using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BGE.Scenarios
{
    public class SeekScenario : Scenario
    {

        public override string Description()
        {
            return "Seek Demo";
        }

        public override void Start()
        {
            Params.Load("default.txt");

            leader = CreateBoid(new Vector3(-20, 20, 20), leaderPrefab);
			Vector3[] arrayForMovement = new []{new Vector3(100,20,40),
				new Vector3(-150,20,-50),
				new Vector3(200,20,100),
				new Vector3(-100,20,-100),
				new Vector3(150,20,150)};

            CreateCamFollower(leader, new Vector3(0, 5, -10));
			leader.GetComponent<SteeringBehaviours>().turnOffAll();
			leader.GetComponent<SteeringBehaviours>().turnOn(SteeringBehaviours.behaviour_type.seek);
			leader.GetComponent<SteeringBehaviours>().seekTargetPos = arrayForMovement[0];
			leader.GetComponent<SteeringBehaviours>().obtainPoints(arrayForMovement);


            GroundEnabled(true);
        }

    }
}