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
## Proposed features
The proposed U# features include:
* **U# Code Snippet Library** to save developers time by avoiding "re-inventing the wheel" 
* **U# GitHub Code Search** to allow developers to search GitHub for publicly available U# code. 
* **U# Autocomplete** to implement an IntelliSense like plugin for U# 
* **U# Documentation & Helper** to allow users to use natural language to find help with U# code.
Additional features include
* **Featured as a plugin for Unity** We plan to implement this as an importable UI based tool for Unity.
* **GLSL to HLSL conversion** (Plus, direct integration with ShaderToy) - Using code from [ShaderMan](https://github.com/smkplus/ShaderMan), we plan to implement a tool to automatically convert between web GLSL and HLSL Unity shaders. smkplus's ShaderMan tool supposedly does this, but it does not seem to function on modern Unity.
* **Avatar Toggle Generator** to automate tedious avatar creation tasks
## Requirements
Specifics on requirements are dependent on which features we are able to fully implement. Details about some of these will be explained below in the *Timeline* subsection.
For Sprint 2, we aim to have some form of UI that is able to be installed in Unity. To do so, all developers must have access to the repo, to Unity, and to the VRChat SDK.
In general, *the overall goal is to have a platform-independent installable Unity asset that provides some number of helpful resources to aid VRChat content creators in the development process.*
Reaching such a goal by successfully implementing at least one of the above proposed features will allow us to deem this project a success.
VRChat development is a constantly changing, new field - so the feasability of some of these features is yet to be fully determined.
However, all of the tools and resources to do so are freely available, and *something* is possible for sure.
