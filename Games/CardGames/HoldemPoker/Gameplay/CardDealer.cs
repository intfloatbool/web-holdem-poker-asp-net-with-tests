using EthWebPoker.Games.CardGames.CardBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthWebPoker.Games.CardGames.HoldemPoker.Gameplay
{
    public class CardDealer
    {
        public List<Card> TempDeck { get; private set; }
        public List<ICardHolder> Players { get; private set; }
        public ICardHolder CardTable { get; private set; }
        public DeckOfCards Deck { get; private set; }

        private int _playerCardsCount;
        private int _tableCardsCount;

        private Random _rnd = new Random();

        public CardDealer(DeckOfCards deck, IEnumerable<ICardHolder> players,
            ICardHolder cardTable, int playerCards = 2, int tableCards = 5)
        {
            this.Deck = deck;
            this.Players = players.ToList();
            this.CardTable = cardTable;

            this._playerCardsCount = playerCards;
            this._tableCardsCount = tableCards;
            
        }

        public void DealCards()
        {
            this.Deck.RefershDeck();
            this.TempDeck = this.Deck.DeckCards.ToList();

            Players.ForEach(p => p.FoldCards());
            CardTable.FoldCards();

            foreach (var player in Players)
            {
                for(int i = 0; i < _playerCardsCount; i++)
                {
                    player.AddCard(GetRandomCard());
                }
            }

            for(int i = 0; i < _tableCardsCount; i++)
            {
                CardTable.AddCard(GetRandomCard());
            }
        }

        private Card GetRandomCard()
        {
            var rndCard = this.TempDeck[_rnd.Next(0, this.TempDeck.Count)];
            this.TempDeck.Remove(rndCard);
            return rndCard;
        }
    }
}
