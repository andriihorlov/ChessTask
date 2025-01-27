# ChessTask

## Project info
<b>Unity Version:</b> 6.0.30f1
- <b>Rendering Pipeline:</b> URP
- <b> Async Framework:</b> UniTask
- <b>3D Model Format Support:</b> glTF

## Task
The goal of this challenge is to load a chessboard geometry (in glTF format) from a web URL into a specific location in the scene.

#### Steps:

* The user should trigger the creation of a "marker" (a small square) to serve as a reference pose.
* After the marker is placed, load the chessboard glTF file in such a way that the black king piece aligns with the marker. All other pieces should maintain their relative positions to the black king.
* Create a World Space interface panel in the scene, positioned in a way that it can be easily read

![UI Layout](Documentation/UiElements.jpg)

## Development log 
Development log can be found [here](Documentation/DevelopmentLog.md)
