using UnityEngine;
using System.Collections;

public class moveGauold : MonoBehaviour {
	GameObject move, mainCamera,otherShips;
	public bool reachDestination = false, check = false;
	bool secondaryMovement,abilityTomove = false;
	Vector3 oriMother;
	public string attackName;
	movement moving;
	// Use this for initialization
	void Start () {
		move = GameObject.FindGameObjectWithTag("Ori Mothership - 2");
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		oriMother = new Vector3(move.transform.position.x,move.transform.position.y-400,move.transform.position.z);
		moving = mainCamera.GetComponent<movement>();
		otherShips = GameObject.FindGameObjectWithTag("Hatak 1");
	}

	public int co = 0;
	
	public Vector3[] path;
	// Update is called once per frame
	void Update () {
		secondaryMovement = otherShips.GetComponent<moveGauold>().check;
		oriMother = new Vector3(move.transform.position.x,move.transform.position.y-400,move.transform.position.z);
		if((Vector3.Distance(mainCamera.transform.position, transform.position) <=642.490f)&&(gameObject.name == "Hatak - 1")){
			if(Vector3.Distance(transform.position,oriMother)>=2000.627){
				transform.position = Vector3.MoveTowards(transform.position,oriMother,10);
			}else{
				if(!check)
					reachDestination = true;
				check = true;
			}

		}

		if((check)||(secondaryMovement)){
			if(gameObject.name =="Hatak - 1")
				hatak1();
			else if(gameObject.name =="Hatak - 2")
				hatak2();
			else if(gameObject.name =="Hatak - 4")
				hatak4();
			else if(gameObject.name =="Hatak - 5")
				hatak5();
			else if(gameObject.name =="Hatak - 5.2")
				hatak();
			else if(gameObject.name =="Hatak - 6")
				hatak6();
			else if(gameObject.name =="Hatak - 7")
				hatak7();
			else if(gameObject.name =="Hatak - 8")
				hatak8();
			else if(gameObject.name =="Hatak - 9")
				hatak9();
			else if(gameObject.name =="Hatak - 10")
				hatak10();
			int gig = path.Length-1;
			if((Vector3.Distance(transform.position, path[co]) >= 10)&&(co<=gig)&&(!abilityTomove)&&
			   (!moving.changeCam)&&((!moving.moveShip7)||(!moving.moveShip5))){
				transform.position = Vector3.MoveTowards(transform.position,path[co],10);
			}else if((gameObject.name =="Hatak - 7")&&(moving.moveShip7)){
				transform.position = Vector3.MoveTowards(transform.position,new Vector3(move.transform.position.x,move.transform.position.y,move.transform.position.z-150),10);
			}
			else if((gameObject.name =="Hatak - 1")&&(moving.moveShip5)){
				transform.position = Vector3.MoveTowards(transform.position,GameObject.Find("lookOri").transform.position,10);
				abilityTomove = true;
			}
			else{
				if(co < path.Length-1){
					co++;
				}
			}
		}
	}

	void hatak1(){
		path = new Vector3[2];
		path[0] = new Vector3(223.8105f,331.5909f,-1792.582f);
		path[1] = new Vector3(168.0126f,331.5909f,-1359.965f);
		attackName = "Ori Mothership - 2";
	}

	void hatak2(){
		path = new Vector3[1];
		path[0] = new Vector3(-2145.175f,403.4883f,-789.873f);
		attackName = "Ori Mothership - 4";
	}


	void hatak4(){
		path = new Vector3[2];
		path[0] = new Vector3(-2050.306f,23.01758f,-4629.217f);
		path[1] = new Vector3(-2298.846f,23.01758f,-3762.881f);
		attackName = "Ori Mothership - 3";
	}

	void hatak5(){
		path = new Vector3[2];
		path[0] = new Vector3(168.0126f,323.5618f,-2668.738f);
		path[1] = new Vector3(168.0126f,331.5909f,-2902.943f);
		attackName = "Ori Mothership - 4";
	}

	void hatak6(){
		path = new Vector3[1];
		path[0] = new Vector3(-66.31902f,-242.5612f,-6589.535f);
		attackName = "Ori Mothership - 3";
	}

	void hatak7(){
		path = new Vector3[2];
		path[0] = new Vector3(2452.267f,158.5294f,-1800.358f);
		path[1] = new Vector3(2452.267f,158.5294f,-1881.729f);
		attackName = "Ori Mothership - 1";
	}

	void hatak(){
		path = new Vector3[1];
		path[0] = new Vector3(534.015f,-242.5612f,-3227.392f);
		attackName = "Ori Mothership - 1";
	}
	
	void hatak8(){
		path = new Vector3[1];
		path[0] = new Vector3(-700.694f, 535.571f, -900.0f);
		attackName = "Ori Mothership - 4";
	}
	
	void hatak9(){
		path = new Vector3[1];
		path[0] = new Vector3(431.2926f, 535.571f, -900.0f);
		attackName = "Ori Mothership - 2";
	}
	
	void hatak10(){
		path = new Vector3[1];
		path[0] = new Vector3(-179.694f, 535.571f, -900.0f);
		attackName = "Ori Mothership - 3";
	}
}
