using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawn : MonoBehaviour

{
	public GameObject spawnObject;
	public GameObject cube;
    Vector3 click;

	void Update()
    {		Vector3 clickPosition = -Vector3.one;
           
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			

			if (Physics.Raycast(ray, out hit)) 
				{	
					clickPosition = hit.point;
					click = clickPosition - cube.transform.position;
					if(Input.GetMouseButtonDown(0) && click.magnitude > 8)
					{	
						clickPosition.y = 4	;
						GameObject[] candidates = GameObject.FindGameObjectsWithTag("Sphere");
						int count =0;
						for (int i =0;i<candidates.Length;i++){
							var cc = clickPosition - candidates[i].transform.position;
							if(cc.magnitude<=4){
								count++;
							}
						}
						if(count==0){
							Instantiate(spawnObject, clickPosition, Quaternion.identity);
						}      
					}
				}    
		
		
	}
}
