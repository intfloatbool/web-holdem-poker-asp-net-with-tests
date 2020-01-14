﻿import * as CardData from "./CardData.js";

const cardPath = "/img/Games/CardsResizing";
const cardBackPath = `${cardPath}/BACK.png`;
const fetchDataUrl = '/api/HoldemGame';
const comboBorderStyle = "border: 5px solid"
const player1_borderColor = '#014d68';
const player2_borderColor = '#454545';

const getStyleByColor = (color) => {
    return `${comboBorderStyle} ${color};`;
}

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

const MatchInfoElements = {
    WinnerText: null,
    ComboName: null,
    WinnerContainer: null
}

document.addEventListener('DOMContentLoaded', function () {

    MatchInfoElements.WinnerText = document.getElementById('winnerNameText');
    MatchInfoElements.ComboName = document.getElementById('combinationName');
    MatchInfoElements.WinnerContainer = document.getElementById('matchInfoRow');

    MatchInfoElements.WinnerContainer.hidden = true;

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

    showWinners(gameResult);

    lastMatchId = matchData.matchID;
}

function showWinners(matchResult) {

    MatchInfoElements.WinnerContainer.hidden = false;
    MatchInfoElements.WinnerText.innerText = "";

    const winners = matchResult.Winners;
    for (let playerWinnerID of winners) {
        const playerKeyInData = playerWinnerID === 'PLAYER_1' ? 'Player1' : 'Player2';
        const player = matchResult[playerKeyInData];
        highlightCombo(player.ComboCards, playerWinnerID);

        MatchInfoElements.WinnerText.innerText += `${CardData.BotNames[playerWinnerID]}\n`;
        MatchInfoElements.ComboName.innerText = CardData.ComboPrettyNames[player.Combination];
    }
}

function highlightCombo(comboCards, playerType) {
    if (!comboCards)
        return;

    let borderColor = playerType === "PLAYER_1" ? player1_borderColor : player2_borderColor;
    for (let card of comboCards) {
        const cardImgName = getNameOfCard(card.Rank, card.Suit);
        let frontCards = Object.values(CardElements);
        frontCards.find((element, index, array) =>
        {
            if (element.src.includes(cardImgName)) {
                element.style = getStyleByColor(borderColor);
            }
        });
    }
}

function hideAllCards() {
    MatchInfoElements.WinnerContainer.hidden = true;
    for (let imgIdKey in CardElements) {
        const cardImgElem = CardElements[imgIdKey];
        cardImgElem.style = "";
        if (cardImgElem.src != cardBackPath) {
            cardImgElem.src = cardBackPath;
        }
    }
}

function printWinnerData(winnerData) {

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