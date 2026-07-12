# Advanced Enemy Generation
There are several spawn points (enemy creation) at the level.
Each spawn point creates its own type of enemy and has a target—an object toward which the enemies move. When created, the spawn point transmits its target to the enemy, so that it can move toward it. There can be multiple such targets, each spawner having its own target.
The targets themselves move along a predetermined route, from one point to the next.