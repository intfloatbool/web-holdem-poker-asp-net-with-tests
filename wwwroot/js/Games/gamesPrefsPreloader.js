import * as Globals from '../Games/Globals/Globals.js';

document.addEventListener('DOMContentLoaded', function() {
    initializePlayersBoxes();
});

function initializePlayersBoxes() {
    const player1_name_element = document.getElementById(Globals.DocumentNames.PLAYER_1_NAME_ID);
    const player2_name_element = document.getElementById(Globals.DocumentNames.PLAYER_2_NAME_ID);

    if(player1_name_element) {
        player1_name_element.innerText = Globals.BotNames.PLAYER_1;
    }

    if(player2_name_element) {
        player2_name_element.innerText = Globals.BotNames.PLAYER_2;
    }
}