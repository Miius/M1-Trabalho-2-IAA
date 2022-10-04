using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

//<summary>
//Game object, that creates maze and instantiates it in scene
//</summary>
public class MazeSpawner : MonoBehaviour {
	public enum MazeGenerationAlgorithm{
		PureRecursive,
		RecursiveTree,
		RandomTree,
		OldestTree,
		RecursiveDivision,
	}

	public MazeGenerationAlgorithm Algorithm = MazeGenerationAlgorithm.PureRecursive;
	public bool FullRandom = false;
	public int RandomSeed = 12345;
	public GameObject Floor = null;
	public GameObject Wall = null;
	public GameObject Pillar = null;
	public int Rows;
	public int Columns;
	public float CellWidth;
	public float CellHeight;
	public bool AddGaps = true;
	//public GameObject GoalPrefab = null;

	private BasicMazeGenerator mMazeGenerator = null;
	
	//Mudado
	//[SerializeField] private GameObject keys;
	//private List<Vector3> placesToSpawnKeysAndItems = new List<Vector3>();

	void Awake () {
		if (!FullRandom)
			Random.seed = RandomSeed;
		
		switch (Algorithm)
		{
			case MazeGenerationAlgorithm.PureRecursive:
				mMazeGenerator = new RecursiveMazeGenerator (Rows, Columns);
				break;
			case MazeGenerationAlgorithm.RecursiveTree:
				mMazeGenerator = new RecursiveTreeMazeGenerator (Rows, Columns);
				break;
			case MazeGenerationAlgorithm.RandomTree:
				mMazeGenerator = new RandomTreeMazeGenerator (Rows, Columns);
				break;
			case MazeGenerationAlgorithm.OldestTree:
				mMazeGenerator = new OldestTreeMazeGenerator (Rows, Columns);
				break;
			case MazeGenerationAlgorithm.RecursiveDivision:
				mMazeGenerator = new DivisionMazeGenerator (Rows, Columns);
				break;
		}
		
		mMazeGenerator.GenerateMaze ();
		
		for (int row = 0; row < Rows; row++) 
		{
			for(int column = 0; column < Columns; column++)
			{
				float x = column*(CellWidth+(AddGaps?.2f:0));
				float z = row*(CellHeight+(AddGaps?.2f:0));
				
				//placesToSpawnKeysAndItems.Add(new Vector3(x,0,z));

				MazeCell cell = mMazeGenerator.GetMazeCell(row,column);

				//Instantiate<GameObject(Floor,new Vector3(x,0,z), Quaternion.Euler(0,0,0)).transform.parent;
				
				
				if(cell.WallRight)
					Instantiate(Wall,new Vector3(x+CellWidth/2,0,z)+Wall.transform.position,Quaternion.Euler(0,90,0)).transform.parent = transform;// right
				if(cell.WallFront)
					Instantiate(Wall,new Vector3(x,0,z+CellHeight/2)+Wall.transform.position,Quaternion.Euler(0,0,0)).transform.parent = transform;// front
				if(cell.WallLeft)
					Instantiate(Wall,new Vector3(x-CellWidth/2,0,z)+Wall.transform.position,Quaternion.Euler(0,270,0)).transform.parent = transform;// left
				if(cell.WallBack)
					Instantiate(Wall,new Vector3(x,0,z-CellHeight/2)+Wall.transform.position,Quaternion.Euler(0,180,0)).transform.parent = transform;// back
				
				/*if(cell.IsGoal && GoalPrefab != null){
					tmp = Instantiate(GoalPrefab,new Vector3(x,1,z), Quaternion.Euler(0,0,0)) as GameObject;
					tmp.transform.parent = transform;
				}*/
			}
		}
		if(Pillar != null){
			for (int row = 0; row < Rows+1; row++) {
				for (int column = 0; column < Columns+1; column++) {
					float x = column*(CellWidth+(AddGaps?.2f:0));
					float z = row*(CellHeight+(AddGaps?.2f:0));
					Instantiate(Pillar,new Vector3(x-CellWidth/2,0,z-CellHeight/2),Quaternion.identity).transform.parent = transform;
				}
			}
		}
		
		/*for (int i = 0; i < 3; i++)
		{
			GameObject key;
			int randomPlace = Random.Range(1, placesToSpawnKeysAndItems.Count-1);
			key = Instantiate(keys,placesToSpawnKeysAndItems[randomPlace], Quaternion.Euler(0,0,0)) as GameObject;
			
			placesToSpawnKeysAndItems.RemoveAt(randomPlace);
		}*/
	}
}
