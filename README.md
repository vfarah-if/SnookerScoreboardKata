# SnookerScoreboardKata
A Kata enspired by @Chris Bimson

Write a program to track the score of a game of [Snooker](https://en.wikipedia.org/wiki/Snooker) played according to rules based upon the [simplified rules](http://www.rulesofsnooker.com/snooker-for-beginners.html) for beginners.
	
The program should accept the shots taken by each player as input and update the players' scores as appropriate. It should also track the current player, as well as determine a winner when the game is over.
	
## The Rules
	
In a single game (called a frame) of Snooker two players compete to win by scoring most points.
	
Points are scored by potting (striking the cue ball with the cue, causing the cue ball to hit another snooker ball such that the other ball rolls into a pocket) balls into the pockets on the table. Penalty points are also awarded when the opposing player commits a foul (infringes the rules).
	
The colour of a snooker ball determines the points awarded for potting it:
	
*  Red - 1
*  Yellow - 2
*  Green - 3
*  Brown - 4
*  Blue - 5
*  Pink - 6
*  Black - 7
	
The non-red (excluding the cue ball, which is white) coloured balls are collectively referred to as 'colours'. At the start of a frame there are 15 'reds' on the table and 1 of each of the colours, arranged in the following configuration: 
	
![Snooker table with balls placed in their starting positions.](https://en.wikipedia.org/wiki/Snooker#/media/File:Snooker_table_drawing_2.svg)
	
### Normal Play
	
If there are still reds on the table when a player starts a turn, then all the reds are 'on' (the on ball is the ball the player must pot next).  
	
If the player pots a red ball, the player scores one point and the red ball remains in the pocket and is no longer in play. For their next shot, the player may nominate any of the colours as the on ball. If the player then pots the on coloured ball, the player scores the point value of that ball. The coloured ball is then returned to the table in it's starting position.
	
If there are still reds remaining, then the red balls are back on and this sequence of play continues until all the red balls have been potted. 
	
When there are no red balls remaining on the table then the coloured balls must be potted in the order of ascending point value. 
	
When all the reds are gone and a coloured ball is potted, it remains in the pocket. The frame is over when the last ball, the black, is potted and the player with the most points wins.
	
If at any point the player fails to pot the on ball, their turn is over and the opposing player's turn begins.
	
If at any point the player commits a foul, the turn is over. Penalty points will be awarded to the opposing player and their next turn begins.
	
### Fouls
	
If the first ball struck by the cue ball is not the on ball, the opposing player is awarded penalty points equal to the value of the ball that was struck or 4 points, whichever is greater.
	
If a ball other than the on ball is potted then the opposing player is awarded penalty points equal to the value of the potted ball or 4 points, whichever is greater. Note that red balls potted in error are removed from play. Coloured balls potted in error are returned to their starting positions if there are still reds remaining, otherwise they are removed from play.
	
If a player fails to hit any ball with the cueball, the opposing player is awarded penalty points equal to the value of the on ball or 4 points, whichever is greater.
	
If a player pots the cueball, the opposing player is awarded 4 penalty points.
	
## Examples
	
The examples are provided in the gherkin DSL for clarity. They are not intended to constrain the testing approach. 
	
Assume that Player 1 always takes the first turn.
	
	```
	Given a new Frame
	Then Player 1 is the current player
	And the score is 0 - 0
	```
	
	```
	Given a new Frame
	When Player 1 pots a red
	Then the score is 1 - 0
	```
	
	```
	Given a new Frame
	When Player 1 pots a red
	And then nominates the black
	And then pots the black
	Then the score is 8 - 0
	And Player 1 is still the current player
	```
	
	```
	Given a new Frame
	When Player 1 pots a red
	And then nominates the black
	And then misses their shot
	Then the score is 1 - 7
	And Player 2 is now the current player
	```
	
## Extending the Kata
	
### Breaks
	
The total number of points scored by a player during one turn is called a 'break'. The maximum possible break is 147. This is achieved by potting a black after every red, followed by all of the colours.
	
Modify the program to track the current player's break in addition to their score. 
	
### Points Remaining
	
It is not uncommon for a frame to end when one player concedes. Typically a player will concede if there are not enough points available on the table to beat the other player's score, and they don't believe they will be able to force the other player to commit enough fouls ('snooker' them) to make up the difference. 
	
Modify the program to track the maximum possible number of points remaining.
