/Introduction/ <br />
The vineyard environment presented can be used for traversability estimation experiments while executing, for instance, crops spraying and inspection tasks. 
In particular, the terrain can be adjusted to display higher amounts of intricacy due to an array of different properties (steep, rocks, mud, foliage, tree leaves, branches). Exceptional attention should be placed on foliage that, due to its uncertain physical characteristics e.g. being compliant or not, often causes mischief when trying to determine traversability.


/Demo execution/  <br />
Install ROS1, http://wiki.ros.org/noetic/Installation<br />
Install Unity, https://unity3d.com/get-unity/download <br />
Download Unity Hub https://unity3d.com/get-unity/download<br />
Open the Unity Hub File<br />
Find the URL of the Unity Editor version 2020.1.0f1    https://unity.com/releases/2020-1<br />
Open a new Terminal window<br />
Run './Unity-Hub-imp<url_Unity_Editor><br />
Open Unity.Hub file<br />
Clone this repo<br />
Open this repo as a project in Unity <br />
Download ROS#, https://github.com/siemens/ros-sharp<br />
Import ROS# to Unity<br />
Executing a ROS Master<br />
Open the file `Assets/NAOUM.Unity` <br />
For RosBridge:<br />
Establish the connection between Unity and ROS, https://www.youtube.com/watch?v=OZiAJuWh6w8<br />
Replace the project's 'Rosharp' folder with the one from the official Rosharp repo<br />
Once the connection is established, press the 'Play' button on Unity<br />
You can now move the robot around the Unity environment, collected screenshots as input images and see robot's sensor topics in ROS.<br />


/Reference/ 
Reader can refer to https://dl.acm.org/doi/abs/10.1145/3453892.3462214 
