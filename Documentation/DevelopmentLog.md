# Development Journal

|Date       |Task                          |Time spent                         |
|----------------|-------------------------------|-----------------------------|
|Monday Evening    |Received task. Quick Overview.|            |
|Tuesday|Initialized git project. Created a Unity project and prepared the structure. |0.5 hour|
||Reviewed the task again. Researched and understood what GLTF is. Imported the package into the project and tested it.  |1 hour|
||Thought about architecture. Drew an Architecture Diagram. Prepared code for future use. Created models of the marker and floor.| 2 hours|
|Wednesday | Tried to understand how to load a 3D asset without spawning. First attempts at loading -> loaded all meshes separately and spawned them at `Vector3.zero`. Found out later that it is possible to spawn by scene. | 2 hours|
||Worked on the remaining functionality. Adjusted positions of the marker and chessboard. |1.5 hours|
|Thursday |inal code review. Made minor changes. Merged everything into the main branch. Prepared this document.|0.5 hour|

## Architecture Diagram
Please find below the architecture diagram
![Architecture diagram](Diagram.png)

## Notes
1. Implementing the state machine is symbolic, as I chose not to spend too much time on it.
2. Tests also weren't added at this stage to save time. If this is critical, let me know, and I will add them.