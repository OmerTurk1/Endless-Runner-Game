# Endless-Runner-Game
This repository contains my endless runner game.
## Goal:
Player must go as far as he can. He should collect items and power-ups.
## Coins:
Main source for transactions(i will handle it later)
## Power-ups:
- Magnet - attracts money to the player. has an effect of 15 seconds.
- Shield - Adds an extra health. Taking multiple shields does not increase the health, max health can be 2.
- Speeder - Player's +z velocity becomes 50 m/s for 10 seconds. increment and decrement will be gradient.
- Coin Multipler - Gives x2 or x3 gain from laterly collected coins based on increment amount.
## Obstacles:
If player hit one of them and don't have a shield, he dies.
- Static Obstacles - I have those assets in my previous unsuccessful project
- Dynamic Obstacles - They will oscillate, turn or rotate in a loop
## Achievements
The more player plays the game, the more achievement he completes, attracting the player even more to the game.
## Enviroment
The environment will change from time to time, player will not play a single place. rahter than textural changing, color change will be easier for me to automatize.
I am now projecting to use a colorful fog to limit far vision, and some structures (like columns or any object) to decorate.
