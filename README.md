## TanukiUdon - Unity & VRChat Tools
<p align="center">
<img src="https://user-images.githubusercontent.com/46682358/151814292-2190d836-3bd0-4bf4-b51c-9be484f4de6a.png" width=25% height=25%>
</p>
TanukiUdon is a suite of developer tools to make developing in Unity easier and more fun. Specifically, TanukiUdon features tools to enable speedy world and avatar creation for VRChat's SDK via Udon Sharp (U#).

## Proposal
[View the project proposal at PROPOSAL.md](PROPOSAL.md)

## Progress
Currently in progress on Milestone 5. Issues have been somewhat restructured, but progress is advancing normally with only minor delays.

*Note: Unity Collaboration tools are being used for portions of this project. Content is stored locally in the [Unity-Home-Tanuki-Udon](Unity-Home-Tanuki-Udon/) folder and is available for download from Unity's servers. Assume that Unity's version is the latest. Files stored on this repo are our code - importing the VRCSDK into a Unity project manually is required. Where this folder is the root folder named "TanukiUdon540", the structure should essentially be: *(TanukiUdon540/Unity-Home-Tanuki-Udon/Tanuki Udon)* - with the *Tanuki Udon* folder containing ./Assets, ./Library, etc.

**Currently producing Milestone 5.1: Autocomplete and Milestone 4.2: Documentation. Milestone 5.2: Code Search is nearly complete.**
![progress-overall-75](https://user-images.githubusercontent.com/46682358/163190791-94fc5b3c-2634-4843-af7b-6bdc3530d4be.png) ~75%

50% of all opened issues are cloesed, and many more are nearly complete considering the current state of the Plastic SCM repo.
In its current state, TanukiUdon is installable, helpful, and ready to be tested.

TanukiUdon's automation tools are able to automate many development activities: (single interact teleporter, single area teleporter, teleporter pairs, removing teleporters, creating/removing interactables, acquiring assets in multiple categories.) Each of these activities takes approximately 5 steps when completed manually, but only one step using TanukiUdon. Additionally, these concepts are not necessarily clearly explained externally. In its current state of 75% completion, we estimate **TanukiUdon accelerates basic world creation by 2-3x. We expect 5x acceleration upon final milestone completion.**

Though each of these individually automated tasks takes only a few moments, learning to do so and repeatedly doing so can add hours to the world creation time.

It is difficult to measure development productivity as this repo is periodically updated (currently at 49 commits) from the Unity version control. Developers are successfully receiving, assigning, and responding to issues, and all commits have been meregd without issue - meaning nearly all work could be considered productive.




## Code Snippets Feature
The latest revision of TanukiUdon includes a feature to display and download commonly used VRChat assets and tools.
![image](https://user-images.githubusercontent.com/46682358/163099991-567dca97-6749-43c0-a341-58a5d7f396a1.png)
