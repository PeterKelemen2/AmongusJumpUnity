# Among Us Jump Game in Unity
**Simple jumping game I made in Unity**

## Features

### Playing
- Infinite tile spawning based on preset combinations. They will destroy if the player is high enough
- There are coins to collect from these tiles. The amount is stored in a `CoinSave.txt` file.
- After ~150 points the **blue sky** background will change to a **spacey** one.
- **Pause Menu** can be toggled by pressing `E`. Here you can go to the Start Menu or Exit the game.
- Game is over if you fall low enough.
- High Score is shown on screen, the value is loaded form `Highscore.txt`.

### Skin Menu
- There are **3** type of skins you can choose from, that being Red, Gold and Green. These were initially meant to be purchased, but for ease of use this feature was not implemented.
- Selecting a skin will play an animation for them.
- The selected skin will be saved in `Model.txt`. This ensures that the skin will be saved even after quitting the game.
- Default skin is the red one.

### Start Menu
- From here you can start playing, select a skin or quit the game.
- Player movement keys are shown on the screen.
- All coins collected are shown on the screen.
- The background image is scrolling.

### Models
- All models were created by me, as well as the backround images.
