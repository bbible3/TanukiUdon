# TanukiUdon
**CS540 Project Proposal**

Bryce Bible, bbible3;  Damian Seals, dseals3
<hr/>

## Introduction
TanukiUdon is a tool to assist developers in Unity create VRChat content. Specifically, this tool aims to provide features to assist with Udon# code development. 
Udon# is a compiled dialect of C#, allowing programmers to use traditional programming methods over the default node-based Udon programming language commonly used to develop for the VRChat platform.
In addition to Udon# features, we also plan to implement VRC Avatar SDK Creation tools to assist with the animation process, and shader conversion features.
With VRChat now having nearly 15,000 daily active users, the need for development tools to the poorly documented VRChat-specific Udon language grows every day.
Using industry-standard software development techniques, many of which exist in the realm of "Software Supply Chain", we can hopefully save VRChat developers countless hours.
By implementing these techniques, we can allow developers to program more efficiently, more smartly, and with less barrier-to-entry, which is important for a platform that may be home to more less-experienced programmers.
## Customer Value
Our primary customer is the VRChat developer who would rather spend their time being productive, contributing to the community with new worlds or avatars, than waste their time completing the same rote tasks over and over again. It doesn't take long to imagine how annoying C would be without standard functions like printf, and it is for this reason we feel that U# needs help. Right now it is young, it needs the ease of use that other languages have had for many years. We will know if we have accomplished this goal when we are able to accomplish tasks in Unity in a fraction of the steps that it currently requires. Ultimately the goal is to increase usability and productivity while also minimizing frustration and time required as much as possible.
## Proposed Solution and Technology
The proposed U# features to solve this customer need include:
* **U# Code Snippet Library** to save developers time by avoiding "re-inventing the wheel" 
* **U# GitHub Code Search** to allow developers to search GitHub for publicly available U# code. 
* **U# Autocomplete** to implement an IntelliSense like plugin for U# 
* **U# Documentation & Helper** to allow users to use natural language to find help with U# code.
Additional features include
* **Featured as a plugin for Unity** We plan to implement this as an importable UI based tool for Unity.
* **GLSL to HLSL conversion** (Plus, direct integration with ShaderToy) - Using code from [ShaderMan](https://github.com/smkplus/ShaderMan), we plan to implement a tool to automatically convert between web GLSL and HLSL Unity shaders. smkplus's ShaderMan tool supposedly does this, but it does not seem to function on modern Unity.
* **Avatar Toggle Generator** to automate tedious avatar creation tasks
## Team
Between the two of us, the level of exposure and skill regarding both U# and Unity vary significantly. While Bryce has experience in 3D modeling, U#, and Unity, Damian has practically none. However, neither of us have built anything like the developer tool we are implementing this semester.
At the moment, we have not designated specific roles for each team member, however with timie it may become apparent that there is some sort of role system in place. For now though, Damian is looking into Unity and U# as a fresh beginner while Bryce is full steam ahead.
## Project Management
Specifics on requirements are dependent on which features we are able to fully implement. Details about some of these will be explained below in the *Timeline* subsection.
Initially, our aim is to have some form of UI that is able to be installed in Unity, which we will be focusing on in Sprint 2. To do so, all developers must have access to the repo, to Unity, and to the VRChat SDK.
In general, *the overall goal is to have a platform-independent installable Unity asset that provides some number of helpful resources to aid VRChat content creators in the development process.*
Once we have reached this goal as well as successfully implemented at least one of the above proposed features, we will be allowed to deem this project a success. At that point, our Unity asset is independent and installable, so the only thing to do is continue to provide additional feature.
VRChat development is a constantly changing, new field - so the feasability of some of these features is yet to be fully determined.
However, all of the tools and resources to do so are freely available, and *something* is possible for sure. Luckily there are no social, ethical, or legal constrints that will prevent us from accmplishing these tasks either.
## Timeline
