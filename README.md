<p align="center">
  <img src="https://daren-stottrup.notion.site/image/https%3A%2F%2Fs3-us-west-2.amazonaws.com%2Fsecure.notion-static.com%2Fb140d187-a902-4d20-8bdf-d8e8f32ca37a%2FGauntlet_High_Score.png?table=block&id=1e40faa3-311b-433b-84df-b1b2c0013ee0&spaceId=f2ac5bd7-db8b-4b29-8205-809cd644ec3b&width=2000&userId=&cache=v2">
</p>

# The Gauntlet
To learn more about this game, visit [The Gauntlet](https://daren-stottrup.notion.site/The-Gauntlet-d60031524148480a895a7bcf8693a9ba) on my [portfolio](https://daren-stottrup.notion.site/Game-Portfolio-3bc5aac8cfcb4d32af26f20301371155).
<br>
To play this game, check out the [WebGL Version](https://play.unity.com/mg/other/webgl-builds-42193).

## Coursework Project
This project was part of a course I took, and looking back, it's jarring to see the lack of "private" and "public" keywords! Nevertheless, as with most of the coursework projects, there were additions I made to the game--features that made the project go from simple homework, to games that I felt comfortable sending to friends to play as evidence of my education.

## My Additions

#### Returning Player
I wanted there to be a feature where the player could [start fresh](https://github.com/dangerdaren/The-Gauntlet/blob/acca196975e5d5d79d9d40e1f958755fc51db570/Assets/UI/NewPlayer.cs#L23-L27), or could try to [beat their own saved score](Assets/Bank/HighScore.cs). When you chose New Player at the start, it overwrites the score saved in PlayerPrefs, but if you choose [Returning Player](https://github.com/dangerdaren/The-Gauntlet/blob/acca196975e5d5d79d9d40e1f958755fc51db570/Assets/UI/NewPlayer.cs#L29-L33), it will display your record on the bottom right of the screen (as well as the menu screen) so you can compare your current score with your highest score.

#### Ghost Turrets
I also felt like it was frustrating, not knowing where the turret might land when you clicked onto the screen (due to the combination of isometric view and tile based game design. So I added a ghost turret that would [appear under the mouse cursor](https://github.com/dangerdaren/The-Gauntlet/blob/acca196975e5d5d79d9d40e1f958755fc51db570/Assets/Environment/Tile.cs#L84-L92). I also made the ghost turret [contextually change color](https://github.com/dangerdaren/The-Gauntlet/blob/acca196975e5d5d79d9d40e1f958755fc51db570/Assets/Environment/Tile.cs#L124-L148)--when you have enough gold, the ghost turret lights up, and when you don’t have enough gold, it appears but is greyed out.

#### Remove Previously Placed Turrets
Finally, I added the ability to [right-click on any turret](https://github.com/dangerdaren/The-Gauntlet/blob/acca196975e5d5d79d9d40e1f958755fc51db570/Assets/Environment/Tile.cs#L97-L112) on the map to [destroy it and get a fraction of the gold back](https://github.com/dangerdaren/The-Gauntlet/blob/acca196975e5d5d79d9d40e1f958755fc51db570/Assets/Tower/Tower.cs#L52-L78). This is useful if you mis-clicked on the map, or if you want to modify your path after starting it (hint: this can be very strategic).
