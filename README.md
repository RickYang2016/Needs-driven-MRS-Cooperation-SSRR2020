# Needs-driven Heterogeneous MRS Cooperation
## Abstract
This paper focuses on the teaming aspects and the role of heterogeneity in a multi-robot system applied to robot-aided urban search and rescue (USAR) missions. We propose a needs-driven multi-robot cooperation mechanism represented through a Behavior Tree structure and evaluate the system's performance in terms of the group utility and energy cost to achieve the rescue mission in a limited time. From the theoretical analysis, we prove that the needs-driven cooperation in a heterogeneous robot system enables higher group utility than a homogeneous robot system. We also perform simulation experiments to verify the proposed needs-driven collaboration and show that the heterogeneous multi-robot cooperation can achieve better performance and increase system robustness by reducing uncertainty in task execution. Finally, we discuss the application to human-robot teaming.

> Paper: [Needs-driven Heterogeneous Multi-Robot Cooperation in Rescue Missions](https://ieeexplore.ieee.org/abstract/document/9292570)

## Needs-driven Model for Robot Cooperation
In nature, from cell to human, all intelligent agents represent different kinds of hierarchical needs such as the low-level physiological needs (food and water) in microbe and animal; the high-level needs self-actualization (creative activities) in human being. Simultaneously, intelligent agents can cooperate or against each other based on their specific needs. As an artificial intelligence agent -- robot, to organize its behaviors and actions, we introduced the needs hierarchy of robots in to help MRS build cooperative strategies considering their individual and common needs. Specifically, the robots possess the following order of needs hierarchy: 
* Safety needs (avoid collisions, safe environment, etc.); 
* Basic needs (Energy, time, mobility, etc.); 
* Capability needs (task-specific such as carry or supply resources); 
* Teaming needs (enhancing group utility and group survival); 
* Learning needs (self-upgrade and evolution).

<div align = center>
<img src="https://github.com/RickYang2016/Qin-Yang-PhD-Dissertation-SASS/blob/main/figures/sass.png" height="500" alt="Hopper-V2 3SABC"/>
</div>

<div align = center>
<img src="https://github.com/RickYang2016/Needs-driven-MRS-Cooperation-SSRR2020/blob/master/figures/heter_cooper.png" height="245" alt="Hopper-V2 3SABC"><img src="https://github.com/RickYang2016/Needs-driven-MRS-Cooperation-SSRR2020/blob/master/figures/overview.gif" height="245" alt="Hopper-V2 3SABC Video"/>
</div>

<div align = center>
<img src="https://github.com/RickYang2016/Needs-driven-MRS-Cooperation-SSRR2020/blob/master/figures/h-c.gif" height="245" alt="Hopper-V2 3SABC"><img src="https://github.com/RickYang2016/Needs-driven-MRS-Cooperation-SSRR2020/blob/master/figures/h-o.gif" height="245" alt="Hopper-V2 3SABC Video"/>
</div>

## Conclusion
We presented an overview of the needs-driven cooperation model for heterogeneous multi-robot systems and theoretically analyzed the importance of heterogeneity in increasing rescue mission performance. As the higher-level intelligent creature globally, humans represent more complex and diversified needs such as personal security, health, friendship, love, respect, recognition, and so forth. When we consider humans and robots work as a team, organizing their needs and getting a common ground is a precondition for human-robot collaboration in urban search and rescue missions.

From a robot needs perspective, it first needs to guarantee human security and health, such as avoiding collision with humans, protecting them from radiation, and so forth. But in the higher level teaming needs, robots should consider human team members' specialty and capability to form corresponding heterogeneous Human-Robot team adapting specific rescue missions automatically.

Humans also expect robots to provide safety and a stable working environment in aiding rescue missions from human needs. Furthermore, efficient and reliable assistance plays an essential element for the entire rescue missions. More importantly, designing an Interruption Mechanism can help humans interrupt robots' current actions and re-organize them to fulfill specific emergency tasks or execute some crucial operations manually.
