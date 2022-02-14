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
## Development Process
We plan to use the most suitable version of Agile for our project, which happens to be the standard Iterative design process. After looking into Scrum and XP, we determined they are overkill. Considering there are only two of us, having a separate product owner and scrum master is simply impossible, and daily 15 minute meetings are also unnecessary. Also with only two of us and one semester to complete the project, focusing on culture instead of processes, like in XP, could very well cost us extra time for no perceivable benefit. Luckily, with our small team size and expected small project overhead, the flexible and low-overhead management and development proccess of Iterative design seems to be ideal. Specifically, we will be doing feature-based milestones and sprints of approximately two weeks.
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
At the moment, we have not designated specific roles for each team member, however it is already clear to see that with Bryce is the unofficial product owner, what with his vision for what the customer wants and needs. With only two of us though, we are both also developers.
## Project Management
Specifics on requirements are dependent on which features we are able to fully implement. Details about some of these will be explained below in the *Timeline* subsection.
Initially, our aim is to have some form of UI that is able to be installed in Unity, which we will be focusing on in Sprint 2. To do so, all developers must have access to the repo, to Unity, and to the VRChat SDK.
In general, *the overall goal is to have a platform-independent installable Unity asset that provides some number of helpful resources to aid VRChat content creators in the development process.*
Once we have reached this goal as well as successfully implemented at least one of the above proposed features, we will be allowed to deem this project a success. At that point, our Unity asset is independent and installable, so the only thing to do is continue to provide additional feature.
VRChat development is a constantly changing, new field - so the feasability of some of these features is yet to be fully determined.
However, all of the tools and resources to do so are freely available, and *something* is possible for sure. Luckily there are no social, ethical, or legal constrints that will prevent us from accmplishing these tasks either.
## Timeline
Using the Sprint and Milestone based timeline we are planning, each two week period will consist of multiple smaller goals/tasks to be divided across team members. The first Sprint involves setting up the workspace, version control, ideas, and proposal. This sprint officially ended on Feb 11. The second Sprint's goal is to create a functional UI that is able to interface with Unity. This might be an incredibly simple milestone, but our team is not yet entirely clear on the process, so it must be figured out as we go along. The general timeline of milestones should look something like this
* **Sprint 1**: Setup & Goals (~1.5 weeks)... setting up objectives, dividing work, writing proposal
* **Sprint 2**: Installable Unity Asset... learning the UI system, implementing basic features (~1.5 weeks)
* **Sprint 3**: First useful feature... likely implementing ShaderMan's code (>1.5 weeks)
* **Sprint 4**: Second set of features (at least one per team member)... Probably start with Snippet Library, Documentation? (~2 weeks)
* **Sprint 5**: Third set of features... Auto Complete, Code Saerch (~2 weeks)
* **Sprint 6**: Thorough testing, more features, etc...

This is about 8 weeks of sprint content, and it is reasonable to assume a few days of testing between each sprint, as well as delays. With such a timeline, it should be straightforward to achieve project requirements and potentially be able to implement additional features like animation and toggle generators.
