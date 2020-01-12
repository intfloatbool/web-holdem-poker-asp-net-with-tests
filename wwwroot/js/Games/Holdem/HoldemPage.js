import * as CardData from "./CardData.js";

const cardPath = "/img/Games/CardsResizing";
const cardBackPath = `${cardPath}/BACK.png`;
const fetchDataUrl = '/api/HoldemGame';
const delayToFetchMs = 3000;

let lastMatchId = -1;

const CardElements = {
    Player1_Card1: null,
    Player1_Card2: null,
    Player2_Card1: null,
    Player2_Card2: null,
    Table_Card1: null,
    Table_Card2: null,
    Table_Card3: null,
    Table_Card4: null,
    Table_Card5: null
}

document.addEventListener('DOMContentLoaded', function () {
    console.log(`HELLO! ITS A POKER FRONT!`);
    initializeCardImagesDOM();
    setInterval(handleServerData, delayToFetchMs);
});

function initializeCardImagesDOM() {
    for (let imgIdKey in CardElements) {
        CardElements[imgIdKey] = document.getElementById(imgIdKey);
        if (!CardElements[imgIdKey])
            console.error(`Cannot find card img with id ${imgIdKey} !`);
    }
}

async function handleServerData() {
    let response = await fetch(fetchDataUrl);

    if (response.ok) { 
        let json = await response.json();
        handleMatchCards(json);
    } else {
        console.error("HTTP ERROR: " + response.status);
    }
}

function handleMatchCards(matchData) {

    if (matchData.gameResultJson === null) {
        hideAllCards();
        return;
    }

    const gameResult = JSON.parse(matchData.gameResultJson);

    if (lastMatchId === matchData.matchID)
        return;

    console.log(`GameResult!: \n ${JSON.stringify(gameResult)}`);


    const player1_data = gameResult.Player1;
    const player2_data = gameResult.Player2;
    const table_data = gameResult.CardTable;

    const player1_cards = player1_data.Cards;
    const player2_cards = player2_data.Cards;
    const tableCards = table_data.Cards;

    CardElements.Player1_Card1.src = getCardImagePath(player1_cards[0]); 
    CardElements.Player1_Card2.src = getCardImagePath(player1_cards[1]); 

    CardElements.Player2_Card1.src = getCardImagePath(player2_cards[0]);
    CardElements.Player2_Card2.src = getCardImagePath(player2_cards[1]); 

    CardElements.Table_Card1.src = getCardImagePath(tableCards[0]);
    CardElements.Table_Card2.src = getCardImagePath(tableCards[1]);
    CardElements.Table_Card3.src = getCardImagePath(tableCards[2]);
    CardElements.Table_Card4.src = getCardImagePath(tableCards[3]);
    CardElements.Table_Card5.src = getCardImagePath(tableCards[4]);

    lastMatchId = matchData.matchID;
}

function hideAllCards() {
    for (let imgIdKey in CardElements) {
        const cardImgElem = CardElements[imgIdKey];
        if (cardImgElem.src != cardBackPath) {
            cardImgElem.src = cardBackPath;
        }
    }
}

function getCardImagePath(cardData) {
    let cardName = getNameOfCard(cardData.Rank, cardData.Suit);
    return `${cardPath}/${cardName}`;
}

function getNameOfCard(rank, suit) {
    let convertedRank = CardData.RanksDict[rank];
    let convertedSuit = CardData.SuitDict[suit];
    return `${convertedRank}_${convertedSuit}.png`;
}