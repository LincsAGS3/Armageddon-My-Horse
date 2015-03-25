using UnityEngine;
using System.Collections;

using KinectNet20;
using TankGameInput;
using KinectForWheelchair;

public class InputController : MonoBehaviour
{
	// Variables for output
	public GameInputInfo InputInfo;
	public KinectForWheelchair.SeatedInfo playerInfo;
	
	// Kinect stuff
	KinectSensor sensor;
	public static Skeleton[] skeletonData;

	
	// Input processor
	InputProcessor inputProcessor;
	SeatedInfoProcessor seatedInputProcessor;
	
	
	// Use this for initialization
	void Start ()
	{

		// Find a Kinect sensor
		KinectSensorCollection kinectSensors = KinectSensor.KinectSensors;
		if(kinectSensors.Count == 0)
		{
			this.sensor = null;
			throw new UnityException("Could not find a Kinect sensor.");
		}
		
		// Enable the skeleton stream
		this.sensor = kinectSensors[0];
		this.sensor.SkeletonStream.Enable();
		if(!this.sensor.SkeletonStream.IsEnabled)
			throw new UnityException("Sensor could not be enabled.");
		
		// Create the input processor
		inputProcessor = new InputProcessor(this.sensor.CoordinateMapper, DepthImageFormat.Resolution320x240Fps30);
		this.InputInfo = inputProcessor.GameInputInfo;
		this.seatedInputProcessor = new SeatedInfoProcessor ();
		
		Debug.Log("Hello");
		return;
	}
	
	void OnApplicationQuit()
	{
		// Dispose the Kinect sensor
		if(sensor != null)
		{
			sensor.Dispose();
			sensor = null;
		}
		
		Debug.Log ("Goodbye");
		return;
	}
	
	// Update is called once per frame
	void Update ()
	{

		
		// Retrieve skeleton data
		using(SkeletonFrame frame = this.sensor.SkeletonStream.OpenNextFrame(0))
		{
			if(frame != null)
			{
				// Allocate memory if needed
				if(skeletonData == null || skeletonData.Length != frame.SkeletonArrayLength)
				{
					skeletonData = new Skeleton[frame.SkeletonArrayLength];
				}
				
				frame.CopySkeletonDataTo(skeletonData);

			}
		}
		
		// Compute game input
		this.InputInfo = inputProcessor.ProcessData(skeletonData);

		if (skeletonData == null) 
		{
			return;
		}

		// Compute seated infos
		SeatedInfo[] seatedInfos = this.seatedInputProcessor.ComputeSeatedInfos (skeletonData);
		
		// Get seated skeleton
		int skeletonIndex = -1;
		for (int i=0; i<skeletonData.Length; i++)
		{
			if(seatedInfos[i].Posture == Posture.Seated)
				skeletonIndex = i;
		}
		
		// Compute seated info
		if (skeletonIndex != -1)
		{
			this.playerInfo = seatedInfos[skeletonIndex];
			Debug.Log ("Tracking skeleton.");
		}
		
		return;
	}
	
}
