# Evolution Simulator 3
Evolution Simulator is a simulated petri dish in which two types of single celled life are present and competing with each other for survival. Each cell is tasked with procuring food. Prokaryotes eat the green food sources which naturally spawn over time throughout the dish. However, Eukaryotes can only eat meat food sources, dropped when another cell dies (By any means other than starvation) and so they hunt prokaryotic cells for food. When a cell meets the following conditions, it replicates into two cells (Some rules can be modified with in-game parameters):
- Reached Maturity (Elapsed Time Since Birth)
- Have Reached Their Food Requirement
When a cell reproduces, its genes may be randomly mutated by small amounts. Some mutations are linked to others, IE: Cell size mutations also impact cell speed. The following cell stats are genes that can be mutated during replication:
- Size
- Speed
- Sense Range
- Health
- Attack Damage
- Food Efficiency
- Food Capacity
- Reproductive Requirement

The intended result of this simulator is to simulate Evolution over time, as the cells inside the petri dish gradually form an ecosystem with the most optimal cell builds.
Internal Metrics Track Population, DNA Make-Ups, and Cell Stats over time to show the results of the simulation over time in game.


Try it out:

[Evolution Simulator 3 WebGL](http://www.piggytek.com/EvolutionSim/)
