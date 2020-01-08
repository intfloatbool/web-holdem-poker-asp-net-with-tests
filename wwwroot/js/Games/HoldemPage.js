let cards = new Map();

//TODO Realize cards mapping
document.addEventListener('DOMContentLoaded', function () {
    console.log(`HELLO! ITS A POKER FRONT!`);
})

function getCardImage(rank, suit) {
    var cardName = getNameOfCard(rank, suit);

    return cards.get(cardName);
}

function getNameOfCard(rank, suit) {
    return `${rank}_${suit}`;
}